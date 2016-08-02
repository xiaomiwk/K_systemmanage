using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 系统管理.服务端
{
    public class M进程状态
    {
        public string 名称 { get; set; }
        public int Id { get; set; }
        public int? CPU { get; set; }
        public long 内存 { get; set; }
        public string 路径 { get; set; }
        public string 描述 { get; set; }
        public DateTime 启动时间 { get; set; }
        public int 线程数 { get; set; }
    }

}
