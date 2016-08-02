using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 系统管理.客户端
{
    public class M命令
    {
        public string 操作系统 { get; set; }
        public string 类别 { get; set; }
        public string 名称 { get; set; }
        public bool 常用 { get; set; }
        public bool 独立进程执行 { get; set; }
        public List<string> 终止命令行列表 { get; set; }
        public List<string> 命令行列表 { get; set; }
        public List<M命令参数> 参数列表 { get; set; }
        public string 描述 { get; set; }

        public override string ToString()
        {
            var __描述 = new StringBuilder();
            __描述.AppendFormat("名称：{0}", 名称).AppendLine();
            if (this.命令行列表 != null && this.命令行列表.Count > 0)
            {
                __描述.Append("命令行：");
                for (int i = 0; i < this.命令行列表.Count; i++)
                {
                    __描述.AppendFormat("{0,-10}", this.命令行列表[i]).AppendLine();
                }
            }
            if (this.参数列表 != null && this.参数列表.Count > 0)
            {
                __描述.Append("参数：");
                for (int i = 0; i < this.参数列表.Count; i++)
                {
                    __描述.AppendFormat("{0,-10}，{1}，{2}", this.参数列表[i].名称, this.参数列表[i].默认值, this.参数列表[i].描述).AppendLine();
                }
            }
            if (独立进程执行)
            {
                __描述.Append("独立进程执行：true");
                if (this.终止命令行列表 != null && this.终止命令行列表.Count > 0)
                {
                    __描述.Append("终止命令行：");
                    for (int i = 0; i < this.终止命令行列表.Count; i++)
                    {
                        __描述.Append(this.终止命令行列表[i]).AppendLine();
                    }
                }
            }
            if (this.描述.IsNotNullOrEmpty())
            {
                __描述.Append("描述：");
                __描述.AppendFormat("{0,-10}", 描述).AppendLine();
            }

            return __描述.ToString();
        }
    }

    public class M命令参数
    {
        public string 名称 { get; set; }
        public string 默认值 { get; set; }
        public string 描述 { get; set; }
    }
}
