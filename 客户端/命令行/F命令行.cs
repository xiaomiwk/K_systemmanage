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
    public partial class F命令行 : UserControlK
    {
        IT客户端 _客户端;

        string _进程标识 = "k";

        string _配置文件 = "默认命令行.txt";

        B命令行 _B命令行;

        bool _滚屏 = true;

        StringBuilder _正常输出缓存 = new StringBuilder();

        StringBuilder _异常输出缓存 = new StringBuilder();

        bool _进程已创建 = false;

        int _上次查询位置 = 0;
        string _上次查询内容 = "";

        public F命令行(IT客户端 __客户端)
        {
            HUI线程.初始化();
            _客户端 = __客户端;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.timer1.Interval = 1000;
            this.timer1.Tick += Timer1_Tick;
            this.timer1.Start();
            this.out命令列表.NodeMouseDoubleClick += Out命令列表_NodeMouseDoubleClick;
            this.in输入.KeyDown += In输入_KeyDown;
            this.in查询.KeyDown += In查询_KeyDown;
            this.do导入.Click += Do从文件加载_Click;
            this.do导出.Click += Do导出_Click;
            this.do清空.Click += Do清空_Click;
            this.do编辑.Click += Do编辑_Click;
            this.do滚屏.Click += Do滚屏_Click;
            this.do强制结束.Click += Do强制结束_Click;
            this.do折叠.Click += (sender1, e1) => this.splitContainer1.Panel1Collapsed = !this.splitContainer1.Panel1Collapsed;

            this.do复制.Click += Do复制_Click;
            this.do查询1.Click += Do查询1_Click;
            this.do查询.Click += Do查询_Click;
            导入(_配置文件);

            _B命令行 = new B命令行(_客户端);
            foreach (TreeNode node in this.out命令列表.Nodes)
            {
                if ((_B命令行.IsWindows && node.Text == "Windows") || (!_B命令行.IsWindows && node.Text != "Windows"))
                {
                    node.ExpandAll();
                }
            }

            this.Disposed += (sender1, e1) =>
            {
                _B命令行.正常输出 -= _B命令行_正常输出;
                _B命令行.异常输出 -= _B命令行_异常输出;
                _B命令行.结束进程(_进程标识);
            };
            _B命令行.正常输出 += _B命令行_正常输出;
            _B命令行.异常输出 += _B命令行_异常输出;
            创建进程();
        }

        private void In查询_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.do查询.PerformClick();
            }
        }

        private void Do查询1_Click(object sender, EventArgs e)
        {
            var __选中 = this.out执行结果.SelectedText;
            if (string.IsNullOrEmpty(__选中))
            {
                new F对话框_确定("没有选中任何内容").ShowDialog();
                return;
            }
            this.in查询.Text = __选中;
            this.do查询.PerformClick();
            this.in查询.Focus();
        }

        private void Do查询_Click(object sender, EventArgs e)
        {
            var __内容 = this.in查询.Text;
            if (string.IsNullOrEmpty(__内容) || string.IsNullOrEmpty(this.out执行结果.Text))
            {
                return;
            }
            if (_上次查询位置 >= 0 && _上次查询位置 + _上次查询内容.Length <= this.out执行结果.TextLength)
            {
                this.out执行结果.SelectionStart = _上次查询位置;
                this.out执行结果.SelectionLength = _上次查询内容.Length;
                this.out执行结果.SelectionBackColor = Color.White;
            }
            var __本次查询位置 = 0;
            if (_上次查询位置 > 0)
            {
                __本次查询位置 = _上次查询位置 + _上次查询内容.Length;
            }
            else
            {
                __本次查询位置 = this.out执行结果.SelectionStart;
                if (__本次查询位置 == this.out执行结果.TextLength)
                {
                    __本次查询位置 = 0;
                }
            }
            if (__本次查询位置 >= this.out执行结果.Text.Length)
            {
                __本次查询位置 = 0;
            }
            var __索引 = this.out执行结果.Find(__内容, __本次查询位置, RichTextBoxFinds.None);
            if (__索引 >= 0)
            {
                this.out执行结果.SelectionStart = __索引;
                this.out执行结果.SelectionLength = __内容.Length;
                this.out执行结果.SelectionBackColor = Color.Yellow;
                _上次查询位置 = __索引;
                _上次查询内容 = __内容;
            }
            else
            {
                _上次查询位置 = -1;
                this.out执行结果.SelectionStart = this.out执行结果.TextLength;
            }
            this.out执行结果.ScrollToCaret();
        }

        private void Do复制_Click(object sender, EventArgs e)
        {
            var __选中 = this.out执行结果.SelectedText;
            if (string.IsNullOrEmpty(__选中))
            {
                new F对话框_确定("没有选中任何内容").ShowDialog();
                return;
            }
            Clipboard.SetText(__选中);
        }

        private void 创建进程()
        {
            try
            {
                _B命令行.创建进程(_进程标识);
                _进程已创建 = true;
            }
            catch (Exception ex)
            {
                _异常输出缓存.AppendLine("创建进程失败: " + ex.Message);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (_正常输出缓存.Length > 0)
            {
                var __描述 = _正常输出缓存.ToString();
                _正常输出缓存.Clear();
                this.out执行结果.AppendText(__描述);
                if (_滚屏)
                {
                    this.out执行结果.ScrollToCaret();
                }
            }
            if (_异常输出缓存.Length > 0)
            {
                var __描述 = _异常输出缓存.ToString();
                _异常输出缓存.Clear();
                var __index = this.out执行结果.TextLength - 1;
                this.out执行结果.AppendText(__描述);
                if (_滚屏)
                {
                    this.out执行结果.ScrollToCaret();
                }
                this.out执行结果.Select(Math.Max(0, __index), this.out执行结果.SelectionStart - __index);
                this.out执行结果.SelectionColor = Color.Red;
            }
        }

        private void Do强制结束_Click(object sender, EventArgs e)
        {
            var __窗口 = new F结束进程(_B命令行.IsWindows);
            if (new F空窗口(__窗口, "结束进程").ShowDialog() == DialogResult.OK)
            {
                var __命令 = __窗口.命令;
                var __进程标识 = Guid.NewGuid().ToString();
                _B命令行.创建进程(__进程标识);
                _B命令行.执行(__进程标识, __命令);
                _B命令行.结束进程(__进程标识);
            }
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

        private void 导入(string __文件名)
        {
            var __json = File.ReadAllText(H路径.获取绝对路径(__文件名), Encoding.UTF8);
            var __命令列表 = H序列化.FromJSON字符串<List<M命令>>(__json);
            __命令列表.Sort(new Comparison<M命令>((m, n) => m.类别.CompareTo(n.类别)));
            this.out命令列表.Nodes.Clear();
            this.out命令列表.Tag = __文件名;

            var __所有操作系统 = __命令列表.GroupBy<M命令, string>(q => q.操作系统).OrderBy(q => q.Key);
            foreach (var __操作系统 in __所有操作系统)
            {
                var __父节点 = this.out命令列表.Nodes.Add(__操作系统.Key.IsNotNullOrEmpty() ? __操作系统.Key : "未分类");
                var __所有分组 = __操作系统.GroupBy<M命令, string>(q => q.类别).OrderBy(q => q.Key);
                foreach (var __分组 in __所有分组)
                {
                    var __子节点 = __父节点.Nodes.Add(__分组.Key.IsNotNullOrEmpty() ? __分组.Key : "未分类");
                    var __排序分组 = __分组.OrderBy(q => q.名称);
                    foreach (M命令 item in __排序分组)
                    {
                        __子节点.Nodes.Add(new TreeNode(item.名称) { Tag = item, ToolTipText = item.ToString(), BackColor = item.常用 ? Color.LightYellow : Color.White });
                    }
                }
            }
        }

        private void _B命令行_异常输出(M输出 obj)
        {
            if (obj.进程标识 == _进程标识)
            {
                _异常输出缓存.AppendLine(obj.内容);
            }
        }

        private void _B命令行_正常输出(M输出 obj)
        {
            if (obj.进程标识 == _进程标识)
            {
                _正常输出缓存.AppendLine(obj.内容);
            }
        }

        private void In输入_KeyDown(object sender, KeyEventArgs e)
        {
            var __输入 = this.in输入.Text;
            if (e.KeyCode == Keys.Enter && __输入.IsNotNullOrEmpty())
            {
                _B命令行.执行(_进程标识, __输入.Trim());
                if (this.in输入.Items.Contains(__输入))
                {
                    this.in输入.Items.Remove(__输入);
                }
                this.in输入.Items.Insert(0, __输入);
                if (this.in输入.Items.Count > 20)
                {
                    this.in输入.Items.RemoveAt(20);
                }
            }
        }

        private void Out命令列表_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                return;
            }
            var __命令 = e.Node.Tag as M命令;
            if (__命令.独立进程执行)
            {
                var __单独进程 = new F单独进程(_B命令行, Guid.NewGuid().ToString());
                __单独进程.Disposed += (sender1, e1) =>
                {
                    if (__命令.终止命令行列表 != null)
                    {
                        __命令.终止命令行列表.ForEach(q => _B命令行.执行(_进程标识, q));
                    }
                };
                new F空窗口(__单独进程, "命令行").Show();
                __单独进程.执行命令(__命令);
            }
            else
            {
                执行命令(__命令);
            }
        }

        public void 执行命令(M命令 __命令)
        {
            if (__命令.参数列表 != null && __命令.参数列表.Count > 0)
            {
                var __窗口 = new F输入参数(__命令, __实参 =>
                {
                    var __命令列表 = 合成命令(__命令, __实参);
                    _正常输出缓存.AppendLine();
                    __命令列表.ForEach(q => _正常输出缓存.AppendLine(q));
                    _B命令行.执行(_进程标识, __命令列表);
                });
                new F空窗口(__窗口, "输入参数").ShowDialog();
            }
            else
            {
                if (!_进程已创建)
                {
                    创建进程();
                }
                if (_进程已创建)
                {
                    _正常输出缓存.AppendLine();
                    __命令.命令行列表.ForEach(q => _正常输出缓存.AppendLine(q));
                    _B命令行.执行(_进程标识, __命令.命令行列表);
                }
            }
        }

        public static List<string>  合成命令(M命令 __命令, Dictionary<string, string> __参数 = null)
        {
            var __命令行列表 = __命令.命令行列表;
            if (__命令.参数列表 != null && __命令.参数列表.Count > 0 && __参数 != null)
            {
                __命令行列表 = new List<string>(__命令行列表);
                for (int i = 0; i < __命令行列表.Count; i++)
                {
                    foreach (var item in __参数)
                    {
                        __命令行列表[i] = __命令行列表[i].Replace("<" + item.Key + ">", item.Value);
                    }
                }
            }
            return __命令行列表;
        }

        private void Do编辑_Click(object sender, EventArgs e)
        {
            var __文件名 = (string)this.out命令列表.Tag;
            try
            {
                var __原内容 = File.ReadAllText(__文件名);
                Process.Start("notepad.exe", __文件名).WaitForExit();
                var __新内容 = File.ReadAllText(__文件名);
                if (__原内容 != __新内容) // && 
                {
                    导入((string)this.out命令列表.Tag);
                }
            }
            catch (Exception)
            {
                new F对话框_确定(string.Format("编辑 {0} 出错", __文件名)).ShowDialog();
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

        private void Do从文件加载_Click(object sender, EventArgs e)
        {
            OpenFileDialog __窗口 = new OpenFileDialog();
            if (__窗口.ShowDialog() == DialogResult.OK)
            {
                导入(__窗口.FileName);
            }
        }
    }
}
