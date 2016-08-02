using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.WindowsForm;
using System.IO;
using Utility.存储;
using 通用访问;
using Utility.扩展;
using System.Diagnostics;

namespace 系统管理.客户端
{
    public partial class F结束进程 : UserControlK
    {
        public string 命令 { get; set; }

        bool _isWindows;

        internal F结束进程(bool __isWindows)
        {
            _isWindows = __isWindows;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in命令.Items.AddRange(new object[] { "pkill -f <进程名>", "taskkill /F /T /IM <进程名>" });
            if (_isWindows)
            {
                this.in命令.SelectedIndex = 1;
            }
            else
            {
                this.in命令.SelectedIndex = 0;
            }
            this.in命令.Focus();

            this.do取消.Click += Do取消_Click;
            this.do确定.Click += Do确定_Click;
        }

        private void Do确定_Click(object sender, EventArgs e)
        {
            this.命令 = this.in命令.Text;
            this.ParentForm.DialogResult = DialogResult.OK;
            this.ParentForm.Close();
        }

        private void Do取消_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = DialogResult.Cancel;
            this.ParentForm.Close();
        }
    }
}
