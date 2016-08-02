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
    public partial class F链路监控_配置 : UserControlK
    {
        M链路监控配置 _配置;

        public F链路监控_配置(M链路监控配置 __配置)
        {
            _配置 = __配置;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            for (int i = 1; i <= 10; i++)
            {
                this.in阈值.Items.Add(i);
            }
            this.in超时.Text = _配置.超时.ToString();
            this.in阈值.SelectedItem = _配置.阈值;
            this.in频率.Text = _配置.频率.ToString();
            _配置.IP列表.ForEach(q => this.out地址列表.Rows.Add(q.Key, q.Value, "删除"));
            this.do添加.Click += Do添加_Click;
            this.do确定.Click += Do确定_Click;
            this.out地址列表.CellMouseClick += Out地址列表_CellMouseClick;
        }

        private void Out地址列表_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == this.out地址列表.ColumnCount - 1 && e.RowIndex >= 0)
            {
                this.out地址列表.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void Do确定_Click(object sender, EventArgs e)
        {
            _配置.超时 = int.Parse(this.in超时.Text.Trim());
            _配置.阈值 = (int)this.in阈值.SelectedItem;
            _配置.频率 = int.Parse(this.in频率.Text.Trim());
            _配置.IP列表.Clear();
            foreach (DataGridViewRow row in this.out地址列表.Rows)
            {
                _配置.IP列表.Add((string)row.Cells[0].Value, (string)row.Cells[1].Value);
            }
            this.ParentForm.DialogResult = DialogResult.OK;
            this.ParentForm.Close();
        }

        private void Do添加_Click(object sender, EventArgs e)
        {
            this.out地址列表.Rows.Add(this.in地址.Text, this.in描述.Text, "删除");
        }
    }
}
