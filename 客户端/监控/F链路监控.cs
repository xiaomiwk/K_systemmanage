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
    public partial class F链路监控 : UserControlK
    {
        B链路监控 _BPing;

        Dictionary<string, ListViewItem> _缓存 = new Dictionary<string, ListViewItem>();

        public F链路监控(IT客户端 __客户端)
        {
            _BPing = new B链路监控(__客户端);
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.do配置.Click += Do配置_Click;

            _BPing.连接变化 += _BPing_连接变化;

            Task.Factory.StartNew(() =>
            {
                List<M链路状态> __状态列表 = null;
                Action __UI执行 = () =>
                {
                    for (int i = 0; i < __状态列表.Count; i++)
                    {
                        var __状态 = __状态列表[i];
                        var __地址 = __状态.地址;
                        var __描述 = __状态.描述;
                        var __通断 = "-";
                        var __延时 = __状态.延时.HasValue ? __状态.延时.Value.ToString() : "";
                        var __颜色 = Color.White;
                        if (__状态.通.HasValue)
                        {
                            __通断 = __状态.通.Value ? "通" : "断";
                            __颜色 = __状态.通.Value ? Color.White : Color.Red;
                        }

                        if (_缓存.ContainsKey(__地址))
                        {
                            _缓存[__地址].SubItems[1].Text = __通断;
                            _缓存[__地址].SubItems[2].Text = __延时;
                            _缓存[__地址].SubItems[3].Text = __描述;
                        }
                        else
                        {
                            _缓存[__地址] = this.out列表.Items.Add(new ListViewItem(new string[] {
                            __地址,
                            __通断,
                            __延时,
                            __描述
                         }));
                        }
                        _缓存[__地址].BackColor = __颜色;
                        var __已关闭 = _缓存.Keys.ToList().FindAll(q => !__状态列表.Exists(k => k.地址 == q));
                        __已关闭.ForEach(q =>
                        {
                            this.out列表.Items.Remove(_缓存[q]);
                            _缓存.Remove(q);
                        });
                    }

                    var __断开数 = __状态列表.Count(q => q.通 == false);
                    this.out断开数.Visible = __断开数 > 0;
                    this.out断开数.Text = string.Format("{0} 个断开", __断开数);
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
                        __状态列表 = _BPing.查询状态();
                    }
                    catch (Exception)
                    {
                        __状态列表 = new List<M链路状态>();
                    }
                    this.Invoke(new Action(__UI执行));
                    Thread.Sleep(2000);
                }
            });
        }

        private void _BPing_连接变化(string __地址, bool? __旧, bool? __新)
        {
            HUI线程.执行(() =>
            {
                if ((__新 == true && __旧 == false) || __新 == false)
                {
                    告警?.Invoke(string.Format("{0} {1}", __地址, __新.Value ? "通" : "断"));
                }
            });
        }

        private void Do配置_Click(object sender, EventArgs e)
        {
            var __配置 = _BPing.配置;
            var __窗口 = new F空窗口(new F链路监控_配置(__配置), "配置链路");
            if (__窗口.ShowDialog() == DialogResult.OK)
            {
                _BPing.修改配置(__配置);
            }
        }

        public event Action<string> 告警;
    }
}
