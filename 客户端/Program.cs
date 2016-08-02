using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Utility.WindowsForm;
using Utility.扩展;
using Utility.通用;
using 通用访问;

namespace 系统管理.客户端
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            H调试.初始化();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new F主窗口());
        }
    }
}
