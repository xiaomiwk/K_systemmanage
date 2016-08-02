using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using Utility.存储;

namespace Utility.通用
{
    //确定要包括在日志文件名称中的日期。
    enum LogFileCreationScheduleOption
    {
        // 摘要: 
        //     不要将日期包括在日志文件名称中。
        None = 0,
        //
        // 摘要: 
        //     将当前日期包括在日志文件名称中。
        Daily = 1,
        //
        // 摘要: 
        //     将当前周的第一天包括在日志文件名称中。
        Weekly = 2,
    }

    //确定在试图写入日志而可用磁盘空间小于ReserveDiskSpace属性所指定的空间时应采取的操作。
    enum DiskSpaceExhaustedOption
    {
        // 摘要: 
        //     引发一个异常。
        ThrowException = 0,
        //
        // 摘要: 
        //     丢弃日志消息。
        DiscardMessages = 1,
    }

    //确定用来写入其日志文件的预定义路径。
    enum LogFileLocation
    {
        // 摘要: 
        //     使用当前系统的临时文件夹的路径。
        TempDirectory = 0,
        //
        // 摘要: 
        //     使用用户的应用程序数据的路径。
        LocalUserApplicationDirectory = 1,
        //
        // 摘要: 
        //     使用所有用户共享的应用程序数据的路径。
        CommonApplicationDirectory = 2,
        //
        // 摘要: 
        //     使用启动应用程序的可执行文件的路径。
        ExecutableDirectory = 3,
        //
        // 摘要: 
        //     如果 Microsoft.VisualBasic.Logging.FileLogTraceListener.CustomLocation 指定的字符串不为空，则使用该字符串作为路径。否则，使用用户的应用程序数据的路径。
        Custom = 4,
    }

    class H写文件 : TraceListener
    {
        private static readonly Dictionary<string, ReferencedStream> m_Streams = new Dictionary<string, ReferencedStream>();
        private ReferencedStream m_Stream;
        private DateTime m_Day;
        private int m_Days;
        private int num = 0;

        /// <summary>
        /// 获取或设置日志文件的位置。
        /// </summary>
        public LogFileLocation Location { get; set; }

        /// <summary>
        /// 指示写入日志文件流时是否刷新缓冲区。
        /// </summary>
        /// 
        /// <returns>
        /// Boolean，True 指示每次写入之后都刷新日志文件流；否则将缓存日志条目，这样写入会更有效率。 此属性的默认设置为 False。
        /// </returns>
        public bool AutoFlush { get; set; }

        /// <summary>
        /// 确定是将输出追加到当前文件还是将输出写入新文件。
        /// </summary>
        /// 
        /// <returns>
        /// Boolean，True 指示将输出追加到当前文件，False 指示将输出写入新文件。 此属性的默认设置为 True。
        /// </returns>
        public bool Append { get; set; }

        /// <summary>
        /// 确定在写入日志文件时，如果可用磁盘空间小于ReserveDiskSpace属性所指定的磁盘空间时应采取的操作。默认值为DiscardMessages。
        /// </summary>
        public DiskSpaceExhaustedOption DiskSpaceExhaustedBehavior { get; set; }

        /// <summary>
        /// 获取或设置日志文件的基名称，该名称用于创建日志文件的完整名称。
        /// </summary>
        /// 
        /// <returns>
        /// String. 日志文件的基名称。 默认为应用程序的产品名称。
        /// </returns>
        public string BaseFileName { get; set; }

        /// <summary>
        /// 获取当前日志文件的完整名称。
        /// </summary>
        /// 
        /// <returns>
        /// String，当前日志文件的完整名称。
        /// </returns>
        public string FullLogFileName { get; private set; }

        /// <summary>
        /// 确定要包括在日志文件名称中的日期。
        /// </summary>
        public LogFileCreationScheduleOption LogFileCreationSchedule { get; set; }

        /// <summary>
        /// 获取或设置所允许的日志文件的最大大小，以字节为单位。
        /// </summary>
        /// 
        /// <returns>
        /// Long. 这是允许的日志文件的最大大小（以字节为单位）。 默认值为 20000000(20M)。
        /// </returns>
        public long MaxFileSize { get; set; }

