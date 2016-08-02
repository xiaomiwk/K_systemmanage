using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 系统管理.服务端
{
    public class M进程监控配置
    {
        public int 频率 { get; set; }

        public List<M进程监控明细> 列表 { get; set; }

    }

    public class M进程监控明细
    {
        public string 进程名 { get; set; }

        public string 描述 { get; set; }

        public int? CPU阈值 { get; set; }

        public int? 内存阈值 { get; set; }

        public int? 阈值次数 { get; set; }
    }

}
