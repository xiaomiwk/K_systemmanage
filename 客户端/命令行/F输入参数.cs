using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.WindowsForm;

namespace 系统管理.客户端
{
    public partial class F输入参数 : UserControlK
    {
        public Dictionary<string, string> 参数 { get; set; }

        M命令 _命令;
        List<M命令参数> _形参;

        Action<Dictionary<string, string>> _处理实参;

        public F输入参数(M命令 __命令, Action<Dictionary<string, string>> __处理实参)
        {
            _命令 = __命令;
            _形参 = __命令.参数列表;
            _处理实参 = __处理实参;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_命令.描述.IsNullOrEmpty())
            {
                this.splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                this.out说明.Text = _命令.描述;
            }
            _形参.ForEach(q => this.in参数列表.Rows.Add(q.名称, q.默认值, q.默认值, q.描述));
            this.do取消.Click += Do取消_Click;
            this.do确定.Click += Do确定_Click;
            this.do确定并关闭.Click += Do确定并关闭_Click;
        }

        private void Do确定并关闭_Click(object sender, EventArgs e)
        {
            this.do确定.PerformClick();
            this.ParentForm.Close();
        }

        private void Do确定_Click(object sender, EventArgs e)
        {
            this.参数 = new Dictionary<string, string>();
            foreach (DataGridViewRow item in this.in参数列表.Rows)
            {
                var __名称 = (string)item.Cells[0].Value;
                var __值 = (string)item.Cells[1].Value;
                this.参数[__名称] = __值;
            }
            _处理实参(this.参数);
        }

        private void Do取消_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
