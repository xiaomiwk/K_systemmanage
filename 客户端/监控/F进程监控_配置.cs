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
    public partial class F进程监控_配置 : UserControlK
    {
        public M进程监控配置 配置 { get; set; }

        public F进程监控_配置(M进程监控配置 __配置)
        {
            配置 = __配置;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in监控频率.Text = 配置.频率.ToString();
            配置.列表.ForEach(q => this.out列表.Rows.Add(q.进程名, q.描述, q.CPU阈值, q.内存阈值, q.阈值次数, "删除"));
            this.do添加.Click += Do添加_Click;
            this.do确定.Click += Do确定_Click;
            this.out列表.CellMouseClick += Out地址列表_CellMouseClick;

            this.in进程名.Text = "foxmail";
            this.in描述.Text = "邮件客户端";
        }

        private void Out地址列表_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                this.out列表.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void Do确定_Click(object sender, EventArgs e)
        {
            配置.频率 = int.Parse(this.in监控频率.Text.Trim());
            配置.列表.Clear();
            foreach (DataGridViewRow row in this.out列表.Rows)
            {
                var __进程名 = (string)row.Cells[0].Value;
                var __描述 = (string)row.Cells[1].Value;
                int? __CPU阈值 = string.IsNullOrEmpty((string)row.Cells[2].Value) ? (int?)null : int.Parse((string)row.Cells[2].Value);
                int? __内存阈值 = string.IsNullOrEmpty((string)row.Cells[3].Value) ? (int?)null : int.Parse((string)row.Cells[3].Value);
                int? __阈值次数 = string.IsNullOrEmpty((string)row.Cells[4].Value) ? (int?)null : int.Parse((string)row.Cells[4].Value);
                配置.列表.Add(new M进程监控明细 { 进程名 = __进程名, 描述 = __描述, CPU阈值 = __CPU阈值, 内存阈值 = __内存阈值, 阈值次数 = __阈值次数 });
            }
            this.ParentForm.DialogResult = DialogResult.OK;
            this.ParentForm.Close();
        }

        private void Do添加_Click(object sender, EventArgs e)
        {
            this.out列表.Rows.Add(this.in进程名.Text, this.in描述.Text, this.inCPU阈值.Text, this.in内存阈值.Text, this.in阈值次数.Text, "删除");
        }
    }
}
