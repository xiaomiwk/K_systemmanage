using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 通用访问;

namespace 系统管理.客户端
{
    class B资源监控
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "资源监控";

        public B资源监控(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
            _IT客户端.订阅事件(_对象名称, "告警", __参数 =>
            {
                var __描述 = __参数["描述"];
                告警(__描述);
            });
        }

        public M资源监控配置 配置
        {
            get
            {
                try
                {
                    return HJSON.反序列化<M资源监控配置>(_IT客户端.查询属性值(_对象名称, "配置"));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public void 设置配置(M资源监控配置 __配置)
        {
            _IT客户端.执行方法(_对象名称, "设置配置", new Dictionary<string, string> { { "配置", HJSON.序列化(__配置) } });
        }

        public M资源状态 查询状态()
        {
            var __结果 = _IT客户端.执行方法(_对象名称, "查询状态");
            return HJSON.反序列化<M资源状态>(__结果);
        }

        public event Action<string> 告警;

        private void on告警(string __描述) { 告警?.Invoke(__描述); }

    }
}
