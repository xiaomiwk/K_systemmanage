using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 系统管理.服务端
{
    class M资源状态
    {
        public bool CPU告警 { get; set; }

        public bool 内存告警 { get; set; }

        public Queue<int> CPU使用率 { get; set; }

        public Queue<int> 内存使用率 { get; set; }

        public M资源状态()
        {
            CPU使用率 = new Queue<int>();
            内存使用率 = new Queue<int>();
        }
    }
}
