using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.WindowsForm;
using 通用访问;
using System.IO;
using Utility.存储;
using System.Diagnostics;

namespace 系统管理.客户端
{
    public partial class F监控主界面 : UserControlK
    {
        IT客户端 _客户端;

        B业务日志 _B业务日志;

        public F监控主界面(IT客户端 __客户端)
        {
            _客户端 = __客户端;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var __链路 = new F链路监控(_客户端) { Dock = DockStyle.Fill, Margin = new Padding(0) };
            this.out链路.Controls.Add(__链路);
            __链路.告警 += __描述 => 增加纪录(DateTime.Now, "链路", __描述);

            var __资源 = new F资源监控(_客户端) { Dock = DockStyle.Fill, Margin = new Padding(0) };
            this.out资源.Controls.Add(__资源);
            __资源.告警 += __描述 => 增加纪录(DateTime.Now, "资源", __描述);

            var __进程 = new F进程监控(_客户端) { Dock = DockStyle.Fill, Margin = new Padding(0) };
            this.out进程.Controls.Add(__进程);
            __进程.告警 += __描述 => 增加纪录(DateTime.Now, "进程", __描述);

            this.do向上折叠.Click += (sender1, e1) => this.splitContainer1.Panel1Collapsed = !this.splitContainer1.Panel1Collapsed;
            this.do向下折叠.Click += (sender1, e1) => this.splitContainer1.Panel2Collapsed = !this.splitContainer1.Panel2Collapsed;

            this.do清空.Click += Do清空_Click;

            _B业务日志 = new B业务日志(_客户端);
            var __列表 = _B业务日志.查询缓存();
            __列表.ForEach(q => 增加纪录(q.时间, q.类别, q.描述));
        }

        private void 增加纪录(DateTime __时间, string __类别, string __描述)
        {
            this.out告警记录.Items.Insert(0, new ListViewItem(new string[] { __时间.ToString(), __类别, __描述 }));
            if (this.out告警记录.Items.Count > 1000)
            {
                this.out告警记录.Items.RemoveAt(1000);
            }
        }

        private void Do清空_Click(object sender, EventArgs e)
        {
            this.out告警记录.Items.Clear();
        }
    }
}
