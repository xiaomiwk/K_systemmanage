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
using Utility.存储;
using System.Diagnostics;
using System.IO;

namespace 系统管理.客户端
{
    public partial class FFTP : UserControlK
    {
        BFTP _BFTP;

        IT客户端 _客户端;

        public FFTP(IT客户端 __客户端)
        {
            _客户端 = __客户端;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _BFTP = new BFTP(_客户端);
            _BFTP.开关变化 += _BFTP_状态变化;

            this.in服务器目录.Items.AddRange(new object[] { "c:", "d:", "e:", "f:", "g:", "/home" });
            File.ReadAllLines(H路径.获取绝对路径("默认FTP目录.txt"), Encoding.UTF8).ForEach(q => this.out常用列表.Nodes.Add(q.Replace('\\', '/')));

            this.do开启.Click += Do开启_Click;
            this.do关闭.Click += Do关闭_Click;
            this.do浏览.Click += Do浏览_Click;
            this.do编辑.Click += Do编辑_Click;
            this.out常用列表.NodeMouseDoubleClick += Out常用列表_NodeMouseDoubleClick;
            this.do清空.Click += (sender1, e1) => this.in客户端目录.Clear();

            var __运行中 = _BFTP.运行中;
            this.out状态.Text = __运行中 ? "运行中" : "未启动";
            this.do开启.Enabled = !__运行中;
            this.do关闭.Enabled = __运行中;
            if (__运行中)
            {
                this.in端口.Text = _BFTP.端口号.ToString();
                this.in服务器目录.Text = _BFTP.目录;
            }
            else
            {
                this.in端口.Text = "2121";
            }
        }

        private void Out常用列表_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.in客户端目录.Text = e.Node.Text;
        }

        private void Do浏览_Click(object sender, EventArgs e)
        {
            if (!_BFTP.运行中)
            {
                try
                {
                    this.do开启.PerformClick();
                }
                catch (Exception ex)
                {
                    new F对话框_确定("FTP开启失败!\r\n" + ex.Message).ShowDialog();
                    return;
                }
            }
            var __客户端目录 = this.in客户端目录.Text;
            if (H路径.验证文件是否存在("FlashFXP\\flashfxp.exe"))
            {
                Process.Start("FlashFXP\\flashfxp.exe", string.Format("ftp://{0}:{1}/{2}", _客户端.设备地址.Address, _BFTP.端口号, __客户端目录));
                return;
            }
            Process.Start("explorer.exe", string.Format("ftp://{0}:{1}", _客户端.设备地址.Address, _BFTP.端口号));
        }

        private void _BFTP_状态变化(bool __运行中)
        {
            HUI线程.执行(() =>
            {
                this.out状态.Text = __运行中 ? "运行中" : "未启动";
                if (__运行中)
                {
                    this.in端口.Text = _BFTP.端口号.ToString();
                    this.in服务器目录.Text = _BFTP.目录;
                }
                this.do开启.Enabled = !__运行中;
                this.do关闭.Enabled = __运行中;
            });
        }

        private void Do编辑_Click(object sender, EventArgs e)
        {
            try
            {
                var __文件名 = H路径.获取绝对路径("默认FTP目录.txt");
                var __原内容 = File.ReadAllText(__文件名, Encoding.UTF8);
                Process.Start("notepad.exe", __文件名).WaitForExit();
                var __新内容 = File.ReadAllText(__文件名, Encoding.UTF8);
                if (__原内容 != __新内容)
                {
                    this.out常用列表.Nodes.Clear();
                    File.ReadAllLines(H路径.获取绝对路径("默认FTP目录.txt"), Encoding.UTF8).ForEach(q => this.out常用列表.Nodes.Add(q));
                }
            }
            catch (Exception)
            {
                new F对话框_确定("编辑默认FTP目录出错").ShowDialog();
            }
        }

        private void Do关闭_Click(object sender, EventArgs e)
        {
            _BFTP.关闭();
        }

        private void Do开启_Click(object sender, EventArgs e)
        {
            var __目录 = this.in服务器目录.Text;
            var __端口号 = int.Parse(this.in端口.Text);
            _BFTP.开启(__目录, __端口号);
        }
    }
}
