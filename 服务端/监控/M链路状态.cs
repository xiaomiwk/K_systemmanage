using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 系统管理.服务端
{
    public class M链路状态
    {
        public string 地址 { get; set; }

        public string 描述 { get; set; }

        public bool? 通 { get; set; }

        public int? 延时 { get; set; }

        internal Queue<bool> 缓存 { get; set; }

        public M链路状态()
        {
            缓存 = new Queue<bool>();
        }
    }
}
