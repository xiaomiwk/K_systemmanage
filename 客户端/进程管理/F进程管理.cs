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
using System.Diagnostics;
using Utility.扩展;
using System.Threading.Tasks;
using System.Threading;

namespace 系统管理.客户端
{
    public partial class F进程管理 : UserControlK
    {
        B进程管理 _B进程管理;

        IT客户端 _IT客户端;

        Dictionary<int, ListViewItem> _缓存 = new Dictionary<int, ListViewItem>();

        bool _允许刷新 = true;

        public F进程管理(IT客户端 __客户端)
        {
            _IT客户端 = __客户端;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _B进程管理 = new B进程管理(_IT客户端);

            this.do刷新.Click += Do停止刷新_Click;
            this.out列表.MouseDoubleClick += Out列表_MouseDoubleClick;

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
                            var __旧 = _缓存[__状态.Id].Tag as M进程状态;
                            if (object.Equals(__旧.名称, __状态.名称) && object.Equals(__旧.CPU, __状态.CPU)
                                && object.Equals(__旧.内存, __状态.内存) && object.Equals(__旧.路径, __状态.路径))
                            {
                                continue;
                            }
                            _缓存[__状态.Id].SubItems[1].Text = __状态.名称;
                            _缓存[__状态.Id].SubItems[2].Text = __状态.CPU.HasValue ? __状态.CPU.ToString() : "";
                            _缓存[__状态.Id].SubItems[3].Text = (__状态.内存 / 1024).ToString("0,00");
                            _缓存[__状态.Id].SubItems[4].Text = __状态.路径;
                        }
                        else
                        {
                            _缓存[__状态.Id] = this.out列表.Items.Insert(i, new ListViewItem(new string[] {
                            __状态.Id.ToString(),
                            __状态.名称,
                            __状态.CPU.ToString(),
                            (__状态.内存 / 1024).ToString("0,00"),
                            __状态.路径
                                }));
                            _缓存[__状态.Id].Tag = __状态;
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
                    if (!Visible || !_允许刷新)
                    {
                        Thread.Sleep(2000);
                        continue;
                    }
                    try
                    {
                        __状态列表 = null;
                        __状态列表 = _B进程管理.查询所有();
                    }
                    catch (Exception)
                    {
                    }
                    this.Invoke(new Action(__UI执行));
                    Thread.Sleep(2000);
                }
            });
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.Visible)
            {
                _允许刷新 = true;
                this.do刷新.Text = "停止刷新";
            }
            else
            {
                this.do刷新.Text = "开始刷新";
            }
        }

        private void Out列表_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var __行 = this.out列表.GetItemAt(e.X, e.Y);
            if (__行 == null)
            {
                return;
            }
            var __Id = __行.SubItems[0].Text;
            var __名称 = __行.SubItems[1].Text;

            if (new F对话框_是否(string.Format("确定要结束进程 {0}({1}) 吗?", __名称, __Id)).ShowDialog() == DialogResult.Yes)
            {
                _B进程管理.结束进程(int.Parse(__Id));
            }
        }

        private void Do停止刷新_Click(object sender, EventArgs e)
        {
            if (this.do刷新.Text == "停止刷新")
            {
                this.do刷新.Text = "开始刷新";
                _允许刷新 = false;
            }
            else
            {
                this.do刷新.Text = "停止刷新";
                _允许刷新 = true;
            }
        }
    }
}
