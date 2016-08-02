using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Diagnostics;
using System.Threading;
using Utility.存储;

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class CallerMemberNameAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class CallerFilePathAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class CallerLineNumberAttribute : Attribute { }
}

namespace Utility.通用
{
    public static class H日志
    {
        static readonly string _行分割 = Environment.NewLine;

        internal static H写文件 详细日志;

        internal static H写文件 错误日志;

        public static string 日志目录 { get; private set; }

        public static string 文件名称 { get; private set; }

        public static TraceEventType 输出级别 { get; set; }

        public static void 初始化(TraceEventType __输出级别 = TraceEventType.Verbose, string __日志目录 = "日志", string __文件名称 = null)
        {
            输出级别 = __输出级别;
            日志目录 = __日志目录;
            文件名称 = __文件名称;
            配置日志文件输出();
        }

        /// <summary>
        /// string 标题, string 内容, TraceEventType 等级, string 线程
        /// </summary>
        public static event Action<string, string, TraceEventType, string> 输出通知;

        public static void 触发输出通知(string __标题, string __内容, TraceEventType __等级, string __线程)
        {
            var handler = 输出通知;
            if (handler != null) handler(__标题, __内容, __等级, __线程);
        }

#pragma warning disable CS0436 // 类型与导入类型冲突
        public static void 记录(string __信息, TraceEventType __等级 = TraceEventType.Verbose, string __内容 = null, [CallerMemberName]string __方法 = "", [CallerFilePath]string __文件 = "", [CallerLineNumber]int __行号 = 0)
        {
            输出(__信息, __等级, __内容, __方法, __文件, __行号);
        }

        public static void 记录明细(string __信息 = "", string __内容 = null, [CallerMemberName]string __方法 = "", [CallerFilePath]string __文件 = "", [CallerLineNumber]int __行号 = 0)
        {
            输出(__信息, TraceEventType.Verbose, __内容, __方法, __文件, __行号);
        }

        public static void 记录提示(string __信息 = "", string __内容 = null, [CallerMemberName]string __方法 = "", [CallerFilePath]string __文件 = "", [CallerLineNumber]int __行号 = 0)
        {
            输出(__信息, TraceEventType.Information, __内容, __方法, __文件, __行号);
        }

        public static void 记录警告(string __信息, string __内容 = null, [CallerMemberName]string __方法 = "", [CallerFilePath]string __文件 = "", [CallerLineNumber]int __行号 = 0)
        {
            输出(__信息, TraceEventType.Warning, __内容, __方法, __文件, __行号);
        }

        public static void 记录错误(string __信息, string __内容 = null, [CallerMemberName]string __方法 = "", [CallerFilePath]string __文件 = "", [CallerLineNumber]int __行号 = 0)
        {
            输出(__信息, TraceEventType.Error, __内容, __方法, __文件, __行号);
        }

        public static void 记录致命(string __信息, string __内容 = null, [CallerMemberName]string __方法 = "", [CallerFilePath]string __文件 = "", [CallerLineNumber]int __行号 = 0)
        {
            输出(__信息, TraceEventType.Critical, __内容, __方法, __文件, __行号);
        }

        public static void 记录异常(Exception __异常, string __信息 = "", string __内容 = null, TraceEventType __等级 = TraceEventType.Error, [CallerMemberName]string __方法 = "", [CallerFilePath]string __文件 = "", [CallerLineNumber]int __行号 = 0)
        {
            __内容 = __内容 + Environment.NewLine + 获取异常描述(__异常);
            输出(__信息, __等级, __内容, __方法, __文件, __行号);
        }
#pragma warning restore CS0436 // 类型与导入类型冲突

        private static void 输出(string __信息, TraceEventType __等级, string __内容, string __方法, string __文件, int __行号)
        {
            if (__等级 > 输出级别)
            {
                return;
            }
            //__信息 = 字符串过滤(__信息);
            var __完整描述 = new StringBuilder();
            var __完整内容 = new StringBuilder();
            __完整描述.AppendFormat("{0}", __信息);
            if (!String.IsNullOrEmpty(__内容))
            {
                __完整内容.AppendFormat(" || {0}", __内容);
            }
            if (!String.IsNullOrEmpty(__文件))
            {
                __完整内容.AppendFormat(" || {0}({1});", __文件, __行号);
            }
            __完整描述.Append(__完整内容);
            详细日志.记录(__完整描述.ToString(), __等级);
            switch (__等级)
            {
                case TraceEventType.Critical:
                case TraceEventType.Error:
                    错误日志.记录(__完整描述.ToString(), __等级);
                    break;
            }
            触发输出通知(__信息, __完整内容.ToString(), __等级, Thread.CurrentThread.Name);
        }

        public static string 获取异常描述(Exception __异常)
        {
            var __描述 = new StringBuilder();
            __描述.AppendFormat("描述:\t{0}", __异常.Message).Append(_行分割);
            __描述.AppendFormat("类型:\t{0}", __异常.GetType().FullName).Append(_行分割);
            __描述.Append(__异常.StackTrace).Append(_行分割);
            var __内部异常 = __异常.InnerException;
            if (__内部异常 != null && __内部异常 != __异常)
            {
                __描述.Append(_行分割).Append("------------内部异常------------").Append(_行分割).Append(获取异常描述(__内部异常));
            }
            return __描述.ToString();
        }

        private static void 配置日志文件输出()
        {
            var __程序集 = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
            var __程序集名称 = __程序集.GetName();
            if (string.IsNullOrEmpty(文件名称))
            {
                文件名称 = __程序集名称.Name + "  " + __程序集名称.Version;
            }
            if (string.IsNullOrEmpty(日志目录))
            {
                日志目录 = "日志";
            }
            详细日志 = new H写文件("详细日志")
            {
                Append = true,
                AutoFlush = true,
                BaseFileName = 文件名称 + "  详细日志",
                Location = LogFileLocation.Custom,
                CustomLocation = H路径.获取绝对路径(日志目录, true),
                Delimiter = " || ",
                DiskSpaceExhaustedBehavior = DiskSpaceExhaustedOption.DiscardMessages,
                Encoding = Encoding.UTF8,
                LogFileCreationSchedule = LogFileCreationScheduleOption.Daily,
                MaxFileSize = 20000000,//20000000
                TraceOutputOptions = TraceOptions.ThreadId | TraceOptions.DateTime | TraceOptions.LogicalOperationStack,
                Filter = new EventTypeFilter(SourceLevels.All),
            };
            错误日志 = new H写文件("错误日志")
            {
                Append = true,
                AutoFlush = true,
                BaseFileName = 文件名称 + "  错误日志",
                Location = LogFileLocation.Custom,
                CustomLocation = H路径.获取绝对路径(日志目录, true),
                Delimiter = " || ",
                DiskSpaceExhaustedBehavior = DiskSpaceExhaustedOption.DiscardMessages,
                Encoding = Encoding.UTF8,
                LogFileCreationSchedule = LogFileCreationScheduleOption.Daily,
                MaxFileSize = 20000000,
                TraceOutputOptions = TraceOptions.ThreadId | TraceOptions.DateTime | TraceOptions.LogicalOperationStack,// | TraceOptions.Callstack,
                Filter = new EventTypeFilter(SourceLevels.Warning),
            };
        }
    }
}
