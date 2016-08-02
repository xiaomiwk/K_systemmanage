using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 系统管理.服务端
{
    public class B链路监控
    {
        private Dictionary<string, M链路状态> _缓存 = new Dictionary<string, M链路状态>();

        public M链路监控配置 配置 { get; private set; }

        public B链路监控(M链路监控配置 __配置)
        {
            配置 = __配置;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var temp = new Dictionary<string, string>(配置.IP列表);
                    foreach (var __kv in temp)
                    {
                        var __地址 = __kv.Key;
                        M链路状态 __状态 = null;
                        if (_缓存.ContainsKey(__地址))
                        {
                            __状态 = _缓存[__地址];
                        }
                        else
                        {
                            __状态 = new M链路状态 { 地址 = __地址, 通 = true, 描述 = __kv.Value };
                            _缓存[__地址] = __状态;
                        }
                        var __Ping = new Ping();
                        __Ping.PingCompleted += PingCompletedCallback;
                        try
                        {
                            if (Program.IsWindows)
                            {
                                __Ping.SendAsync(__地址, 配置.超时, new Tuple<string, Ping, M链路状态>(__地址, __Ping, __状态));
                            }
                            else
                            {
                                __Ping.SendAsync(Dns.GetHostAddresses(__地址)[0], 配置.超时, new Tuple<string, Ping, M链路状态>(__地址, __Ping, __状态));
                            }
                        }
                        catch (Exception)
                        {
                            处理Ping结果(__地址, __Ping, __状态, false);
                        }
                    }
                    Thread.Sleep(配置.频率);
                }
            });
        }

        public List<M链路状态> 查询状态()
        {
            return _缓存.Values.ToList();
        }

        private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            var __参数 = e.UserState as Tuple<string, Ping, M链路状态>;
            if (__参数 == null)
            {
                return;
            }
            var __地址 = __参数.Item1;
            var __Ping = __参数.Item2;
            var __状态 = __参数.Item3;
            var __通 = true;
            int? __延时 = null;
            if (e.Cancelled || e.Error != null || e.Reply == null || e.Reply.Status != IPStatus.Success || e.Reply.RoundtripTime > 配置.超时)
            {
                __通 = false;
            }
            else
            {
                __延时 = (int)e.Reply.RoundtripTime;
            }
            处理Ping结果(__地址, __Ping, __状态, __通, __延时);
        }

        private void 处理Ping结果(string __地址, Ping __Ping, M链路状态 __状态, bool __通, int? __延时 = null)
        {
            __状态.延时 = __延时;
            __状态.缓存.Enqueue(__通);
            var __旧 = __状态.通;
            if (__状态.缓存.Count > 10)
            {
                var __移除 = __状态.缓存.Dequeue();
                if (__移除 != __通)
                {
                    __状态.通 = __状态.缓存.Count(q => q) >= 配置.阈值;
                }
            }
            else
            {
                __状态.通 = __通;
            }
            if (__状态.通 != __旧)
            {
                On连接变化(__地址, __旧, __状态.通);
            }
            __Ping.PingCompleted -= PingCompletedCallback;
            __Ping.Dispose();
        }

        public void 修改配置(M链路监控配置 __配置)
        {
            配置 = __配置;
            _缓存.Clear();
        }

        public event Action<string, bool?, bool?> 连接变化;

        protected virtual void On连接变化(string __ip, bool? __旧, bool? __新)
        {
            连接变化?.Invoke(__ip, __旧, __新);
        }
    }
}
