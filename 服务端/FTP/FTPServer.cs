//using LibFTPServ.VFS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Timers;
using System.Xml.Serialization;
using Timer = System.Timers.Timer;

namespace Utility.扩展
{
    /// <summary>
    /// FTP server class
    /// </summary>
    public class FTPServer
    {
        private TcpListener FTPListener;
        private int _port, _pass_min, _pass_max;
        private string _startdir;
        private List<IPAddress> _banlist;
        private List<IPAddress> _acceptlist;
        private List<FTPSession> FTPClients;
        private UserManager _userlist;
        private int _maxInactiveTime;
        private Timer DisconectInactive;
        //private VFSManager _VFS;
        private int _dlLimit, _ulLumit;

        /// <summary>
        /// Creates a new Instance of FTPServer
        /// </summary>
        public FTPServer()
        {
            FTPClients = new List<FTPSession>(2);
            _pass_min = 20000;
            _pass_max = 40000;
            _dlLimit = -1;
            _ulLumit = -1;
            _banlist = new List<IPAddress>();
            _acceptlist = new List<IPAddress>();
            _userlist = new UserManager();
            _port = 21;
            _maxInactiveTime = 30;
            //_VFS = new VFSManager();
            DisconectInactive = new Timer(_maxInactiveTime * 1000);
            DisconectInactive.Elapsed += new ElapsedEventHandler(DisconectInactive_Elapsed);
        }

        void DisconectInactive_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimeSpan ts;
            List<FTPSession> remove = new List<FTPSession>();
            foreach (FTPSession s in FTPClients)
            {
                ts = DateTime.Now - s.LastCommandTime;
                if (ts.TotalSeconds > _maxInactiveTime) remove.Add(s);
            }

            foreach (FTPSession rs in remove)
            {
                rs.Disconnect();
                FTPClients.Remove(rs);
            }
        }


        internal void RemoveClient(FTPSession s)
        {
            this.FTPClients.Remove(s);
        }

        #region Properties
        internal string Status
        {
            get { if (FTPListener == null) return "value=\"0\""; else return "value=\"1\" checked"; }
        }

        public int InactiveClientTimeOut
        {
            get { return _maxInactiveTime; }
            set
            {
                _maxInactiveTime = value;
                DisconectInactive.Interval = 1000 * _maxInactiveTime;
            }
        }

        internal bool IsRunning
        {
            get { return FTPListener != null; }
        }

        /// <summary>
        /// Gets or sets the ftp default port
        /// </summary>
        public int Port
        {
            get { return _port; }
            set
            {
                if (IsRunning) throw new InvalidOperationException("Port can only be changed when server is not running");
                _port = value;
            }
        }

