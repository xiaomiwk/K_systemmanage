using System;
using System.IO;
using System.Reflection;
using Utility.存储;
using Utility.扩展;
using Utility.通用;

namespace 系统管理.服务端
{
    public class BFTP
    {
        public bool 运行中 { get; set; }

        public int 端口号 { get; set; }

        public string 目录 { get; set; }

        private FTPServer _FTP;

        public void 开启(string __目录, int __端口号 = 2121)
        {
            端口号 = __端口号;
            目录 = string.IsNullOrEmpty(__目录) ? H路径.程序目录 : __目录;
            if (_FTP == null)
            {
                _FTP = new FTPServer
                {
                    DownloadSpeedLimit = -1,
                    UploadSpeedLimit = -1,
                    StartupDir = 目录,
                    //UTF8 = true,
                    Port = 端口号
                };
                //_FTP.OnLogEvent += (m, n) => H调试.记录(n.ToString());
                //_FTP.OnLogEvent += (m, n) => Console.WriteLine(n.ToString());
                //_FTP.AcceptedAdresses.Add(addr);
                //_FTP.BannedAdresses.Add(addr);

                try
                {
                    _FTP.Start();
                    if (!运行中)
                    {
                        运行中 = true;
                        on状态变化(运行中);
                    }
                }
                catch (Exception ex)
                {
                    H日志.记录异常(ex);
                    运行中 = false;
                }
            }
        }

        public void 关闭()
        {
            if (_FTP != null)
            {
                if (运行中)
                {
                    运行中 = false;
                    on状态变化(运行中);
                }
                _FTP.Stop();
                _FTP = null;
            }
        }

        public event Action<bool> 状态变化;

        public void on状态变化(bool __开启)
        {
            var temp = 状态变化;
            if (temp != null)
            {
                temp(__开启);
            }
        }
    }

}
