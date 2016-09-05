using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.模式;
using Utility.通用;
using 通用访问;

namespace 系统管理.服务端
{
    class B资源监控
    {
        private static PerformanceCounter _CPU计数器 = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        private static PerformanceCounter _可用内存计数器;

        /// <summary>
        /// 单位MB
        /// </summary>
        public int 总内存 { get; set; }

        public M资源监控配置 配置 { get; set; }

        private M资源状态 _状态;

        H阈值告警<int> _CPU阈值告警;

        H阈值告警<int> _内存阈值告警;

        public B资源监控(M资源监控配置 __配置)
        {
            配置 = __配置;
            if (Program.IsWindows)
            {
                _可用内存计数器 = new PerformanceCounter("Memory", "Available MBytes");
                var __内存信息 = new MEMORYSTATUSEX();
                GlobalMemoryStatusEx(__内存信息);
                总内存 = (int)(__内存信息.ullTotalPhys / 1024 / 1024);
            }
            else
            {
                //var __内存计数器 = new PerformanceCounterCategory("Mono Memory");
                //foreach (var __计数器 in __内存计数器.GetCounters())
                //{
                //    Console.WriteLine(string.Format("CounterName:{0}; CounterType:{1}; CounterHelp:{2}; Value:{3}", __计数器.CounterName, __计数器.CounterType, __计数器.CounterHelp, __计数器.NextValue()));
                //}
                _可用内存计数器 = new PerformanceCounter("Mono Memory", "Available Physical Memory"); //通过free命令行，实际是free性质的内存，非Available性质的内存
                using (var __内存总数计数器 = new PerformanceCounter("Mono Memory", "Total Physical Memory"))
                {
                    总内存 = (int)(__内存总数计数器.NextValue() / 1024 / 1024);
                }
            }

            _状态 = new M资源状态();
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        var __CPU使用率 = 获取CPU使用率();
                        if (_CPU阈值告警 == null)
                        {
                            _CPU阈值告警 = new H阈值告警<int>(配置.CPU阈值, (a, b) => a.CompareTo(b), (__告警, __缓存) =>
                            {
                                _状态.CPU告警 = __告警;
                                on阈值告警(string.Format("CPU{0}，明细：{1}", __告警 ? "告警" : "告警解除", string.Join(",", __缓存)));
                            }, 10, 配置.阈值次数);
                        }
                        _CPU阈值告警.阈值 = 配置.CPU阈值;
                        _CPU阈值告警.告警判定次数 = 配置.阈值次数;
                        _CPU阈值告警.添加(__CPU使用率);
                        _状态.CPU使用率 = _CPU阈值告警.缓存;
                    }
                    catch (Exception ex)
                    {
                        H日志.记录异常(ex);
                    }
                    try
                    {
                        var __内存使用率 = 获取内存使用率();
                        if (_内存阈值告警 == null)
                        {
                            _内存阈值告警 = new H阈值告警<int>(配置.内存阈值, (a, b) => a.CompareTo(b), (__告警, __缓存) =>
                            {
                                _状态.内存告警 = __告警;
                                on阈值告警(string.Format("内存{0}，明细：{1}", __告警 ? "告警" : "告警解除", string.Join(",", __缓存)));
                            }, 10, 配置.阈值次数);
                        }
                        _内存阈值告警.阈值 = 配置.内存阈值;
                        _内存阈值告警.告警判定次数 = 配置.阈值次数;
                        _内存阈值告警.添加(__内存使用率);
                        _状态.内存使用率 = _内存阈值告警.缓存;
                    }
                    catch (Exception ex)
                    {
                        H日志.记录异常(ex);
                    }
                    Thread.Sleep(配置.频率);
                }
            });
        }

        public M资源状态 查询状态()
        {
            return _状态;
        }

        private int 获取CPU使用率()
        {
            return (int)(_CPU计数器.NextValue());
        }

        private int 获取内存使用率()
        {
            if (Program.IsWindows)
            {
                var __内存信息 = new MEMORYSTATUSEX();
                GlobalMemoryStatusEx(__内存信息);
                return (int)__内存信息.dwMemoryLoad;
            }
            else
            {
                #region 方案一，暂未成功
                //var __系统信息 = new sysinfo();
                //var __temp = Getsysinfo(__系统信息);
                //Console.WriteLine("结果" + __temp);
                //Console.WriteLine(HJSON.序列化(__系统信息));
                //return (int)(__系统信息.freeram * 100 / __系统信息.totalram);
                #endregion

                #region 方案二, 文件无法释放，too many files opened 
                //using (var __进程 = new Process())
                //{
                //    __进程.StartInfo.FileName = "sh";
                //    __进程.StartInfo.UseShellExecute = false;
                //    __进程.StartInfo.RedirectStandardInput = true;
                //    __进程.StartInfo.RedirectStandardOutput = true;
                //    //__进程.StartInfo.RedirectStandardError = true;
                //    __进程.StartInfo.CreateNoWindow = true;
                //    __进程.Start();
                //    __进程.StandardInput.WriteLine("free -m");
                //    __进程.StandardInput.WriteLine("exit");
                //    var __响应 = __进程.StandardOutput.ReadToEnd();
                //    __进程.StandardInput.Dispose();
                //    __进程.StandardOutput.Dispose();
                //    //Console.WriteLine(__响应);
                //    var __所有行 = __响应.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //    if (__所有行.Length > 2)
                //    {
                //        var __第二行所有列 = __所有行[1].Split(new string[] { "\t", " " }, StringSplitOptions.RemoveEmptyEntries);
                //        if (__第二行所有列.Length > 2)
                //        {
                //            return int.Parse(__第二行所有列[2]) * 100 / int.Parse(__第二行所有列[1]);
                //        }
                //    }
                //}
                #endregion

                return 100 - (int)(_可用内存计数器.NextValue() / 1024 / 1024 * 100 / 总内存);
            }
        }

        public event Action<string> 阈值告警;

        private void on阈值告警(string __描述) { 阈值告警?.Invoke(__描述); }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        class MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
            public MEMORYSTATUSEX()
            {
                this.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            }
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct sysinfo
        {
            public long uptime;          /* 启动到现在经过的时间 */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public ulong[] loads;
            /* 1, 5, and 15 minute load averages */
            public ulong totalram;  /* 总的可用的内存大小 */
            public ulong freeram;   /* 还未被使用的内存大小 */
            public ulong sharedram; /* 共享的存储器的大小*/
            public ulong bufferram; /* 共享的存储器的大小 */
            public ulong totalswap; /* 交换区大小 */
            public ulong freeswap;  /* 还可用的交换区大小 */
            public short procs;    /* 当前进程数目 */
            public ulong totalhigh; /* 总的高内存大小 */
            public ulong freehigh;  /* 可用的高内存大小 */
            public int mem_unit;   /* 以字节为单位的内存大小 */

            //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 0)]
            //public Byte[] padding;
                
            //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
            //public Byte[] padding;
        };

        [DllImport("libc", EntryPoint = "sysinfo", SetLastError = true)]
        static extern int Getsysinfo([In, Out] sysinfo info);

        [DllImport("libc", SetLastError = true)]
        static extern int open([MarshalAs(UnmanagedType.LPStr)]string pathname, int flags);
    }
}
