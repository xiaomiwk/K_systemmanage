using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace 系统管理.服务端
{
    class B进程管理
    {
        Dictionary<string, string> _路径缓存 = new Dictionary<string, string>();

        Dictionary<string, TimeSpan> _CPU时间缓存 = new Dictionary<string, TimeSpan>();

        DateTime _上次查询时间;

        List<M进程状态> _缓存 = null;

        public List<M进程状态> 查询所有()
        {
            DateTime __当前时间 = DateTime.Now;
            if (_缓存 != null && _上次查询时间.AddSeconds(2) > __当前时间 && _上次查询时间 < __当前时间)
            {
                return _缓存;
            }
            if (_上次查询时间.AddSeconds(8) < __当前时间 || _上次查询时间 > __当前时间)
            {
                _CPU时间缓存.Clear();
            }
            var __结果 = new List<M进程状态>();
            Process.GetProcesses().ToList().ForEach(q =>
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

                    int? __CPU = null;
                    if (!string.IsNullOrEmpty(__路径))
                    {
                        var __cpu时间 = q.TotalProcessorTime;
                        if (_CPU时间缓存.ContainsKey(__标识))
                        {
                            __CPU = (int)((__cpu时间 - _CPU时间缓存[__标识]).TotalMilliseconds * 100 / Environment.ProcessorCount / (__当前时间 - _上次查询时间).TotalMilliseconds);
                        }
                        _CPU时间缓存[__标识] = __cpu时间;
                    }
                    __结果.Add(new M进程状态
                    {
                        Id = q.Id,
                        名称 = q.ProcessName,
                        内存 = q.WorkingSet64,
                        CPU = __CPU,
                        路径 = __路径
                    });
                    q.Dispose();
                }
                catch (Exception)
                {
                }
            });
            __结果.Sort(new Comparison<M进程状态>((m, n) => m.名称.CompareTo(n.名称)));
            _上次查询时间 = __当前时间;
            _缓存 = __结果;
            return __结果;
        }

        public void 结束进程(int id)
        {
            Process.GetProcessById(id).Kill();
        }
    }
}
