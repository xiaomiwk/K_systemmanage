using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.WindowsForm;
using System.Net;
using 通用访问;
using 通用访问.DTO;

namespace 系统管理.客户端
{
    public partial class F模块列表 : UserControlK
    {
        IPEndPoint _地址;
        string _名称;

        public F模块列表(IPEndPoint __地址, string __名称)
        {
            InitializeComponent();
            _地址 = __地址;
            _名称 = __名称;
            访问入口 = FT通用访问工厂.创建客户端();
            连接();
            this.uTab1.添加("命令行", new F命令行(访问入口) { Dock = DockStyle.Fill });
            this.uTab1.添加("FTP", new FFTP(访问入口) { Dock = DockStyle.Fill });
            this.uTab1.添加("进程管理", new F进程管理(访问入口) { Dock = DockStyle.Fill });
            this.uTab1.添加("监控", new F监控主界面(访问入口) { Dock = DockStyle.Fill });

            this.uTab1.激活("命令行");

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Action __显示连接异常 = () => this.BeginInvoke(new Action(() =>
            {

            }));
            Action __显示连接正常 = () => this.BeginInvoke(new Action(() =>
            {

            }));
            访问入口.已断开 += __主动 =>
            {
                if (!__主动)
                {
                    __显示连接异常();
                }
            };
            访问入口.已连接 += __显示连接正常;
            if (访问入口.连接正常)
            {
                __显示连接正常();
            }
            else
            {
                __显示连接异常();
            }
        }

        public void 连接()
        {
            访问入口.连接(_地址);
        }

        public void 断开()
        {
            访问入口.断开();
        }

        public IT客户端 访问入口 { get; private set; }

    }
}
