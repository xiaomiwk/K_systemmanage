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
using Utility.扩展;
using System.Threading.Tasks;
using System.Threading;

namespace 系统管理.客户端
{
    public partial class F资源监控 : UserControlK
    {
        B资源监控 _B资源监控;

        int _缓存数量 = 20;

        public F资源监控(IT客户端 __客户端)
        {
            _B资源监控 = new B资源监控(__客户端);
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.do配置.Click += Do配置_Click;

            _B资源监控.告警 += __描述 => HUI线程.执行(() => 告警?.Invoke(__描述));

            this.outCPU占用率.Visible = false;
            this.out内存占用率.Visible = false;

            this.chart1.ChartAreas[0].AxisX.Maximum = _缓存数量;
            this.chart1.ChartAreas[0].AxisX.Minimum = 1;
            this.chart1.ChartAreas[0].AxisY.Maximum = 100;
            this.chart1.ChartAreas[0].AxisY.Minimum = 0;

            Task.Factory.StartNew(() =>
            {
                M资源状态 __状态 = null;
                Action __UI执行 = () =>
                {
                    显示状态("内存", __状态.内存使用率, __状态.内存告警, this.out内存占用率, "内存: {0}%");
                    显示状态("CPU", __状态.CPU使用率, __状态.CPU告警, this.outCPU占用率, "CPU: {0}%");
                };
                while (!this.Disposing && !this.IsDisposed)
                {
                    if (!Visible)
                    {
                        Thread.Sleep(2000);
                        continue;
                    }
                    try
                    {
                        __状态 = _B资源监控.查询状态();
                    }
                    catch (Exception)
                    {
                        __状态 = new M资源状态();
                    }
                    this.Invoke(new Action(__UI执行));
                    Thread.Sleep(1000);
                }
            });
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                chart1.Series["内存"].Points.Clear();
                chart1.Series["CPU"].Points.Clear();
            }
        }

        private void 显示状态(string __名称, Queue<int> __数据, bool __告警, Label __告警标志, string __格式)
        {
            var __点集合 = chart1.Series[__名称].Points;
            if (__数据 == null || __数据.Count == 0)
            {
                __点集合.Clear();
                __告警标志.Visible = false;
                return;
            }
            if (__点集合.Count == 0)
            {
                __数据.ForEach(q => __点集合.Add(q));
            }
            else
            {
                __点集合.Add(__数据.Last());
                if (__点集合.Count > _缓存数量)
                {
                    __点集合.RemoveAt(0);
                }
            }
            __告警标志.Visible = __告警;
            if (__告警)
            {
                __告警标志.Text = string.Format(__格式, __数据.Last().ToString());
            }
        }

        private void Do配置_Click(object sender, EventArgs e)
        {
            var __配置 = _B资源监控.配置;
            var __配置窗口 = new F资源监控_配置(__配置);
            var __窗口 = new F空窗口(__配置窗口, "配置资源");
            if (__窗口.ShowDialog() == DialogResult.OK)
            {
                _B资源监控.设置配置(__配置);
            }
        }

        public event Action<string> 告警;

    }
}