        /// <summary>
        /// Gets or sets the minumum passive port number
        /// </summary>
        public int PassivePortMinimum
        {
            get { return _pass_min; }
            set
            {
                if (IsRunning) throw new InvalidOperationException("PassivePortMinum can only be changed when server is not running");
                _pass_min = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum passive port number
        /// </summary>
        public int PassivePortMaximum
        {
            get { return _pass_max; }
            set
            {
                if (IsRunning) throw new InvalidOperationException("PassivePortMaximum can only be changed when server is not running");
                _pass_max = value;
            }
        }

        /// <summary>
        /// Gets or sets the global startup directory
        /// </summary>
        public string StartupDir
        {
            get { return _startdir; }
            set
            {
                if (IsRunning) throw new InvalidOperationException("Start dir can only be changed when server is not running");
                _startdir = value;
            }
        }

        /// <summary>
        /// Gets the List of Banned Adresses on the server
        /// </summary>
        public List<IPAddress> BannedAdresses
        {
            get { return _banlist; }
        }

        /// <summary>
        /// Gets the always accepted list of Adresses on the server
        /// </summary>
        public List<IPAddress> AcceptedAdresses
        {
            get { return _acceptlist; }
        }

        /// <summary>
        /// Gets the user manager associated to this server
        /// </summary>
        public UserManager Users
        {
            get { return _userlist; }
        }


        /// <summary>
        /// Gets or sets the Server downlaod speed limit in Bytes/second. -1 is disabled
        /// </summary>
        public int DownloadSpeedLimit
        {
            get { return _dlLimit; }
            set { _dlLimit = value; }
        }

        /// <summary>
        /// Gets or sets the Server upload speed limit in Bytes/second. -1 disabled
        /// </summary>
        public int UploadSpeedLimit
        {
            get { return _ulLumit; }
            set { _ulLumit = value; }
        }

        //public VFSManager VFS
        //{
        //    get { return _VFS; }
        //    set
        //    {
        //        if (IsRunning) throw new InvalidOperationException("VFS can only be changed when server is not running");
        //        _VFS = value;
        //    }
        //}

        public bool UTF8 { get; set; }

        #endregion

        /// <summary>
        /// Starts the server
        /// </summary>
        public void Start()
        {
            Stop();

            FTPListener = new TcpListener(IPAddress.Any, _port);
            FTPListener.Start(20);
            //DisconectInactive.Start();
            // Start accepting the incoming clients.
            FTPListener.BeginAcceptSocket(new AsyncCallback(NewFTPClientArrived), null);
        }

        /// <summary>
        /// Stops the server
        /// </summary>
        public void Stop()
        {
            if (FTPListener != null)
            {
                FTPListener.Stop();
                DisconectInactive.Stop();
                FTPListener = null;
            }
        }

        private void NewFTPClientArrived(IAsyncResult arg)
        {
            try
            {
                FTPClients.Add(new FTPSession(FTPListener.EndAcceptSocket(arg), this, _startdir));
                FTPListener.BeginAcceptSocket(new AsyncCallback(NewFTPClientArrived), null);
            }
            catch { }
        }

        #region Events

        /// <summary>
        /// Event occures when a Logable event occures.
        /// </summary>
        public event FTPLogEventHandler OnLogEvent;

        internal virtual void Call_Log(FTPLogEventArgs e)
        {
            if (OnLogEvent != null) OnLogEvent(this, e);
        }

        #endregion
    }

    /// <summary>
    /// An FTP User management class
    /// </summary>
    [Serializable]
    public class FTPUser
    {
        /// <summary>
        /// The Name of the user
        /// </summary>
        public string Name;

        /// <summary>
        /// The SHA1 hash of the user's password
        /// </summary>
        public string SHA1Password;

        /// <summary>
        /// The home directory of the userr
        /// </summary>
        public string Startupdir;

        /// <summary>
        /// The Permissions associated to the user
        /// </summary>
        public FTPUserPermission Permissions;


        /// <summary>
        /// Creates a new instance of FTPUser
        /// </summary>
        public FTPUser()
        {
            Permissions = new FTPUserPermission();
            Startupdir = "/";
        }

        /// <summary>
        /// Creates a new instance of FTPUser
        /// </summary>
        /// <param name="name">The name of the user</param>
        /// <param name="pass">The desired password for the user</param>
        public FTPUser(string name, string pass)
        {
            Permissions = new FTPUserPermission();
            Name = name;
            Startupdir = "/";
            SHA1Password = HelperFunctions.SHA1Hash(pass);
        }

        public void SetPassword(string pass)
        {
            SHA1Password = HelperFunctions.SHA1Hash(pass);
        }

        /// <summary>
        /// Creates a new instance of FTPUser
        /// </summary>
        /// <param name="name">The name of the user</param>
        /// <param name="pass">The desired password for the user</param>
        /// <param name="dir">The startup directory of the user</param>
        public FTPUser(string name, string pass, string dir)
            : this(name, pass)
        {
            Startupdir = dir;
        }

        /// <summary>
        /// Returns a new Anonymus user
        /// </summary>
        public static FTPUser Anonymus
        {
            get
            {
                return new FTPUser("Anonymus", "");
            }
        }
    }

    internal class FTPListItem
    {
        public string Name;
        public bool IsDir;
        public long Size;
        public DateTime Date;

        public FTPListItem()
        {
            Name = "";
            IsDir = true;
            Size = 0;
            Date = DateTime.Now;
        }

        public FTPListItem(string name)
            : this()
        {
            Name = name;
        }

        public override string ToString()
        {
            string datestr = Date.ToString("MM-dd-yy hh:mmtt", new CultureInfo("en-US"));
            if (IsDir) return datestr + " <DIR> " + Name.Substring(Name.Replace('\\', '/').LastIndexOf('/') + 1) + "\r\n";
            else return datestr + " " + Size.ToString() + " " + Name.Substring(Name.Replace('\\', '/').LastIndexOf('/') + 1) + "\r\n";
        }
    }

    /// <summary>
    /// FTP User Permission management class
    /// </summary>
    [Serializable]
    public class FTPUserPermission
    {
        /// <summary>
        /// The User can upload
        /// </summary>
        public bool Upload;

        /// <summary>
        /// The user can delete files
        /// </summary>
        public bool Delete;

        /// <summary>
        /// The user can rename files
        /// </summary>
        public bool Rename;

        /// <summary>
        /// The user can see hidden files on directory and name list
        /// </summary>
        public bool ListHidden;

        /// <summary>
        /// Resets the current users permissions to default
        /// </summary>
        public void Reset()
        {
            Upload = false;
            Delete = false;
            Rename = false;
            ListHidden = false;
        }
    }

    class FTPSession
    {
        private DateTime _lastcmdtime, _conntime;
        private FTPServer _server;
        private string _currentDir, _localpath;
        private Socket _clientSocket, _datasocket;
        private string _connuser;
        private bool _isAuthenticated;
        private bool DataTransferEnabled;
        private TcpListener DataListener;
        private string _renamefrom;
        private byte[] _portBuffer = new byte[500];
        private bool _utf8;
#pragma warning disable 414
        private bool _activecommand;
#pragma warning restore 414
        // Used inside PORT method
        IPEndPoint[] ClientEndPoints;
        FTPUserPermission _currentperms;

        bool _isLinux;

        internal string SessionID
        {
            get
            {
                return _conntime.Ticks.ToString();
            }
        }

        internal string EndPoint
        {
            get
            {
                return _clientSocket.RemoteEndPoint.ToString();
            }
        }

        internal bool IsConnected
        {
            get
            {
                if (_clientSocket == null || !_clientSocket.Connected || _conntime.ToString("HH:mm:ss") == _lastcmdtime.ToString("HH:mm:ss"))
                {
                    Disconnect();
                    return false;
                }
                return true;
            }
        }

        internal DateTime LastCommandTime
        {
            get { return _lastcmdtime; }
        }

        internal FTPSession(Socket ClientSocket, FTPServer serv, string startdir)
        {
            _isLinux = Environment.NewLine == "\n";
            IPEndPoint p = (IPEndPoint)ClientSocket.LocalEndPoint;
            if (serv.BannedAdresses.Contains(p.Address) && !serv.AcceptedAdresses.Contains(p.Address)) Disconnect();
            else
            {
                this._clientSocket = ClientSocket;
                ClientSocket.NoDelay = false;
                _conntime = DateTime.Now;
                _server = serv;
                _currentDir = startdir;
                SendMessage("220 FTP Ready");
                _utf8 = serv.UTF8;
                // Wait for the command to be sent by the client
                ClientSocket.BeginReceive(_portBuffer, 0, _portBuffer.Length, SocketFlags.None, CommandReceived, null);
            }
        }

        internal void Disconnect()
        {
            if (_clientSocket != null && _clientSocket.Connected) _clientSocket.Close();
            _clientSocket = null;
            if (DataListener != null) DataListener.Stop();
            DataListener = null;
            if (_datasocket != null && _datasocket.Connected) _datasocket.Close();
            _datasocket = null;
            _connuser = null;
            ClientEndPoints = null;
            _server.RemoveClient(this);
            _portBuffer = null;
            _renamefrom = null;
            GC.Collect();
        }

        void CommandReceived(IAsyncResult arg)
        {
            _activecommand = false;
            int CommandSize = 0;
            try
            {
                CommandSize = _clientSocket.EndReceive(arg);
            }
            catch (Exception)
            {
            }
            if (CommandSize == 0)
            {
                Disconnect();
                return;
            }

            // Wait for the next command to be sent by the client
            try
            {
                _clientSocket.BeginReceive(_portBuffer, 0, _portBuffer.Length, SocketFlags.None, CommandReceived, null);

                _lastcmdtime = DateTime.Now;
                var CommandText = _utf8 ? Encoding.UTF8.GetString(_portBuffer, 0, CommandSize).TrimStart(' ') : Encoding.Default.GetString(_portBuffer, 0, CommandSize).TrimStart(' ');
                string CmdArguments = null;
                int End;
                if ((End = CommandText.IndexOf(' ')) == -1) End = (CommandText = CommandText.Trim()).Length;
                else CmdArguments = CommandText.Substring(End).TrimStart(' ');
                var Command = CommandText.Substring(0, End).ToUpper();

                if (CmdArguments != null && CmdArguments.EndsWith("\r\n")) CmdArguments = CmdArguments.Substring(0, CmdArguments.Length - 2);
                bool CommandExecued = false;
                switch (Command)
                {
                    case "USER":
                        _activecommand = true;
                        if (!string.IsNullOrEmpty(CmdArguments))
                        {
                            SendMessage("331 Password required!");
                            _connuser = CmdArguments;
                        }
                        CommandExecued = true;
                        break;
                    case "PASS":
                        _activecommand = true;
                        if (_connuser == "")
                        {
                            SendMessage("503 Invalid User Name");
                            return;
                        }
                        if (_server.Users.Count == 0)
                        {
                            _isAuthenticated = true;
                            _currentDir = "/";
                            _localpath = _server.StartupDir;
                            _currentperms = new FTPUserPermission { Delete = true, Rename = true, Upload = true, ListHidden = false };
                            _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.UserConnect, _connuser, true, 230, "none"));
                            SendMessage("230 Authentication Successful");
                        }
                        else
                        {
                            if (_server.Users[_connuser] != null)
                            {
                                if (_server.Users[_connuser].SHA1Password == HelperFunctions.SHA1Hash(CmdArguments))
                                {
                                    _isAuthenticated = true;
                                    _currentDir = "/";
                                    _currentperms = _server.Users.GetPermissions(_connuser);
                                    if (string.IsNullOrEmpty(_server.Users[_connuser].Startupdir) || _server.Users[_connuser].Startupdir == "/")
                                    {
                                        _localpath = _server.StartupDir;
                                    }
                                    else
                                    {
                                        _localpath = _server.Users[_connuser].Startupdir;
                                    }
                                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.UserConnect, _connuser, true, 230, "none"));
                                    SendMessage("230 Authentication Successful");
                                }
                                else
                                {
                                    SendMessage("530 Authentication Failed!");
                                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.UserConnect, _connuser, false, 530, "none"));
                                }
                            }
                            else
                            {
                                SendMessage("530 Authentication Failed!");
                                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.UserConnect, _connuser, false, 530, "none"));
                            }
                        }
                        CommandExecued = true;
                        break;
                }
                if (!CommandExecued)
                {
                    if (!_isAuthenticated)
                    {
                        SendMessage("530 Access Denied! Authenticate first");
                        return;
                    }
                    switch (Command.ToUpper())
                    {
                        case "CWD":
                            _activecommand = true;
                            CWD(CmdArguments);
                            break;

                        case "CDUP":
                            _activecommand = true;
                            string[] pathParts = _currentDir.Split('/');
                            if (pathParts.Length > 1)
                            {
                                _currentDir = "";
                                for (int i = 0; i < (pathParts.Length - 2); i++) _currentDir += pathParts[i] + "/";
                                if (_currentDir.Length == 0) _currentDir = "/";
                            }
                            SendMessage("250 CDUP command successful.");
                            break;

                        case "QUIT":
                            _activecommand = true;
                            SendMessage("221 FTP server signing off");
                            Disconnect();
                            break;

                        case "PWD":
                            _activecommand = true;
                            SendMessage("257 \"" + _currentDir + "\"");
                            break;

                        case "PORT":
                            _activecommand = true;
                            PORT(CmdArguments); //done
                            break;

                        case "PASV":
                            _activecommand = true;
                            PASV(CmdArguments); //done
                            break;

                        case "TYPE":
                            _activecommand = true;
                            TYPE(CmdArguments); //done
                            break;

                        case "SYST":
                            _activecommand = true;
                            SendMessage("215 Windows_NT");
                            break;

                        case "NOOP":
                            _activecommand = true;
                            SendMessage("200 OK");
                            break;

                        case "RETR":
                            _activecommand = true;
                            RETR(CmdArguments);
                            break;

                        case "STOR":
                            _activecommand = true;
                            STOR(CmdArguments, false);
                            break;

                        case "APPE":
                            _activecommand = true;
                            APPE(CmdArguments);
                            break;

                        case "RNFR":
                            _activecommand = true;
                            RNFR(CmdArguments);
                            break;

                        case "RNTO":
                            _activecommand = true;
                            RNTO(CmdArguments);
                            break;
                        case "DELE":
                            _activecommand = true;
                            DELE(CmdArguments);
                            break;

                        case "RMD":
                            _activecommand = true;
                            RMD(CmdArguments);
                            break;

                        case "MKD":
                            _activecommand = true;
                            MKD(CmdArguments);
                            break;

                        case "LIST":
                            _activecommand = true;
                            LIST(_currentDir);
                            break;

                        case "NLST":
                            _activecommand = true;
                            NLST(CmdArguments);
                            break;

                        /*case "CLNT":
                            break;*/
                        case "MDTM":
                            _activecommand = true;
                            MDTM(CmdArguments);
                            break;

                        case "SIZE":
                            _activecommand = true;
                            SIZE(CmdArguments);
                            break;

                        case "OPTS":
                            _activecommand = true;
                            OPTS(CmdArguments);
                            break;

                        case "REIN":
                            _activecommand = true;
                            REIN(CmdArguments);
                            break;

                        case "STOU":
                            _activecommand = true;
                            STOR(CmdArguments, true);
                            break;

                        case "ABOR":
                        case "SHUTDOWN":
                            if (_datasocket != null && _datasocket.Connected) _datasocket.Close();
                            _datasocket = null;
                            GC.Collect();
                            SendMessage("200 Data transfer aborted");
                            _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.Abort, _connuser, true, 200));
                            break;

                        case "FEAT":
                            SendMessage("  SIZE");
                            SendMessage("  MTDM");
                            SendMessage("211 Feature list end");
                            _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.FeatureList, _connuser, true, 211));
                            break;

                        default:
                            SendMessage("500 Unknown Command.");
                            _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.UnknownCommand, _connuser, true, 500, Command, CmdArguments));
                            break;

                            //	case "STAT":
                            //		break;

                            //	case "HELP":
                            //		break;

                            //	case "REST":
                            //		break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Disconnect();
            }
        }

        #region CWD
        private void CWD(string CmdArguments)
        {
            string navpath;
            bool full = Fullpath(CmdArguments);
            if (full) navpath = CmdArguments;
            else navpath = _currentDir + "/" + CmdArguments;

            if (navpath.Contains(".."))
            {
                string[] parts = _currentDir.Split('/');
                StringBuilder sb = new StringBuilder();
                sb.Append('/');
                for (int i = 0; i < parts.Length - 1; i++)
                {
                    sb.Append(parts[i]);
                    sb.Append('/');
                }
                _currentDir = sb.ToString();
                _currentDir = HelperFunctions.FixPath(_currentDir);
                SendMessage("250 CWD command successful.");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.ChangeWorkDir, _connuser, true, 250, _currentDir));
            }
            else
            {
                if (DirectoryExists(navpath))
                {
                    if (full) _currentDir = navpath;
                    else
                    {
                        _currentDir += "/" + CmdArguments;
                        _currentDir = HelperFunctions.FixPath(_currentDir);
                    }
                    SendMessage("250 CWD command successful.");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.ChangeWorkDir, _connuser, true, 250, _currentDir));
                }
                else
                {
                    SendMessage("550 System can't find directory.");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.ChangeWorkDir, _connuser, false, 250, _currentDir));
                }

            }

        }
        #endregion

        #region Type
        private void TYPE(string CmdArguments)
        {
            if ((CmdArguments = CmdArguments.Trim().ToUpper()) == "A" || CmdArguments == "I")
            {
                SendMessage("200 Type " + CmdArguments + " Accepted.");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.ChangeType, _connuser, true, 200, CmdArguments));
            }
            else
            {
                SendMessage("500 Unknown Type.");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.ChangeType, _connuser, false, 200, CmdArguments));
            }
        }
        #endregion

        #region PORT
        private void PORT(string CmdArguments)
        {
            string[] IP_Parts = CmdArguments.Split(',');
            if (IP_Parts.Length != 6)
            {
                SendMessage("550 Invalid arguments.");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.PortCommand, _connuser, false, 550, "Invalid arguments", CmdArguments));
                return;
            }

            string ClientIP = IP_Parts[0] + "." + IP_Parts[1] + "." + IP_Parts[2] + "." + IP_Parts[3];
            int tmpPort = (Convert.ToInt32(IP_Parts[4]) << 8) | Convert.ToInt32(IP_Parts[5]);

            IPAddress[] client = Dns.GetHostEntry(ClientIP).AddressList;
            ClientEndPoints = new IPEndPoint[client.Length];
            for (int i = 0; i < client.Length; i++)
            {
                ClientEndPoints[i] = new IPEndPoint(client[i], tmpPort);
            }
            DataTransferEnabled = false;

            SendMessage("200 Ready to connect to " + ClientIP + "");
            _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.PortCommand, _connuser, true, 200, CmdArguments));
        }
        #endregion

        #region PASV
        private void PASV(string CmdArguments)
        {
            // Open listener within the specified port range
            int tmpPort = _server.PassivePortMinimum;
            StartListener:
            if (DataListener != null) { DataListener.Stop(); DataListener = null; }
            try
            {
                DataListener = new TcpListener(IPAddress.Any, tmpPort);
                DataListener.Start();
            }
            catch
            {
                if (tmpPort < _server.PassivePortMaximum)
                {
                    tmpPort++;
                    goto StartListener;
                }
                else
                {
                    SendMessage("500 Action Failed Retry");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.PassiveMode, _connuser, false, 500));
                    return;
                }
            }

            //string tmpEndPoint = DataListener.LocalEndpoint.ToString();
            //tmpPort = Convert.ToInt32(tmpEndPoint.Substring(tmpEndPoint.IndexOf(':') + 1));

            string SocketEndPoint = _clientSocket.LocalEndPoint.ToString();

            SocketEndPoint = SocketEndPoint.Substring(0, SocketEndPoint.IndexOf(":")).Replace(".", ",") + "," + (tmpPort >> 8) + "," + (tmpPort & 255);
            DataTransferEnabled = true;

            SendMessage("227 Entering Passive Mode (" + SocketEndPoint + ").");
            _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.PassiveMode, _connuser, true, 500, SocketEndPoint));
        }
        #endregion

        #region RETR
        private void RETR(string CmdArguments)
        {
            Stream fileStream;
            string navpath;
            bool full = Fullpath(CmdArguments);
            if (full) navpath = CmdArguments;
            else navpath = _currentDir + "/" + CmdArguments;

            string __备份路径 = null;

            string file = GetExactPath(navpath);
            try
            {
                try
                {
                    fileStream = File.OpenRead(file);
                }
                catch (Exception)
                {
                    var __源文件 = file;
                    __备份路径 = file + Guid.NewGuid();
                    File.Copy(__源文件, __备份路径, true);
                    fileStream = File.OpenRead(__备份路径);
                }
            }
            catch
            {
                SendMessage("550 Access denied or directory dosen't exist !");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.DownloadFile, _connuser, false, 550, file, "Access denied or directory dosen't exist"));
                return;
            }

            _datasocket = this.GetDataSocket();
            if (_datasocket == null) return;

            try
            {
                if (fileStream != null)
                {
                    SendMessage("250 Transfer started");
                    // ToDo: bandwidth limiting here
                    int readed = 1;
                    int cnt = 0;

                    if (_server.DownloadSpeedLimit > 0)
                    {
                        while (readed > 0)
                        {
                            byte[] data = new byte[10000];
                            readed = fileStream.Read(data, 0, data.Length);
                            cnt += readed;
                            _datasocket.Send(data, readed, SocketFlags.None);
                            if (cnt >= _server.DownloadSpeedLimit)
                            {
                                Thread.Sleep(1000);
                                cnt = 0;
                            }
                        }
                    }
                    else
                    {
                        while (readed > 0)
                        {
                            byte[] data = new byte[10000];
                            readed = fileStream.Read(data, 0, data.Length);
                            cnt += readed;
                            _datasocket.Send(data, readed, SocketFlags.None);
                        }
                    }
                }
                else
                {

                }

                _datasocket.Shutdown(SocketShutdown.Both);
                _datasocket.Close();
                _datasocket.Dispose();
                _datasocket = null;
                GC.Collect();

                SendMessage("226 Transfer Complete.");
                //SendMessage("200 OK");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.DownloadFile, _connuser, true, 226, file));
            }
            catch
            {
                SendMessage("426 Connection closed; transfer aborted.");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.DownloadFile, _connuser, false, 426, file, "Transfer aborted"));
            }

            if (fileStream != null) fileStream.Close();

            if (__备份路径 != null)
            {
                File.Delete(__备份路径);
            }
        }
        #endregion

        #region STOR
        private void STOR(string CmdArguments, bool unique)
        {
            if (_currentperms.Upload)
            {
                Stream fileStream;
                string file = null;
                try
                {
                    string name;
                    if (unique)
                    {
                        name = HelperFunctions.GenerateUniqueFileName();
                        file = GetExactPath(_currentDir + "/" + name);
                    }
                    else
                    {
                        name = CmdArguments;
                        file = GetExactPath(_currentDir + "/" + name);
                    }

                    if (File.Exists(file)) File.Delete(file);
                    fileStream = File.OpenWrite(file);
                    if (unique) SendMessage("250 " + name);
                    else SendMessage("250 Transfer started");
                }
                catch
                {
                    SendMessage("550 Access denied or directory dosen't exist !");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.UploadFile, _connuser, false, 550, file, "Access denied or directory dosen't exist"));
                    return;
                }

                _datasocket = GetDataSocket();
                if (_datasocket == null) return;
                try
                {
                    if (fileStream != null)
                    {
                        // ToDo: bandwidth limiting here

                        int readed = 1;
                        int cnt = 0;

                        if (_server.UploadSpeedLimit > 0)
                        {

                            while (readed > 0)
                            {
                                byte[] data = new byte[10000];
                                readed = _datasocket.Receive(data);
                                cnt += readed;
                                fileStream.Write(data, 0, readed);
                                if (cnt > _server.UploadSpeedLimit)
                                {
                                    Thread.Sleep(1000);
                                    cnt = 0;
                                }
                            }
                        }
                        else
                        {
                            while (readed > 0)
                            {
                                byte[] data = new byte[10000];
                                readed = _datasocket.Receive(data);
                                fileStream.Write(data, 0, readed);
                            }
                        }
                    }

                    _datasocket.Shutdown(SocketShutdown.Both);
                    _datasocket.Close();
                    _datasocket = null;
                    GC.Collect();
                    SendMessage("226 Transfer Complete.");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.UploadFile, _connuser, true, 226, file));
                }
                catch
                {
                    SendMessage("426 Connection closed; transfer aborted.");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.UploadFile, _connuser, false, 426, file, "Transfer aborted"));
                }

                fileStream.Close();
            }
            else
            {
                SendMessage("550 Access denied");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.UploadFile, _connuser, false, 550, "Acces Denied"));
            }
        }
        #endregion

        #region DELE
        private void DELE(string CmdArguments)
        {
            if (_currentperms.Delete)
            {
                string navpath;
                bool full = Fullpath(CmdArguments);
                if (full) navpath = CmdArguments;
                else navpath = _currentDir + "/" + CmdArguments;

                string file = GetExactPath(navpath);

                try
                {
                    File.Delete(file);
                    SendMessage("250 file deleted.");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.DeleteFile, _connuser, true, 250, file));
                }
                catch
                {
                    SendMessage("550 file delete failed");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.DeleteFile, _connuser, false, 550, file, "Delete failed"));
                }
            }
            else
            {
                SendMessage("550 Acces Denied");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.DeleteFile, _connuser, false, 550, "Acces Denied"));
            }
        }
        #endregion

        #region APPE
        private void APPE(string CmdArguments)
        {
            string navpath;
            bool full = Fullpath(CmdArguments);
            if (full) navpath = CmdArguments;
            else navpath = _currentDir + "/" + CmdArguments;

            string file = GetExactPath(navpath);
            if (_currentperms.Upload)
            {
                Stream fileStream;
                try
                {
                    fileStream = File.Open(file, FileMode.Append);
                }
                catch
                {
                    SendMessage("550 File Upload error");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.AppendFile, _connuser, false, 550, file, "File Upload error"));
                    return;
                }

                _datasocket = GetDataSocket();
                if (_datasocket == null) return;
                try
                {
                    // ToDo: bandwidth limiting here

                    int readed = 1;
                    while (readed > 0)
                    {
                        byte[] data = new byte[10000];
                        readed = _datasocket.Receive(data);
                        fileStream.Write(data, 0, readed);
                    }

                    _datasocket.Shutdown(SocketShutdown.Both);
                    _datasocket.Close();
                    _datasocket = null;
                    GC.Collect();
                    SendMessage("226 Transfer Complete.");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.AppendFile, _connuser, true, 226, file));
                }
                catch
                {
                    SendMessage("426 Connection closed; transfer aborted.");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.AppendFile, _connuser, false, 426, file, "Transfer aborted"));
                }

                fileStream.Close();

            }
            else
            {
                SendMessage("550 Access denied");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.AppendFile, _connuser, false, 550, "Access denied"));
            }

        }
        #endregion

        #region RNFR
        private void RNFR(string CmdArguments)
        {
            string navpath;
            bool full = Fullpath(CmdArguments);
            if (full) navpath = CmdArguments;
            else navpath = _currentDir + "/" + CmdArguments;

            string dir = GetExactPath(navpath);
            if (DirectoryExists(dir) || FileExists(dir))
            {
                SendMessage("350 Please specify destination name.");
                _renamefrom = dir;
            }
            else SendMessage("550 File or directory doesn't exist.");
        }
        #endregion

        #region RNTO
        private void RNTO(string CmdArguments)
        {
            if (_currentperms.Rename)
            {
                string navpath;
                bool full = Fullpath(CmdArguments);
                if (full) navpath = CmdArguments;
                else navpath = _currentDir + "/" + CmdArguments;

                if (string.IsNullOrEmpty(_renamefrom))
                {
                    SendMessage("503 Bad sequence of commands.");
                    return;
                }
                string dir = GetExactPath(navpath);

                try
                {
                    if (File.Exists(_renamefrom))
                    {
                        File.Move(_renamefrom, dir);
                        SendMessage("250 File renamed");
                        _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.Rename, _connuser, true, 250, _renamefrom, dir));

                    }
                    else if (Directory.Exists(_renamefrom))
                    {
                        Directory.Move(_renamefrom, dir);
                        SendMessage("250 Directory renamed");
                        _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.Rename, _connuser, true, 250, _renamefrom, dir));
                    }
                    else
                    {
                        SendMessage("550 Error renaming file or directory");
                        _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.Rename, _connuser, false, 550, _renamefrom, dir));
                    }
                }
                catch
                {
                    SendMessage("550 Error renaming file or directory");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.Rename, _connuser, false, 550, _renamefrom, dir));
                }
            }
            else
            {
                SendMessage("550 Acces denied");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.Rename, _connuser, false, 550, "Acces denied"));
            }

        }
        #endregion

        #region RMD
        private void RMD(string CmdArguments)
        {
            if (_currentperms.Delete)
            {
                string navpath;
                bool full = Fullpath(CmdArguments);
                if (full) navpath = CmdArguments;
                else navpath = _currentDir + "/" + CmdArguments;

                string dir = GetExactPath(navpath);
                try
                {
                    if (DirectoryExists(CmdArguments))
                    {
                        Directory.Delete(dir);
                        SendMessage("250 \"" + dir + "\" directory deleted");
                        _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.DeleteDirectory, _connuser, true, 250, dir));
                    }
                    else
                    {
                        SendMessage("550 Directory deletion failed.");
                        _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.DeleteDirectory, _connuser, false, 550, dir));
                    }
                }
                catch
                {
                    SendMessage("550 Directory deletion failed.");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.DeleteDirectory, _connuser, false, 550, dir));
                }
            }
            else
            {
                SendMessage("550 Acces denied");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.DeleteDirectory, _connuser, false, 550, "Acces denied"));
            }
        }
        #endregion

        #region MKD
        private void MKD(string CmdArguments)
        {
            if (_currentperms.Upload)
            {
                string navpath;
                bool full = Fullpath(CmdArguments);
                if (full) navpath = CmdArguments;
                else navpath = _currentDir + "/" + CmdArguments;

                string dir = GetExactPath(navpath);

                try
                {
                    Directory.CreateDirectory(dir);
                    SendMessage("257 \"" + dir + "\" directory created.");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.MakeDirectory, _connuser, true, 257, dir));
                }
                catch
                {
                    SendMessage("550 Directory creation failed.");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.MakeDirectory, _connuser, false, 550, dir));
                }
            }
            else
            {
                SendMessage("550 Acces denied");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.MakeDirectory, _connuser, false, 550, "Acces denied"));
            }
        }
        #endregion

        #region LIST
        private void LIST(string CmdArguments)
        {
            List<FTPListItem> items = ListDir(CmdArguments);
            _datasocket = GetDataSocket();
            if (_datasocket == null) return;

            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (FTPListItem itm in items)
                {
                    sb.Append(itm);

                }
                _datasocket.Send(_utf8 ? Encoding.UTF8.GetBytes(sb.ToString()) : Encoding.Default.GetBytes(sb.ToString()));
                SendMessage("226 Transfer Complete.");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.ListDirectory, _connuser, true, 226, _currentDir));
                _datasocket.Shutdown(SocketShutdown.Both);
                _datasocket.Close();
                _datasocket = null;
                GC.Collect();
            }
            catch
            {
                SendMessage("426 Connection closed; transfer aborted.");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.ListDirectory, _connuser, false, 426, _currentDir, "Transfer aborted"));
            }
        }
        #endregion

        #region NLST
        private void NLST(string CmdArguments)
        {
            List<FTPListItem> items = ListDir(GetExactPath(CmdArguments));
            _datasocket = GetDataSocket();
            if (_datasocket == null) return;

            try
            {

                foreach (FTPListItem itm in items)
                {
                    _datasocket.Send(_utf8 ? Encoding.UTF8.GetBytes(itm.Name) : Encoding.Default.GetBytes(itm.Name));
                }
                _datasocket.Shutdown(SocketShutdown.Both);
                _datasocket.Close();
                _datasocket = null;
                GC.Collect();

                SendMessage("226 Transfer Complete.");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.ListFileNames, _connuser, true, 226, _currentDir));
            }
            catch
            {
                SendMessage("426 Connection closed; transfer aborted.");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.ListFileNames, _connuser, false, 426, _currentDir, "Transfer aborted"));
            }
        }
        #endregion

        #region SIZE
        private void SIZE(string CmdArguments)
        {
            string navpath;
            bool full = Fullpath(CmdArguments);
            if (full) navpath = CmdArguments;
            else navpath = _currentDir + "/" + CmdArguments;

            try
            {
                FileInfo fi = new FileInfo(GetExactPath(_currentDir + "/" + CmdArguments));
                string resp = fi.Length.ToString();
                SendMessage("213 " + resp);
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.FileSize, _connuser, true, 250, navpath));
            }
            catch
            {
                SendMessage("550 File not found");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.FileSize, _connuser, false, 550, navpath));
            }
        }
        #endregion

        #region MTDM
        private void MDTM(string CmdArguments)
        {
            string navpath;
            bool full = Fullpath(CmdArguments);
            if (full) navpath = CmdArguments;
            else navpath = _currentDir + "/" + CmdArguments;

            try
            {
                FileInfo fi = new FileInfo(GetExactPath(navpath));
                string resp = fi.LastWriteTime.ToString("yyyyMMddHHmmss", new CultureInfo("en-US"));
                SendMessage("250 " + resp);
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.FileModificationDate, _connuser, true, 250, navpath));
            }
            catch
            {
                SendMessage("550 File not found");
                _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.FileModificationDate, _connuser, false, 550, navpath));
            }
        }
        #endregion

        #region OPTS
        private void OPTS(string CmdArguments)
        {
            string option = CmdArguments.ToUpper();
            switch (option)
            {
                case "UTF8 ON":
                    _utf8 = true;
                    SendMessage("200 UTF-8 Enabled");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.OptionReceived, _connuser, true, 200, option));
                    break;
                case "UTF8 OFF":
                    _utf8 = false;
                    SendMessage("200 UTF-8 Disabled");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.OptionReceived, _connuser, true, 200, option));
                    break;
                default:
                    SendMessage("504 Unrecognised option");
                    _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.OptionReceived, _connuser, false, 200, option));
                    break;
            }
        }
        #endregion

        #region REIN
        private void REIN(string CmdArguments)
        {
            _connuser = null;
            _isAuthenticated = false;
            _currentperms.Reset();
            SendMessage("200 Connection reinitialized");
            _server.Call_Log(new FTPLogEventArgs(FTPLogEventType.ConnectionReinitialize, _connuser, true, 200));
        }
        #endregion

        #region Helper Functions
        private string GetExactPath(string path)
        {
            if (path == null) path = "";
            if (!path.StartsWith("/")) path = "/" + path;
            if (!_isLinux)
            {
                string local = _localpath + path.Replace("/", "\\");
                local = local.Replace("\\\\", "\\");
                return local;
            }
            else
            {
                string local = _localpath + path.Replace("\\", "/");
                return local;
            }
        }

        private void SendMessage(string Data)
        {
            if (string.IsNullOrEmpty(Data)) return;
            try
            {
                if (!Data.EndsWith("\r\n")) Data += "\r\n";
                byte[] rawdata = _utf8 ? Encoding.UTF8.GetBytes(Data) : Encoding.Default.GetBytes(Data);
                _clientSocket.Send(rawdata);
            }
            catch { Disconnect(); }
        }

        private bool DirectoryExists(string path)
        {
            return Directory.Exists(GetExactPath(path));
        }

        private bool FileExists(string path)
        {
            return File.Exists(GetExactPath(path));
        }

        private Socket GetDataSocket()
        {
            Socket DataSocket;
            try
            {
                if (DataTransferEnabled)
                {
                    int Count = 0;
                    while (!DataListener.Pending())
                    {
                        Thread.Sleep(1000);
                        Count++;
                        // Time out after 30 seconds
                        if (Count > 29)
                        {
                            SendMessage("425 Data Connection Timed out");
                            return null;
                        }
                    }

                    DataSocket = DataListener.AcceptSocket();
                    SendMessage("125 Connected, Starting Data Transfer.");
                }
                else
                {
                    SendMessage("150 Connecting.\r\n");
                    DataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    bool suces = false;
                    for (int i = 0; i < ClientEndPoints.Length; i++)
                    {
                        try
                        {
                            DataSocket.Connect(ClientEndPoints[i]);
                            suces = true;
                            SendMessage("125 Connected, Starting Data Transfer.");
                            break;
                        }
                        catch { }
                    }
                    if (!suces) throw new Exception();
                }
            }
            catch
            {
                SendMessage("425 Can't open data connection.");
                return null;
            }
            finally
            {
                if (DataListener != null)
                {
                    DataListener.Stop();
                    DataListener = null;
                    GC.Collect();
                }
            }

            DataTransferEnabled = false;

            return DataSocket;
        }

        private List<FTPListItem> ListDir(string path)
        {
            List<FTPListItem> ret = new List<FTPListItem>();
            string[] dirs = Directory.GetDirectories(GetExactPath(path));
            string[] files = Directory.GetFiles(GetExactPath(path));
            FTPListItem tmp;

            foreach (string dir in dirs)
            {
                var di = new DirectoryInfo(dir);
                if ((((di.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) ||
                     ((di.Attributes & FileAttributes.System) == FileAttributes.System)) &&
                    !_currentperms.ListHidden)
                {
                    continue;
                }
                tmp = new FTPListItem(dir)
                {
                    IsDir = true,
                    Date = di.LastWriteTime
                };
                ret.Add(tmp);
            }

            foreach (string file in files)
            {
                var fi = new FileInfo(file);
                if ((((fi.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) ||
                     ((fi.Attributes & FileAttributes.System) == FileAttributes.System)) &&
                    !_currentperms.ListHidden)
                {
                    continue;
                }
                tmp = new FTPListItem(file)
                {
                    IsDir = false,
                    Date = fi.LastWriteTime,
                    Size = fi.Length
                };
                ret.Add(tmp);
            }
            return ret;
        }

        private bool Fullpath(string path)
        {
            if (path.Split('/').Length > 1) return true;
            else return false;
        }
        #endregion
    }

    /// <summary>
    /// A User management class
    /// </summary>
    public class UserManager
    {
        private List<FTPUser> _users;

        /// <summary>
        /// Creates a new instance of UserManager
        /// </summary>
        public UserManager()
        {
            _users = new List<FTPUser>();
        }

        /// <summary>
        /// Adds a user to the management system
        /// </summary>
        /// <param name="user">The user to be added</param>
        public void AddUser(FTPUser user)
        {
            _users.Add(user);
        }

        /// <summary>
        /// Removes a user from the management system
        /// </summary>
        /// <param name="user">The user to be removed</param>
        public void RemoveUser(FTPUser user)
        {
            _users.Remove(user);
        }

        /// <summary>
        /// Removes a user from the management system by the user's name
        /// </summary>
        /// <param name="name">The name of the user to be removed</param>
        public void RemoveUserbyName(string name)
        {
            var q = (from user in _users where user.Name == name select user).ToList();
            foreach (FTPUser u in q) _users.Remove(u);
        }

        /// <summary>
        /// Returns a user based on it's name
        /// </summary>
        /// <param name="name">The name of the user to get</param>
        /// <returns></returns>
        public FTPUser this[string name]
        {
            get
            {
                var q = from user in _users where user.Name == name select user;
                return q.FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets the permissions associated to the user by the user's name
        /// </summary>
        /// <param name="name">the name of the user</param>
        /// <returns></returns>
        public FTPUserPermission GetPermissions(string name)
        {
            var q = from user in _users where user.Name == name select user.Permissions;
            return q.FirstOrDefault();
        }

        /// <summary>
        /// Gets the number of users in the management system
        /// </summary>
        public int Count
        {
            get
            {
                return _users.Count;
            }
        }

        /// <summary>
        /// serializes users to stream
        /// </summary>
        /// <param name="Target"></param>
        public void Serialize(Stream Target)
        {
            XmlSerializer xs = new XmlSerializer(typeof(FTPUser[]));
            xs.Serialize(Target, _users.ToArray());
        }

        /// <summary>
        /// Deserializes users from stream
        /// </summary>
        /// <param name="Source"></param>
        public void Deserialize(Stream Source)
        {
            XmlSerializer xs = new XmlSerializer(typeof(FTPUser[]));
            _users.AddRange((FTPUser[])xs.Deserialize(Source));
        }

        /// <summary>
        /// gets the user names
        /// </summary>
        public string[] UserNames
        {
            get
            {
                return (from user in _users select user.Name).ToArray();
            }
        }
    }

    /// <summary>
    /// Event Type Enumeration
    /// </summary>
    public enum FTPLogEventType
    {
        /// <summary>
        /// Occures when a user trys to connect to the server
        /// </summary>
        UserConnect,

        /// <summary>
        /// Occures when a user disconects from the server
        /// </summary>
        UserDisconnect,

        /// <summary>
        /// Occures when a cwd command recived
        /// </summary>
        ChangeWorkDir,

        /// <summary>
        /// Occures when a dele command recived
        /// </summary>
        DeleteFile,

        /// <summary>
        /// Occures when a list command is recived
        /// </summary>
        ListDirectory,

        /// <summary>
        /// Occures when a mkd command is recived
        /// </summary>
        MakeDirectory,

        /// <summary>
        /// Occures when a nlst command is recived
        /// </summary>
        ListFileNames,

        /// <summary>
        /// Occures when a pasv command is recived
        /// </summary>
        PassiveMode,

        /// <summary>
        /// Occures when a port command is recived
        /// </summary>
        PortCommand,

        /// <summary>
        /// Occures when a retr command is recived
        /// </summary>
        DownloadFile,

        /// <summary>
        /// Occures when a rmd command is recived
        /// </summary>
        DeleteDirectory,

        /// <summary>
        /// Occures when a rnfr and rnto command pair is recived
        /// </summary>
        Rename,

        /// <summary>
        /// Occures wehen a stor coomand is recived
        /// </summary>
        UploadFile,

        /// <summary>
        /// Occures when a type command is recived
        /// </summary>
        ChangeType,

        /// <summary>
        /// Occures when an appe command is recived
        /// </summary>
        AppendFile,


        /// <summary>
        /// Occures when a size command is recived
        /// </summary>
        FileSize,

        /// <summary>
        /// Occures when a mtdm command is recived
        /// </summary>
        FileModificationDate,

        /// <summary>
        /// Occures when an opts command is recived
        /// </summary>
        OptionReceived,

        /// <summary>
        /// Occures when a rein command is recived
        /// </summary>
        ConnectionReinitialize,

        /// <summary>
        /// Occures when an abor commnad is recived
        /// </summary>
        Abort,

        /// <summary>
        /// Occures when a feat command is recived
        /// </summary>
        FeatureList,

        /// <summary>
        /// Occures when an unknown command is recived
        /// </summary>
        UnknownCommand
    }

    /// <summary>
    /// Log Event args
    /// </summary>
    public class FTPLogEventArgs : EventArgs
    {
        private DateTime _date;
        private FTPLogEventType _type;
        private bool _eventsucces;
        private string[] _arguments;
        private int _responsecode;
        private string _user;

        /// <summary>
        /// Creates a new instance of LogEventArgs
        /// </summary>
        /// <param name="EventType">The Type of the event</param>
        /// <param name="User">Current FTP User</param>
        /// <param name="Succes">Completed succesfully or not</param>
        /// <param name="Response">Server Response code</param>
        /// <param name="arguments">Event specific arguments</param>
        public FTPLogEventArgs(FTPLogEventType EventType, string User, bool Succes, int Response, params string[] arguments)
        {
            _date = DateTime.Now;
            _type = EventType;
            _eventsucces = Succes;
            _arguments = arguments;
            _responsecode = Response;
            _user = User;
        }

        /// <summary>
        /// The Date and Time of the event
        /// </summary>
        public DateTime EventDate
        {
            get { return _date; }
        }

        /// <summary>
        /// Gets if the Event raising command completed succesfully or not
        /// </summary>
        public bool Succes
        {
            get { return _eventsucces; }
        }

        /// <summary>
        /// Gets the user associated to the event
        /// </summary>
        public string User
        {
            get { return _user; }
        }

        /// <summary>
        /// Event type
        /// </summary>
        public FTPLogEventType EventType
        {
            get { return _type; }
        }

        /// <summary>
        /// Event Arguments related to the event type
        /// </summary>
        public string[] arguments
        {
            get { return _arguments; }
        }

        /// <summary>
        /// Gets the server Response code for the event
        /// </summary>
        public int Response
        {
            get { return _responsecode; }
        }

        /// <summary>
        /// Gets a specific event argument
        /// </summary>
        /// <param name="index">the index of the event argument to get</param>
        /// <returns>The the specific event argument</returns>
        public string this[int index]
        {
            get { return _arguments[index]; }
        }

        /// <summary>
        /// Gets the count of the event arguments
        /// </summary>
        public int Length
        {
            get { return _arguments.Length; }
        }

        public override string ToString()
        {
            var __sb = new System.Text.StringBuilder();
            __sb.Append(EventDate.ToShortTimeString()).Append("\t");
            __sb.Append(EventType.ToString()).Append("\t");
            __sb.Append(Succes.ToString()).Append("\t");
            __sb.Append(User).Append("\t");

            foreach (string arg in arguments)
            {
                __sb.Append(arg);
                __sb.Append(", ");
            }

            return __sb.ToString();
        }
    }

    public delegate void FTPLogEventHandler(object sender, FTPLogEventArgs e);
    internal static class HelperFunctions
    {
        public static string FixPath(string path)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("/");
            string[] p = path.Split('/');
            for (int i = 0; i < p.Length; i++)
            {
                if (!string.IsNullOrEmpty(p[i]))
                {
                    sb.Append(p[i]);
                    if (i != p.Length - 1) sb.Append("/");
                }
            }
            return sb.ToString();

        }

        public static string SHA1Hash(string source)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] data = Encoding.UTF8.GetBytes(source);
            byte[] hash = sha1.ComputeHash(data);
            StringBuilder sb = new StringBuilder(50);
            for (int i = 0; i < hash.Length; i++) sb.Append(hash[i].ToString("x2").ToLower());
            return sb.ToString(); ;
        }

        public static string GenerateUniqueFileName()
        {
            RNGCryptoServiceProvider rgn = new RNGCryptoServiceProvider();
            byte[] data = new byte[16];
            rgn.GetBytes(data);
            Guid name = new Guid(data);
            return name.ToString();
        }
    }

}