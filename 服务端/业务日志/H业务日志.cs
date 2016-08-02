using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Utility.存储;

namespace 系统管理.服务端
{
    static class H业务日志
    {
        static List<M业务日志> _缓存 = new List<M业务日志>();

        public static int 缓存上限 = 1000;

        static H业务日志()
        {
            if (!Directory.Exists(H路径.获取绝对路径("日志")))
            {
                Directory.CreateDirectory(H路径.获取绝对路径("日志"));
            }
        }

        public static void 记录(string __类别, string __描述)
        {
            var __文件 = H路径.获取绝对路径(string.Format("日志{1}业务日志 {0}.txt", DateTime.Now.Date.ToString("yyyy-MM-dd"), Program.IsWindows ? "\\" : "/"));
            File.AppendAllText(__文件, string.Format("{0} || {1} || {2}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), __类别, __描述), Encoding.UTF8);
            _缓存.Add(new M业务日志 { 时间 = DateTime.Now, 描述 = __描述, 类别 = __类别 });
            if (_缓存.Count > 缓存上限)
            {
                _缓存.RemoveAt(0);
            }
        }

        //public static void 记录开发日志(string __类别, string __描述, TraceEventType __级别 = TraceEventType.Information)
        //{
        //    var __文件 = H路径.获取绝对路径(string.Format("日志{1}开发日志 {0}.txt", DateTime.Now.Date.ToString("yyyy-MM-dd"), Program.IsWindows ? "\\" : "/"));
        //    File.AppendAllText(__文件, string.Format("{0} || {1} || {2} || {3}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), __级别, __类别, __描述), Encoding.UTF8);
        //}

        public static List<M业务日志> 查询缓存()
        {
            return _缓存;
        }
    }

}
