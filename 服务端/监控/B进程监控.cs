using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.模式;
using Utility.通用;

namespace 系统管理.服务端
{
    class B进程监控
    {
        List<M进程状态> _上次存在进程 = new List<M进程状态>();

        Dictionary<string, string> _路径缓存 = new Dictionary<string, string>();

        Dictionary<string, PerformanceCounter> _计数器缓存 = new Dictionary<string, PerformanceCounter>();

        object _锁 = new object();

        Dictionary<string, H阈值告警<int>> _CPU阈值告警 = new Dictionary<string, H阈值告警<int>>();

        Dictionary<string, H阈值告警<int>> _内存阈值告警 = new Dictionary<string, H阈值告警<int>>();

        public M进程监控配置 配置 { get; set; }

        public B进程监控(M进程监控配置 __配置)
        {
            配置 = __配置;
            Task.Factory.StartNew(() =>
            {
                var __比较器 = new B比较器();
                while (true)
                {
                    lock (_锁)
                    {
                        if (配置.列表.Count == 0)
                        {
                            _上次存在进程.Clear();
                            continue;
                        }
                        var __本次存在进程 = new List<M进程状态>();
                        配置.列表.ForEach(k =>
                        {
                            var __进程列表 = Process.GetProcessesByName(k.进程名);
                            if (__进程列表 != null && __进程列表.Length > 0)
                            {
                                __进程列表.ToList().ForEach(q =>
                                    {
                                        try
                                        {
                                            var __标识 = string.Format("{0}-{1}", q.Id, q.ProcessName);
                                            var __路径 = "";
                                            if (_路径缓存.ContainsKey(__标识))
                                            {
                                                __路径 = _路径缓存[__标识];
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    __路径 = q.MainModule.FileName;
                                                }
                                                catch (Exception)
                                                {
                                                }
                                                _路径缓存[__标识] = __路径;
                                            }
                                            var __状态 = new M进程状态
                                            {
                                                Id = q.Id,
                                                名称 = q.ProcessName,
                                                描述 = k.描述,
                                                启动时间 = q.StartTime,
                                                路径 = __路径
                                            };
                                            __状态.内存 = 获取内存使用(__状态.Id, __状态.名称);
                                            __状态.线程数 = 获取线程数(__状态.Id, __状态.名称);
                                            __状态.CPU = 获取CPU使用率(__状态.Id, __状态.名称);
                                            __本次存在进程.Add(__状态);

                                            if (k.内存阈值.HasValue)
                                            {
                                                if (!_内存阈值告警.ContainsKey(__状态.名称))
                                                {
                                                    _内存阈值告警[__状态.名称] = new H阈值告警<int>(k.内存阈值.Value, (a, b) => a.CompareTo(b), (__告警, __缓存) =>
                                                    {
                                                        on阈值告警(string.Format("进程 {0} 内存{1}，明细：{2}", __状态.名称, __告警 ? "告警" : "告警解除", string.Join(",", __缓存)));
                                                    }, 10, 5);
                                                }
                                                _内存阈值告警[__状态.名称].阈值 = k.内存阈值.Value;
                                                _内存阈值告警[__状态.名称].添加((int)(__状态.内存 / 1024 / 1024));
                                            }                                            
                                            if (k.CPU阈值.HasValue)
                                            {
                                                if (!_CPU阈值告警.ContainsKey(__状态.名称))
                                                {
                                                    _CPU阈值告警[__状态.名称] = new H阈值告警<int>(k.CPU阈值.Value, (a, b) => a.CompareTo(b), (__告警, __缓存) =>
                                                    {
                                                        on阈值告警(string.Format("进程 {0} CPU{1}，明细：{2}", __状态.名称, __告警 ? "告警" : "告警解除", string.Join(",", __缓存)));
                                                    }, 10, 5);
                                                }
                                                _CPU阈值告警[__状态.名称].阈值 = k.CPU阈值.Value;
                                                _CPU阈值告警[__状态.名称].添加((int)(__状态.CPU));
                                            }
                                            q.Dispose();
                                        }
                                        catch (Exception ex)
                                        {
                                            H日志.记录异常(ex);
                                        }
                                    });
                            }
                        });

                        _上次存在进程.Except(__本次存在进程, __比较器).ToList().ForEach(q => on进程关闭(q.Id, q.名称));
                        __本次存在进程.Except(_上次存在进程, __比较器).ToList().ForEach(q =>
                        {
                            if (q.启动时间.AddSeconds(10) > DateTime.Now)
                            {
                                on进程开启(q.Id, q.名称, q.启动时间);
                            }
                        });
                        _上次存在进程 = __本次存在进程;
                    }
                    Thread.Sleep(配置.频率);
                }
            });
        }

