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
    public partial class F进程监控 : UserControlK
    {
        B进程监控 _B进程监控;

        Dictionary<int, ListViewItem> _缓存 = new Dictionary<int, ListViewItem>();

        public F进程监控(IT客户端 __客户端)
        {
            _B进程监控 = new B进程监控(__客户端);
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.do配置.Click += Do配置_Click;
            _B进程监控.告警 += on告警;

            Task.Factory.StartNew(() =>
            {
                List<M进程状态> __状态列表 = null;
                Action __UI执行 = () =>
                {
                    for (int i = 0; i < __状态列表.Count; i++)
                    {
                        var __状态 = __状态列表[i];
                        if (_缓存.ContainsKey(__状态.Id))
                        {
                            _缓存[__状态.Id].SubItems[1].Text = __状态.名称;
                            _缓存[__状态.Id].SubItems[2].Text = __状态.描述;
                            _缓存[__状态.Id].SubItems[3].Text = __状态.CPU.HasValue ? __状态.CPU.ToString() : "";
                            _缓存[__状态.Id].SubItems[4].Text = (__状态.内存 / 1024).ToString("0,00");
                            _缓存[__状态.Id].SubItems[5].Text = __状态.线程数.ToString();
                            _缓存[__状态.Id].SubItems[6].Text = __状态.启动时间.ToString("yyyy-MM-dd HH:mm:ss");
                            _缓存[__状态.Id].SubItems[7].Text = __状态.路径;
                        }
                        else
                        {
                            _缓存[__状态.Id] = this.out列表.Items.Add(new ListViewItem(new string[] {
                            __状态.Id.ToString(),
                            __状态.名称,
                            __状态.描述,
                            __状态.CPU.HasValue ? __状态.CPU.ToString() : "",
                            (__状态.内存 / 1024).ToString("0,00"),
                            __状态.线程数.ToString(),
                            __状态.启动时间.ToString("yyyy-MM-dd HH:mm:ss"),
                            __状态.路径
                         }));
                        }
                    }
                    var __已关闭 = _缓存.Keys.ToList().FindAll(q => !__状态列表.Exists(k => k.Id == q));
                    __已关闭.ForEach(q =>
                    {
                        this.out列表.Items.Remove(_缓存[q]);
                        _缓存.Remove(q);
                    });
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
                        __状态列表 = _B进程监控.查询状态();
                    }
                    catch (Exception)
                    {
                        __状态列表 = new List<M进程状态>();
                    }
                    this.Invoke(new Action(__UI执行));
                    Thread.Sleep(2000);
                }
            });
        }

        private void Do配置_Click(object sender, EventArgs e)
        {
            var __配置 = _B进程监控.查询配置();
            var __配置窗口 = new F进程监控_配置(__配置);
            var __窗口 = new F空窗口(__配置窗口, "配置进程");
            if (__窗口.ShowDialog() == DialogResult.OK)
            {
                _B进程监控.设置配置(__配置窗口.配置);
            }
        }

        public event Action<string> 告警;

        protected void on告警(string __描述)
        {
            HUI线程.执行(() => { 告警?.Invoke(__描述); });
        }
    }
}
