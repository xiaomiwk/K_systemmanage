using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 系统管理.客户端
{
    public class M资源监控配置
    {
        /// <summary>
        /// 毫秒/次
        /// </summary>
        public int 频率 { get; set; }

        public int 阈值次数 { get; set; }

        /// <summary>
        /// 使用率 0-100
        /// </summary>
        public int CPU阈值 { get; set; }

        /// <summary>
        /// 使用率 0-100
        /// </summary>
        public int 内存阈值 { get; set; }
    }
}