        /// <summary>
        /// 获取或设置在将消息写入日志文件之前需要满足的可用磁盘空间量（以字节为单位）。
        /// </summary>
        /// 
        /// <returns>
        /// Long. 这是所需的可用磁盘空间量。 默认值为 10000000(1G)。
        /// </returns>
        public long ReserveDiskSpace { get; set; }

        /// <summary>
        /// 获取或设置用于在日志消息中分隔字段的分隔符。
        /// </summary>
        /// 
        /// <returns>
        /// String，用作日志消息中字段的分隔符。 此属性的默认设置为制表符字符。
        /// </returns>
        public string Delimiter { get; set; }

        /// <summary>
        /// 获取或设置创建新日志文件时使用的编码。
        /// </summary>
        public Encoding Encoding { get; set; }

        private string m_CustomLocation;
        /// <summary>
        /// 当Location属性设置为LogFileLocation.Custom时获取或设置日志文件目录。
        /// </summary>
        /// 
        /// <returns>
        /// String，日志文件目录的名称。 此属性的默认设置是用户的应用程序数据目录。
        /// </returns>
        public string CustomLocation
        {
            [SecuritySafeCritical]
            get
            {
                string fullPath = Path.GetFullPath(this.m_CustomLocation);
                new FileIOPermission(FileIOPermissionAccess.PathDiscovery, fullPath).Demand();
                return fullPath;
            }
            set
            {
                string fullPath = Path.GetFullPath(value);
                if (!Directory.Exists(fullPath))
                    Directory.CreateDirectory(fullPath);
                if (this.Location == LogFileLocation.Custom & string.Compare(fullPath, this.m_CustomLocation, StringComparison.OrdinalIgnoreCase) != 0)
                    this.CloseCurrentStream();
                this.Location = LogFileLocation.Custom;
                this.m_CustomLocation = fullPath;
            }
        }

        private DateTime m_FirstDayOfWeek;

        private string LogFileName
        {
            get
            {
                string path1 = H路径.程序目录;
                string path2 = this.BaseFileName;
                switch (this.LogFileCreationSchedule)
                {
                    case LogFileCreationScheduleOption.Daily:
                        path2 = path2 + "  " + DateTime.Now.Date.ToString("MM-dd", CultureInfo.InvariantCulture);
                        break;
                    case LogFileCreationScheduleOption.Weekly:
                        this.m_FirstDayOfWeek = DateTime.Now.AddDays(checked(-unchecked((int)DateTime.Now.DayOfWeek)));
                        path2 = path2 + "  " + this.m_FirstDayOfWeek.Date.ToString("MM-dd", CultureInfo.InvariantCulture);
                        break;
                }
                return Path.Combine(path1, path2);
            }
        }

        private ReferencedStream ListenerStream
        {
            get
            {
                this.EnsureStreamIsOpen();
                return this.m_Stream;
            }
        }

        static H写文件()
        {
        }

