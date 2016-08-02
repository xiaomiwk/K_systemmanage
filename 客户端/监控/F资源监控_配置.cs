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
    public partial class F资源监控_配置 : UserControlK
    {
        M资源监控配置 _配置;

        public F资源监控_配置(M资源监控配置 __配置)
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
            this.in内存阈值.Text = _配置.内存阈值.ToString();
            this.inCPU阈值.Text = _配置.CPU阈值.ToString();
            this.in阈值.SelectedItem = _配置.阈值次数;
            this.in频率.Text = _配置.频率.ToString();
            this.do确定.Click += Do确定_Click;
        }

        private void Do确定_Click(object sender, EventArgs e)
        {
            _配置.内存阈值 = int.Parse(this.in内存阈值.Text.Trim());
            _配置.CPU阈值 = int.Parse(this.inCPU阈值.Text.Trim());
            _配置.阈值次数 = (int)this.in阈值.SelectedItem;
            _配置.频率 = int.Parse(this.in频率.Text.Trim());
            this.ParentForm.DialogResult = DialogResult.OK;
            this.ParentForm.Close();
        }
    }
}
