using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 通用访问;

namespace 系统管理.客户端
{
    class B链路监控
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "链路监控";

        public B链路监控(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
            _IT客户端.订阅事件(_对象名称, "连接变化", __参数 =>
            {
                var __地址 = __参数["地址"];
                bool? __旧 = null;
                bool? __新 = null;
                if (!__参数["旧"].IsNullOrEmpty())
                {
                    __旧 = bool.Parse(__参数["旧"]);
                }
                if (!__参数["新"].IsNullOrEmpty())
                {
                    __新 = bool.Parse(__参数["新"]);
                }
                On连接变化(__地址, __旧, __新);
            });
        }

        public M链路监控配置 配置
        {
            get
            {
                try
                {
                    return HJSON.反序列化<M链路监控配置>(_IT客户端.查询属性值(_对象名称, "配置"));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public List<M链路状态> 查询状态()
        {
            return HJSON.反序列化<List<M链路状态>>(_IT客户端.执行方法(_对象名称, "查询状态", null));
        }

        public void 修改配置(M链路监控配置 __配置)
        {
            _IT客户端.执行方法(_对象名称, "修改配置", new Dictionary<string, string> { { "配置", HJSON.序列化(__配置) } });
        }

        public event Action<string, bool?, bool?> 连接变化;

        protected virtual void On连接变化(string __ip, bool? __旧, bool? __新)
        {
            连接变化?.Invoke(__ip, __旧, __新);
        }
    }
}