        [HostProtection(SecurityAction.LinkDemand, Resources = HostProtectionResource.ExternalProcessMgmt)]
        public H写文件(string name)
            : base(name)
        {
            this.Location = LogFileLocation.LocalUserApplicationDirectory;
            this.AutoFlush = false;
            this.Append = true;
            this.DiskSpaceExhaustedBehavior = DiskSpaceExhaustedOption.DiscardMessages;
            this.BaseFileName = Assembly.GetEntryAssembly().GetName().Name;
            this.LogFileCreationSchedule = LogFileCreationScheduleOption.None;
            this.MaxFileSize = 20000000L;
            this.ReserveDiskSpace = 1000000000L;
            this.Delimiter = "\t";
            this.Encoding = Encoding.UTF8;
            this.m_CustomLocation = H路径.程序目录;
            this.m_Day = DateTime.Now.Date;
            this.m_Days = 0;
            this.m_FirstDayOfWeek = GetFirstDayOfWeek(DateTime.Now.Date);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        [HostProtection(SecurityAction.LinkDemand, Resources = HostProtectionResource.ExternalProcessMgmt)]
        public H写文件()
            : this("FileLogTraceListener")
        {
        }

        /// <summary>
        /// 将消息逐字写入磁盘，后跟当前行分隔符，不带任何附加上下文信息。
        /// </summary>
        [HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
        private void WriteLine1(string message)
        {
            try
            {
                this.HandleDateChange();
                message = message.Replace(Environment.NewLine, Environment.NewLine + "".PadLeft(47));
                if (!this.ResourcesAvailable(this.Encoding.GetByteCount(message + "\r\n")))
                    return;
                this.ListenerStream.WriteLine(message);
                if (!this.AutoFlush)
                    return;
                this.ListenerStream.Flush();
            }
            catch (Exception)
            {
                this.CloseCurrentStream();
                //throw;
            }
        }

        /// <summary>
        /// 将消息逐字写入磁盘，不带任何附加上下文信息。
        /// </summary>
        [HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
        public override void Write(string message)
        {
            TraceEvent(new TraceEventCache(), "", TraceEventType.Verbose, 0, message);
        }

        /// <summary>
        /// 将消息逐字写入磁盘，后跟当前行分隔符，不带任何附加上下文信息。
        /// </summary>
        [HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
        public override void WriteLine(string message)
        {
            TraceEvent(new TraceEventCache(), "", TraceEventType.Verbose, 0, message);
        }

        [HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
        public void 记录(string message, TraceEventType type)
        {
            TraceEvent(new TraceEventCache(), "", type, 0, message);
        }

        /// <summary>
        /// 将跟踪信息、消息和事件信息写入输出文件或流中。
        /// </summary>
        /// <param name="eventCache">包含当前进程 ID、线程 ID 以及堆栈跟踪信息的 <see cref="T:System.Diagnostics.TraceEventCache"/> 对象。</param><param name="source">调用此方法的跟踪源的名称。</param><param name="eventType"><see cref="T:System.Diagnostics.TraceEventType"/> 枚举值之一。</param><param name="id">事件的数值标识符。</param><param name="message">要写入的消息。</param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        [HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            if (this.Filter != null && !this.Filter.ShouldTrace(eventCache, source, eventType, id, message, null, null, null))
                return;
            var stringBuilder = new StringBuilder();
            //stringBuilder.Append("> ");
            //if ((this.TraceOutputOptions & TraceOptions.DateTime) == TraceOptions.DateTime)
            stringBuilder.Append(eventCache.DateTime.ToLocalTime().ToString("MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + this.Delimiter);
            //stringBuilder.Append(source + this.Delimiter);
            stringBuilder.Append(eventType.ToString().PadRight(11) + this.Delimiter);
            //stringBuilder.Append(id.ToString((IFormatProvider)CultureInfo.InvariantCulture) + this.Delimiter);
            if ((this.TraceOutputOptions & TraceOptions.ThreadId) == TraceOptions.ThreadId)
                stringBuilder.Append(eventCache.ThreadId.PadRight(4) + this.Delimiter);
            stringBuilder.Append(message);
            if ((this.TraceOutputOptions & TraceOptions.Callstack) == TraceOptions.Callstack)
                stringBuilder.Append(Environment.NewLine + "Callstack >>>>" + Environment.NewLine + eventCache.Callstack);
            if ((this.TraceOutputOptions & TraceOptions.LogicalOperationStack) == TraceOptions.LogicalOperationStack)
            {
                var __stack = StackToString(eventCache.LogicalOperationStack);
                if (!string.IsNullOrEmpty(__stack.Replace("\"", "")))
                {
                    stringBuilder.Append(Environment.NewLine + "LogicalOperationStack >>>>" + StackToString(eventCache.LogicalOperationStack));
                }
            }
            //if ((this.TraceOutputOptions & TraceOptions.ProcessId) == TraceOptions.ProcessId)
            //    stringBuilder.Append(this.Delimiter + eventCache.ProcessId.ToString(CultureInfo.InvariantCulture));
            //if ((this.TraceOutputOptions & TraceOptions.Timestamp) == TraceOptions.Timestamp)
            //    stringBuilder.Append(this.Delimiter + eventCache.Timestamp.ToString(CultureInfo.InvariantCulture));
            this.WriteLine1(stringBuilder.ToString());
        }

        /// <summary>
        /// 将跟踪信息、格式化对象数组和事件信息写入输出文件或流中。
        /// </summary>
        /// <param name="eventCache">包含当前进程 ID、线程 ID 以及堆栈跟踪信息的 <see cref="T:System.Diagnostics.TraceEventCache"/> 对象。</param><param name="source">调用此方法的跟踪源的名称。</param><param name="eventType"><see cref="T:System.Diagnostics.TraceEventType"/> 枚举值之一。</param><param name="id">事件的数值标识符。</param><param name="format">包含零个或多个格式项的格式字符串，这些项与 <paramref name="args"/> 数组中的对象相对应。</param><param name="args">包含零个或多个要格式化的对象的 Object 数组。</param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        [HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            string message = args == null ? format : string.Format(CultureInfo.InvariantCulture, format, args);
            this.TraceEvent(eventCache, source, eventType, id, message);
        }

        /// <summary>
        /// 向输出文件或流中写入跟踪信息、数据对象和事件信息。
        /// </summary>
        /// <param name="eventCache">包含当前进程 ID、线程 ID 以及堆栈跟踪信息的 <see cref="T:System.Diagnostics.TraceEventCache"/> 对象。</param><param name="source">调用此方法的跟踪源的名称。</param><param name="eventType"><see cref="T:System.Diagnostics.TraceEventType"/> 枚举值之一。</param><param name="id">事件的数值标识符。</param><param name="data">要发出的跟踪数据。</param>
        [HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            string message = "";
            if (data != null)
                message = data.ToString();
            this.TraceEvent(eventCache, source, eventType, id, message);
        }

        /// <summary>
        /// 将跟踪信息、数据对象数组和事件信息写入输出文件或流中。
        /// </summary>
        /// <param name="eventCache">包含当前进程 ID、线程 ID 以及堆栈跟踪信息的 <see cref="T:System.Diagnostics.TraceEventCache"/> 对象。</param><param name="source">调用此方法的跟踪源的名称。</param><param name="eventType"><see cref="T:System.Diagnostics.TraceEventType"/> 枚举值之一。</param><param name="id">事件的数值标识符。</param><param name="data">要作为数据发出的对象数组。</param>
        [HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, params object[] data)
        {
            var stringBuilder = new StringBuilder();
            if (data != null)
            {
                int num1 = checked(data.Length - 1);
                const int num2 = 0;
                int num3 = num1;
                int index = num2;
                while (index <= num3)
                {
                    stringBuilder.Append(data[index]);
                    if (index != num1)
                        stringBuilder.Append(this.Delimiter);
                    checked { ++index; }
                }
            }
            this.TraceEvent(eventCache, source, eventType, id, stringBuilder.ToString());
        }

        /// <summary>
        /// 刷新写入当前日志文件的基础流。
        /// </summary>
        [HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
        public override void Flush()
        {
            if (this.m_Stream == null)
                return;
            this.m_Stream.Flush();
        }

        /// <summary>
        /// 关闭当前日志文件的基础流，并释放与当前流关联的所有资源。
        /// </summary>
        /// <filterpriority>1</filterpriority>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        [HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
        public override void Close()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// 关闭基础流，并可以选择释放托管资源。
        /// </summary>
        /// <param name="disposing">若为 True，释放托管资源和非托管资源；若为 False，则只释放非托管资源。</param>
        [HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
        protected override void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            this.CloseCurrentStream();
        }

        [SecuritySafeCritical]
        private ReferencedStream GetStream()
        {
            ReferencedStream referencedStream = null;
            while (referencedStream == null && num < int.MaxValue)
            {
                string str = num != 0 ? Path.GetFullPath(this.LogFileName + ".log1" + "." + num) : Path.GetFullPath(this.LogFileName + ".log1");
                if (File.Exists(str) && new FileInfo(str).Length + 10000> this.MaxFileSize)
                {
                    ++num;
                    continue;
                }
                string key = str.ToUpper(CultureInfo.InvariantCulture);
                Dictionary<string, ReferencedStream> dictionary = m_Streams;
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(dictionary, ref lockTaken);
                    if (m_Streams.ContainsKey(key))
                    {
                        referencedStream = m_Streams[key];
                        if (!referencedStream.IsInUse)
                        {
                            m_Streams.Remove(key);
                            referencedStream = null;
                        }
                        else if (this.Append)
                        {
                            new FileIOPermission(FileIOPermissionAccess.Write, str).Demand();
                            referencedStream.AddReference();
                            this.FullLogFileName = str;
                            return referencedStream;
                        }
                        else
                        {
                            checked { ++num; }
                            referencedStream = null;
                            continue;
                        }
                    }
                    Encoding encoding = this.Encoding;
                    try
                    {
                        if (this.Append)
                            encoding = this.GetFileEncoding(str) ?? this.Encoding;
                        referencedStream = new ReferencedStream(new StreamWriter(str, this.Append, encoding));
                        referencedStream.AddReference();
                        m_Streams.Add(key, referencedStream);
                        this.FullLogFileName = str;
                        return referencedStream;
                    }
                    catch (IOException)
                    {
                    }
                    checked { ++num; }
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(dictionary);
                }
            }
            throw new Exception("ApplicationLog_ExhaustedPossibleStreamNames");
        }

        private void EnsureStreamIsOpen()
        {
            if (this.m_Stream != null)
                return;
            this.m_Stream = this.GetStream();
        }

        private void CloseCurrentStream()
        {
            if (this.m_Stream == null)
                return;
            Dictionary<string, ReferencedStream> dictionary = m_Streams;
            bool lockTaken = false;
            try
            {
                Monitor.Enter(dictionary, ref lockTaken);
                if (this.m_Stream == null)
                    return;
                this.m_Stream.CloseStream();
                if (!this.m_Stream.IsInUse)
                    m_Streams.Remove(this.FullLogFileName.ToUpper(CultureInfo.InvariantCulture));
                this.m_Stream = null;
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(dictionary);
            }
        }

        private bool DayChanged()
        {
            return DateTime.Compare(this.m_Day.AddDays(this.m_Days), DateTime.Now.Date) != 0;
        }

        private bool WeekChanged()
        {
            return DateTime.Compare(this.m_FirstDayOfWeek.Date, GetFirstDayOfWeek(DateTime.Now.Date)) != 0;
        }

        private static DateTime GetFirstDayOfWeek(DateTime checkDate)
        {
            return checkDate.AddDays(checked(-unchecked((int)checkDate.DayOfWeek))).Date;
        }

        private void HandleDateChange()
        {
            if (this.LogFileCreationSchedule == LogFileCreationScheduleOption.Daily)
            {
                if (!this.DayChanged())
                    return;
                this.m_Days = DateTime.Now.Date.Subtract(this.m_Day).Days;
                this.CloseCurrentStream();
            }
            else
            {
                if (this.LogFileCreationSchedule != LogFileCreationScheduleOption.Weekly || !this.WeekChanged())
                    return;
                this.CloseCurrentStream();
            }
        }

        private bool ResourcesAvailable(long newEntrySize)
        {
            if (checked(this.ListenerStream.FileSize + newEntrySize) > this.MaxFileSize)
            {
                this.CloseCurrentStream();
                ++num;
                return true;
                //if (this.DiskSpaceExhaustedBehavior == DiskSpaceExhaustedOption.ThrowException)
                //    throw new InvalidOperationException("ApplicationLog_FileExceedsMaximumSize");
                //else
                //    return false;
            }
            if (checked(this.GetFreeDiskSpace() - newEntrySize) >= this.ReserveDiskSpace)
                return true;
            if (this.DiskSpaceExhaustedBehavior == DiskSpaceExhaustedOption.ThrowException)
                throw new InvalidOperationException("ApplicationLog_ReservedSpaceEncroached");
            return false;
        }

        [SecuritySafeCritical]
        private long GetFreeDiskSpace()
        {
            return int.MaxValue;
        }

        private Encoding GetFileEncoding(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader streamReader = null;
                try
                {
                    streamReader = new StreamReader(fileName, this.Encoding, true);
                    if (streamReader.BaseStream.Length > 0L)
                    {
                        streamReader.ReadLine();
                        return streamReader.CurrentEncoding;
                    }
                }
                finally
                {
                    if (streamReader != null)
                        streamReader.Close();
                }
            }
            return null;
        }

        private static string StackToString(Stack stack)
        {
            int length = ", ".Length;
            var stringBuilder = new StringBuilder();
            try
            {
                foreach (object obj in stack)
                    stringBuilder.Append(obj + ", ");
            }
            finally
            {
            }
            stringBuilder.Replace("\"", "\"\"");
            if (stringBuilder.Length >= length)
                stringBuilder.Remove(checked(stringBuilder.Length - length), length);
            return "\"" + stringBuilder + "\"";
        }
    }

    internal class ReferencedStream : IDisposable
    {
        private StreamWriter m_Stream;
        private int m_ReferenceCount;
        private object m_SyncObject;
        private bool m_Disposed;

        internal bool IsInUse
        {
            get
            {
                return this.m_Stream != null;
            }
        }

        internal long FileSize
        {
            get
            {
                return this.m_Stream.BaseStream.Length;
            }
        }

        internal ReferencedStream(StreamWriter stream)
        {
            this.m_ReferenceCount = 0;
            this.m_SyncObject = new object();
            this.m_Disposed = false;
            this.m_Stream = stream;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void Write(string message)
        {
            object Expression = this.m_SyncObject;
            //ObjectFlowControl.CheckForSyncLockOnValueType(Expression);
            bool lockTaken = false;
            try
            {
                Monitor.Enter(Expression, ref lockTaken);
                this.m_Stream.Write(message);
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(Expression);
            }
        }

        internal void WriteLine(string message)
        {
            object Expression = this.m_SyncObject;
            //ObjectFlowControl.CheckForSyncLockOnValueType(Expression);
            bool lockTaken = false;
            try
            {
                Monitor.Enter(Expression, ref lockTaken);
                this.m_Stream.WriteLine(message);
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(Expression);
            }
        }

        internal void AddReference()
        {
            object Expression = this.m_SyncObject;
            //ObjectFlowControl.CheckForSyncLockOnValueType(Expression);
            bool lockTaken = false;
            try
            {
                Monitor.Enter(Expression, ref lockTaken);
                this.m_ReferenceCount = checked(this.m_ReferenceCount + 1);
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(Expression);
            }
        }

        internal void Flush()
        {
            object Expression = this.m_SyncObject;
            //ObjectFlowControl.CheckForSyncLockOnValueType(Expression);
            bool lockTaken = false;
            try
            {
                Monitor.Enter(Expression, ref lockTaken);
                this.m_Stream.Flush();
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(Expression);
            }
        }

        internal void CloseStream()
        {
            object Expression = this.m_SyncObject;
            //ObjectFlowControl.CheckForSyncLockOnValueType(Expression);
            bool lockTaken = false;
            try
            {
                Monitor.Enter(Expression, ref lockTaken);
                try
                {
                    this.m_ReferenceCount = checked(this.m_ReferenceCount - 1);
                    this.m_Stream.Flush();
                }
                finally
                {
                    if (this.m_ReferenceCount <= 0)
                    {
                        this.m_Stream.Close();
                        this.m_Stream = null;
                    }
                }
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(Expression);
            }
        }

        private void Dispose(bool disposing)
        {
            if (!disposing || this.m_Disposed)
                return;
            if (this.m_Stream != null)
                this.m_Stream.Close();
            this.m_Disposed = true;
        }
    }

}
