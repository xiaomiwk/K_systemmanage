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
    public partial class F单独进程 : UserControlK
    {
        string _进程标识;

        B命令行 _B命令行;

        bool _滚屏 = true;

        internal F单独进程(B命令行 __B命令行, string __进程标识)
        {
            _进程标识 = __进程标识;
            _B命令行 = __B命令行;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.do导出.Click += Do导出_Click;
            this.do清空.Click += Do清空_Click;
            this.do滚屏.Click += Do滚屏_Click;

            this.Disposed += (sender1, e1) =>
            {
                _B命令行.正常输出 -= _B命令行_正常输出;
                _B命令行.异常输出 -= _B命令行_异常输出;
                _B命令行.结束进程(_进程标识);
            };
            _B命令行.正常输出 += _B命令行_正常输出;
            _B命令行.异常输出 += _B命令行_异常输出;

            _B命令行.创建进程(_进程标识);
        }

        private void Do滚屏_Click(object sender, EventArgs e)
        {
            if (_滚屏)
            {
                this.do滚屏.Text = "开始滚屏";
                _滚屏 = false;
            }
            else
            {
                this.do滚屏.Text = "停止滚屏";
                _滚屏 = true;
            }
        }

        private void _B命令行_异常输出(M输出 obj)
        {
            HUI线程.执行(() =>
            {
                if (obj.进程标识 == _进程标识 && !this.Disposing)
                {
                    var __index = this.out执行结果.TextLength - 1;
                    this.out执行结果.AppendText(string.Format("{0}{1}", obj.内容, Environment.NewLine));
                    if (_滚屏)
                    {
                        this.out执行结果.ScrollToCaret();
                    }
                    this.out执行结果.Select(Math.Max(0, __index), this.out执行结果.SelectionStart - __index);
                    this.out执行结果.SelectionColor = Color.Red;
                }
            });
        }

        private void _B命令行_正常输出(M输出 obj)
        {
            HUI线程.执行(() =>
            {
                if (obj.进程标识 == _进程标识 && !this.Disposing)
                {
                    this.out执行结果.AppendText(string.Format("{0}{1}", obj.内容, Environment.NewLine));
                    if (_滚屏)
                    {
                        this.out执行结果.ScrollToCaret();
                    }
                }
            });
        }

        public void 执行命令(M命令 __命令)
        {
            if (__命令.参数列表 != null && __命令.参数列表.Count > 0)
            {
                var __窗口 = new F输入参数(__命令, __实参 => _B命令行.执行(_进程标识, F命令行.合成命令(__命令, __实参)));
                new F空窗口(__窗口, "输入参数").ShowDialog();
            }
            else
            {
                _B命令行.执行(_进程标识, __命令.命令行列表);
            }
        }

        private void Do清空_Click(object sender, EventArgs e)
        {
            this.out执行结果.Clear();
        }

        private void Do导出_Click(object sender, EventArgs e)
        {
            SaveFileDialog __窗口 = new SaveFileDialog() { Filter = "rtf files (*.rtf)|*.rtf" };
            if (__窗口.ShowDialog() == DialogResult.OK)
            {
                this.out执行结果.SaveFile(__窗口.FileName);
            }
        }

    }
}
