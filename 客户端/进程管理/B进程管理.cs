using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 通用访问;

namespace 系统管理.客户端
{
    class B进程管理
    {
        IT客户端 _客户端;

        string _对象名 = "进程管理";

        public B进程管理(IT客户端 __客户端)
        {
            _客户端 = __客户端;
        }

        public List<M进程状态> 查询所有()
        {
            var __结果 = _客户端.执行方法(_对象名, "查询所有", null);
            return HJSON.反序列化<List<M进程状态>>(__结果);
        }

        public void 结束进程(int id)
        {
            _客户端.执行方法(_对象名, "结束进程", new Dictionary<string, string> { { "Id", id.ToString() } });
        }

    }
}