        public List<M进程状态> 查询状态()
        {
            lock (_锁)
            {
                return _上次存在进程;
            }
        }

        public M进程监控配置 查询配置()
        {
            lock (_锁)
            {
                return 配置;
            }
        }

        public void 设置配置(M进程监控配置 __配置)
        {
            lock (_锁)
            {
                配置 = __配置;
            }
        }

        public event Action<int, string, DateTime> 进程开启;

        private void on进程开启(int __PID, string __进程名, DateTime __时间) { 进程开启?.Invoke(__PID, __进程名, __时间); }

        public event Action<int, string> 进程关闭;

        private void on进程关闭(int __PID, string __进程名) { 进程关闭?.Invoke(__PID, __进程名); }

        public event Action<string> 阈值告警;

        private void on阈值告警(string __描述) { 阈值告警?.Invoke(__描述); }

        class B比较器 : EqualityComparer<M进程状态>
        {
            public override bool Equals(M进程状态 b1, M进程状态 b2)
            {
                if (b1.Id == b2.Id & b1.名称 == b2.名称)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public override int GetHashCode(M进程状态 bx)
            {
                return string.Format("{0}-{1}", bx.Id, bx.名称).GetHashCode();
            }
        }

        private int 获取CPU使用率(int __id, string __进程名)
        {
            var __实例名 = Program.IsWindows ? __进程名 : string.Format("{0}/{1}", __id, __进程名);
            var __标识 = string.Format("cpu - {0}", __实例名);
            PerformanceCounter __计数器;
            if (_计数器缓存.ContainsKey(__标识))
            {
                __计数器 = _计数器缓存[__标识];
            }
            else
            {
                __计数器 = new PerformanceCounter("Process", "% Processor Time", __实例名);
                _计数器缓存[__标识] = __计数器;
            }
            return (int)(__计数器.NextValue() / Environment.ProcessorCount);
        }

        private int 获取内存使用(int __id, string __进程名)
        {
            var __实例名 = Program.IsWindows ? __进程名 : string.Format("{0}/{1}", __id, __进程名);
            var __标识 = string.Format("mem - {0}", __实例名);
            PerformanceCounter __计数器;
            if (_计数器缓存.ContainsKey(__标识))
            {
                __计数器 = _计数器缓存[__标识];
            }
            else
            {
                if (Program.IsWindows)
                {
                    __计数器 = new PerformanceCounter("Process", "Working Set - Private", __实例名);
                }
                else
                {
                    __计数器 = new PerformanceCounter("Process", "Working Set", __实例名);
                }
                _计数器缓存[__标识] = __计数器;
            }
            return (int)__计数器.NextValue();
        }

        private int 获取线程数(int __id, string __进程名)
        {
            var __实例名 = Program.IsWindows ? __进程名 : string.Format("{0}/{1}", __id, __进程名);
            var __标识 = string.Format("thread - {0}", __实例名);
            PerformanceCounter __计数器;
            if (_计数器缓存.ContainsKey(__标识))
            {
                __计数器 = _计数器缓存[__标识];
            }
            else
            {
                __计数器 = new PerformanceCounter("Process", "Thread Count", __实例名);
                _计数器缓存[__标识] = __计数器;
            }
            return (int)__计数器.NextValue();
        }
    }
}
