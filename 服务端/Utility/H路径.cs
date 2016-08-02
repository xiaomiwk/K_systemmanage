using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Utility.存储
{
    public static class H路径
    {
        private static readonly string _程序目录;

        public static string 程序目录 { get { return _程序目录; } }

        static H路径()
        {
            try
            {
                //Application.StartupPath
                _程序目录 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
            catch (NullReferenceException)//设计时异常
            {
                _程序目录 = Environment.CurrentDirectory;
            }
        }

        public static string 获取绝对路径(string 路径, bool 方法所在程序集 = false)
        {
            if (路径.Contains(':'))
            {
                return 路径;
            }
            var __相对路径 = 程序目录;
            if (方法所在程序集)
            {
                __相对路径 = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
            }
            return Path.Combine(__相对路径, 路径);
        }

        public static bool 验证目录是否存在(string 目录路径, bool 方法所在程序集 = false)
        {
            var __路径 = 获取绝对路径(目录路径, 方法所在程序集);
            return Directory.Exists(__路径);
        }

        public static bool 验证文件是否存在(string 文件路径, bool 方法所在程序集 = false)
        {
            var __路径 = 获取绝对路径(文件路径, 方法所在程序集);
            return File.Exists(__路径);
        }

        /// <summary>
        /// 如果文件已经存在,则覆盖
        /// </summary>
        /// <param name="文件路径"></param>
        public static FileStream 创建文件(string 文件路径)
        {
            if (!文件路径.Contains(':'))
            {
                文件路径 = Path.Combine(_程序目录, 文件路径);
                var __path = Path.GetDirectoryName(文件路径);
                if (!Directory.Exists(__path))
                {
                    Directory.CreateDirectory(__path);
                }
            }
            return new FileStream(文件路径, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        }

        public static FileStream 打开文件(string 文件路径, bool 方法所在程序集 = false)
        {
            文件路径 = 获取绝对路径(文件路径, 方法所在程序集);
            if (!验证文件是否存在(文件路径, 方法所在程序集))
            {
                return null;
            }
            return new FileStream(文件路径, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        }

    }
}
