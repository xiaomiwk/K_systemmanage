using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using INET;
using Utility.WindowsForm;
using Utility.存储;
using Utility.通用;
using 通用访问;

namespace 系统管理.客户端
{
    public partial class F主窗口 : FormK
    {
        private Point _鼠标位置;

        private TreeNode _当前设备节点;

        public F主窗口()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.out标题.Text += " " + Assembly.GetExecutingAssembly().GetName().Version;

            this.out设备列表.ShowNodeToolTips = true;
            this.out设备列表.NodeMouseDoubleClick += out设备列表_NodeMouseDoubleClick;

            this.do设备_断开.Click += do设备_断开_Click;
            this.out设备菜单.Opening += out设备菜单_Opening;
            this.out设备列表.MouseDown += TV_MouseDown;

            this.do编辑设备.Click += do编辑设备_Click;
            this.do折叠.Click += (sender, e1) => this.splitContainer1.Panel1Collapsed = !this.splitContainer1.Panel1Collapsed;

            加载设备列表();

            H日志输出.设置(__日志 => H调试.记录(__日志.概要, __日志.等级, __日志.详细, __日志.方法, __日志.文件, __日志.行号));
        }

        private void 加载设备列表()
        {
            this.out设备列表.Nodes.Clear();
            var __设备列表 = new List<M设备>();
            var __文件 = H路径.打开文件("设备列表.xml");
            var __XML文档 = XDocument.Load(__文件);
            __文件.Close();
            var __根节点 = __XML文档.Root;
            foreach (XElement __节点 in __根节点.XPathSelectElements("./设备"))
            {
                __设备列表.Add(new M设备
                {
                    分类 = __节点.Attribute("分类").Value,
                    名称 = __节点.Attribute("名称").Value,
                    IP = IPAddress.Parse(__节点.Attribute("IP").Value),
                    端口号 = int.Parse(__节点.Attribute("端口号").Value)
                });
            }
            var __分类节点 = new Dictionary<string, TreeNode>();
            __设备列表.ForEach(q =>
            {
                var __node = new TreeNode(q.名称)
                {
                    Tag = q,
                    ToolTipText = string.Format("{0}:{1}", q.IP, q.端口号)
                };
                if (string.IsNullOrEmpty(q.分类))
                {
                    this.out设备列表.Nodes.Add(__node);
                }
                else
                {
                    if (!__分类节点.ContainsKey(q.分类))
                    {
                        __分类节点[q.分类] = this.out设备列表.Nodes.Add(q.分类);
                    }
                    __分类节点[q.分类].Nodes.Add(__node);
                }
            });
            if (__设备列表.Count < 30)
            {
                this.out设备列表.ExpandAll();
            }
        }

        void do编辑设备_Click(object sender, EventArgs e)
        {
            var __文件名 = H路径.获取绝对路径("设备列表.xml");
            try
            {
                var __原内容 = File.ReadAllText(__文件名, Encoding.UTF8);
                Process.Start("notepad.exe", __文件名).WaitForExit();
                var __新内容 = File.ReadAllText(__文件名, Encoding.UTF8);
                if (__原内容 != __新内容)
                {
                    加载设备列表();
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("编辑设备列表出错");
            }
        }

        void TV_MouseDown(object sender, MouseEventArgs e)
        {
            _鼠标位置 = e.Location;
        }

        void out设备菜单_Opening(object sender, CancelEventArgs e)
        {
            var __菜单 = sender as ContextMenuStrip;
            if (__菜单 == null) return;
            var __tv = __菜单.SourceControl as TreeView;
            if (__tv == null) return;

            var __node = __tv.GetNodeAt(_鼠标位置);
            if (__node == null || __node.Tag == null)
            {
                e.Cancel = true;
                return;
            }
            __tv.SelectedNode = __node;
        }

        void do设备_断开_Click(object sender, EventArgs e)
        {
            var __tv = out设备菜单.SourceControl as TreeView;
            var __node = __tv.GetNodeAt(_鼠标位置);
            if (__node == null || __node.Tag == null)
            {
                return;
            }
            var __设备 = __node.Tag as M设备;
            if (__设备.访问入口 == null)
            {
                return;
            }
            __设备.控件.断开();
            __设备.控件.Dispose();
            this.u容器1.删除控件(__设备.控件);
            __设备.控件 = null;
            __设备.访问入口 = null;
            this.out提示.Visible = true;
            显示连接状态(__node, true);
        }

        void out设备列表_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.out提示.Visible = false;
            //加载对象
            var __设备 = e.Node.Tag as M设备;
            if (__设备 == null)
            {
                return;
            }
            if (_当前设备节点 != null)
            {
                _当前设备节点.BackColor = Color.Gainsboro;
            }
            _当前设备节点 = e.Node;
            _当前设备节点.BackColor = Color.Yellow;
            if (__设备.访问入口 == null)
            {
                __设备.控件 = new F模块列表(new IPEndPoint(__设备.IP, __设备.端口号), __设备.名称) { Dock = DockStyle.Fill };
                this.u容器1.添加控件(__设备.控件);

                __设备.访问入口 = __设备.控件.访问入口;
                __设备.访问入口.已断开 += __主动 =>
                {
                    if (!__主动)
                    {
                        显示连接状态(_当前设备节点, false);
                    }
                };
                __设备.访问入口.已连接 += () => 显示连接状态(_当前设备节点, true);
                显示连接状态(_当前设备节点, __设备.访问入口.连接正常);
            }
            else
            {
                this.u容器1.激活控件(__设备.控件);
                if (!__设备.访问入口.连接正常)
                {
                    __设备.控件.连接();
                }
            }
        }

        private void 显示连接状态(TreeNode __节点, bool __正常)
        {
            __节点.ForeColor = __正常 ? Color.Black : Color.Red;
        }

        private class M设备
        {
            public string 名称 { get; set; }
            public string 分类 { get; set; }
            public IPAddress IP { get; set; }
            public int 端口号 { get; set; }
            public IT客户端 访问入口 { get; set; }
            public F模块列表 控件 { get; set; }
        }
    }
}
