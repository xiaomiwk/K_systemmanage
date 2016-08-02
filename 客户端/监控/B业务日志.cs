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
    class B业务日志
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "业务日志";

        public B业务日志(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
        }

        public int 缓存上限
        {
            get
            {
                try
                {
                    return int.Parse(_IT客户端.查询属性值(_对象名称, "缓存上限"));
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        public List<M业务日志> 查询缓存()
        {
            //var __结果 = HJSON.AES解压(_IT客户端.执行方法(_对象名称, "查询缓存"));
            var __结果 = _IT客户端.执行方法(_对象名称, "查询缓存");
            return HJSON.反序列化<List<M业务日志>>(__结果);
        }

    }
}
