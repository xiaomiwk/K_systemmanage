using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 系统管理.客户端
{
    public class M链路监控配置
    {
        /// <summary>
        /// 毫秒
        /// </summary>
        public int 超时 { get; set; }

        /// <summary>
        /// 毫秒/次
        /// </summary>
        public int 频率 { get; set; }

        /// <summary>
        /// 1-10, 通过10次中成功的次数表示当前通断
        /// </summary>
        public int 阈值 { get; set; }

        /// <summary>
        /// key：ip或域名,value：描述
        /// </summary>
        public Dictionary<string, string> IP列表 { get; set; }

        public M链路监控配置()
        {
            this.IP列表 = new Dictionary<string, string>();
        }
    }
}
