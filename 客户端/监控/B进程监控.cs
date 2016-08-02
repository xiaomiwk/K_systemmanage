using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using 通用访问;

namespace 系统管理.客户端
{
    class B进程监控
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "进程监控";

        public B进程监控(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
            _IT客户端.订阅事件(_对象名称, "告警", __参数 =>
            {
                var __描述 = __参数["描述"];
                告警(__描述);
            });
        }

        public List<M进程状态> 查询状态()
        {
            return HJSON.反序列化<List<M进程状态>>(_IT客户端.执行方法(_对象名称, "查询状态", null));
        }

        public M进程监控配置 查询配置()
        {
            return HJSON.反序列化<M进程监控配置>(_IT客户端.执行方法(_对象名称, "查询配置", null));
        }

        public void 设置配置(M进程监控配置 __配置)
        {
            _IT客户端.执行方法(_对象名称, "设置配置", new Dictionary<string, string> { { "配置", HJSON.序列化(__配置) } });
        }

        public event Action<string> 告警;

        private void on告警(string __描述) { 告警?.Invoke(__描述); }

    }
}
