using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Utility.存储;
using Utility.通用;
using 通用访问;
using 通用访问.DTO;

namespace 系统管理.服务端
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject == null) return;
                H日志.记录致命(e.ExceptionObject.ToString());
            };
            IsWindows = Environment.NewLine == "\r\n";

            if (!Environment.UserInteractive)
            {
                var ServicesToRun = new ServiceBase[] { new Service1() };
                ServiceBase.Run(ServicesToRun);
                return;
            }
            var __B控制器 = new B控制器();
            __B控制器.配置();
            __B控制器.开启();
            Console.WriteLine("开启成功,按回车键结束");
            Console.ReadLine();
            __B控制器.关闭();
        }


        public static bool IsWindows { get; private set; }
    }

}
