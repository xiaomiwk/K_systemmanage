using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace 系统管理.服务端
{
    partial class Service1 : ServiceBase
    {
        B控制器 _B控制器 = new B控制器();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _B控制器.配置();
            _B控制器.开启();
        }

        protected override void OnStop()
        {
            _B控制器.关闭();
        }
    }
}
