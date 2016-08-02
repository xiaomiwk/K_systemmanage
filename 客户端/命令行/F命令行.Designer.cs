using System.Windows.Forms;

namespace 系统管理.客户端
{
    partial class F命令行
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.out命令列表 = new System.Windows.Forms.TreeView();
            this.out执行结果 = new System.Windows.Forms.RichTextBox();
            this.in输入 = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.do编辑 = new Utility.WindowsForm.U按钮();
            this.do导入 = new Utility.WindowsForm.U按钮();
            this.do强制结束 = new Utility.WindowsForm.U按钮();
            this.do滚屏 = new Utility.WindowsForm.U按钮();
            this.label1 = new System.Windows.Forms.Label();
            this.do折叠 = new Utility.WindowsForm.U按钮();
            this.do清空 = new Utility.WindowsForm.U按钮();
            this.do导出 = new Utility.WindowsForm.U按钮();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.do复制 = new System.Windows.Forms.ToolStripMenuItem();
            this.do查询1 = new System.Windows.Forms.ToolStripMenuItem();
            this.in查询 = new System.Windows.Forms.TextBox();
            this.do查询 = new Utility.WindowsForm.U按钮();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // out命令列表
            // 
            this.out命令列表.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out命令列表.HideSelection = false;
            this.out命令列表.Location = new System.Drawing.Point(3, 27);
            this.out命令列表.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.out命令列表.Name = "out命令列表";
            this.out命令列表.ShowNodeToolTips = true;
            this.out命令列表.Size = new System.Drawing.Size(247, 470);
            this.out命令列表.TabIndex = 0;
            // 
            // out执行结果
            // 
            this.out执行结果.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out执行结果.BackColor = System.Drawing.Color.White;
            this.out执行结果.ContextMenuStrip = this.contextMenuStrip1;
            this.out执行结果.Font = new System.Drawing.Font("新宋体", 9F);
            this.out执行结果.Location = new System.Drawing.Point(3, 27);
            this.out执行结果.Name = "out执行结果";
            this.out执行结果.ReadOnly = true;
            this.out执行结果.Size = new System.Drawing.Size(640, 439);
            this.out执行结果.TabIndex = 2;
            this.out执行结果.Text = "";
            // 
            // in输入
            // 
            this.in输入.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.in输入.FormattingEnabled = true;
            this.in输入.Location = new System.Drawing.Point(3, 472);
            this.in输入.Name = "in输入";
            this.in输入.Size = new System.Drawing.Size(640, 25);
            this.in输入.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.do编辑);
            this.splitContainer1.Panel1.Controls.Add(this.do导入);
            this.splitContainer1.Panel1.Controls.Add(this.out命令列表);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.do查询);
            this.splitContainer1.Panel2.Controls.Add(this.in查询);
            this.splitContainer1.Panel2.Controls.Add(this.do强制结束);
            this.splitContainer1.Panel2.Controls.Add(this.do滚屏);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.do折叠);
            this.splitContainer1.Panel2.Controls.Add(this.do清空);
            this.splitContainer1.Panel2.Controls.Add(this.do导出);
            this.splitContainer1.Panel2.Controls.Add(this.out执行结果);
            this.splitContainer1.Panel2.Controls.Add(this.in输入);
            this.splitContainer1.Size = new System.Drawing.Size(900, 500);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(0, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 39;
            this.label2.Text = "常用";
            // 
            // do编辑
            // 
            this.do编辑.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do编辑.BackColor = System.Drawing.Color.White;
            this.do编辑.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.do编辑.FlatAppearance.BorderSize = 0;
            this.do编辑.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do编辑.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do编辑.Location = new System.Drawing.Point(142, 0);
            this.do编辑.Name = "do编辑";
            this.do编辑.Size = new System.Drawing.Size(52, 25);
            this.do编辑.TabIndex = 34;
            this.do编辑.Text = "编辑";
            this.toolTip1.SetToolTip(this.do编辑, "编辑");
            this.do编辑.UseVisualStyleBackColor = false;
            this.do编辑.大小 = new System.Drawing.Size(52, 25);
            this.do编辑.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do编辑.颜色 = System.Drawing.Color.White;
            // 
            // do导入
            // 
            this.do导入.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do导入.BackColor = System.Drawing.Color.White;
            this.do导入.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.do导入.FlatAppearance.BorderSize = 0;
            this.do导入.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do导入.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do导入.Location = new System.Drawing.Point(200, 0);
            this.do导入.Name = "do导入";
            this.do导入.Size = new System.Drawing.Size(50, 25);
            this.do导入.TabIndex = 33;
            this.do导入.Text = "导入";
            this.toolTip1.SetToolTip(this.do导入, "从文件导入");
            this.do导入.UseVisualStyleBackColor = false;
            this.do导入.大小 = new System.Drawing.Size(50, 25);
            this.do导入.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do导入.颜色 = System.Drawing.Color.White;
            // 
            // do强制结束
            // 
            this.do强制结束.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do强制结束.BackColor = System.Drawing.Color.White;
            this.do强制结束.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.do强制结束.FlatAppearance.BorderSize = 0;
            this.do强制结束.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do强制结束.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do强制结束.Location = new System.Drawing.Point(355, 0);
            this.do强制结束.Name = "do强制结束";
            this.do强制结束.Size = new System.Drawing.Size(70, 25);
            this.do强制结束.TabIndex = 41;
            this.do强制结束.Text = "强制结束";
            this.toolTip1.SetToolTip(this.do强制结束, "当命令输出非常耗时或者无限输出，通过该命令结束");
            this.do强制结束.UseVisualStyleBackColor = false;
            this.do强制结束.大小 = new System.Drawing.Size(70, 25);
            this.do强制结束.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do强制结束.颜色 = System.Drawing.Color.White;
            // 
            // do滚屏
            // 
            this.do滚屏.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do滚屏.BackColor = System.Drawing.Color.White;
            this.do滚屏.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.do滚屏.FlatAppearance.BorderSize = 0;
            this.do滚屏.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do滚屏.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do滚屏.Location = new System.Drawing.Point(441, -1);
            this.do滚屏.Name = "do滚屏";
            this.do滚屏.Size = new System.Drawing.Size(70, 25);
            this.do滚屏.TabIndex = 40;
            this.do滚屏.Text = "停止滚屏";
            this.do滚屏.UseVisualStyleBackColor = false;
            this.do滚屏.大小 = new System.Drawing.Size(70, 25);
            this.do滚屏.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do滚屏.颜色 = System.Drawing.Color.White;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 38;
            this.label1.Text = "结果";
            // 
            // do折叠
            // 
            this.do折叠.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do折叠.FlatAppearance.BorderSize = 0;
            this.do折叠.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do折叠.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do折叠.Location = new System.Drawing.Point(0, 233);
            this.do折叠.Name = "do折叠";
            this.do折叠.Size = new System.Drawing.Size(5, 26);
            this.do折叠.TabIndex = 37;
            this.do折叠.UseVisualStyleBackColor = false;
            this.do折叠.大小 = new System.Drawing.Size(5, 26);
            this.do折叠.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do折叠.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // do清空
            // 
            this.do清空.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do清空.BackColor = System.Drawing.Color.White;
            this.do清空.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.do清空.FlatAppearance.BorderSize = 0;
            this.do清空.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do清空.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do清空.Location = new System.Drawing.Point(593, 0);
            this.do清空.Name = "do清空";
            this.do清空.Size = new System.Drawing.Size(50, 25);
            this.do清空.TabIndex = 36;
            this.do清空.Text = "清空";
            this.toolTip1.SetToolTip(this.do清空, "清空");
            this.do清空.UseVisualStyleBackColor = false;
            this.do清空.大小 = new System.Drawing.Size(50, 25);
            this.do清空.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do清空.颜色 = System.Drawing.Color.White;
            // 
            // do导出
            // 
            this.do导出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do导出.BackColor = System.Drawing.Color.White;
            this.do导出.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.do导出.FlatAppearance.BorderSize = 0;
            this.do导出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do导出.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do导出.Location = new System.Drawing.Point(527, 0);
            this.do导出.Name = "do导出";
            this.do导出.Size = new System.Drawing.Size(50, 25);
            this.do导出.TabIndex = 35;
            this.do导出.Text = "导出";
            this.toolTip1.SetToolTip(this.do导出, "导出");
            this.do导出.UseVisualStyleBackColor = false;
            this.do导出.大小 = new System.Drawing.Size(50, 25);
            this.do导出.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do导出.颜色 = System.Drawing.Color.White;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.do复制,
            this.do查询1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // do复制
            // 
            this.do复制.Name = "do复制";
            this.do复制.Size = new System.Drawing.Size(100, 22);
            this.do复制.Text = "复制";
            // 
            // do查询1
            // 
            this.do查询1.Name = "do查询1";
            this.do查询1.Size = new System.Drawing.Size(100, 22);
            this.do查询1.Text = "查询";
            // 
            // in查询
            // 
            this.in查询.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.in查询.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.in查询.Location = new System.Drawing.Point(131, 5);
            this.in查询.Name = "in查询";
            this.in查询.Size = new System.Drawing.Size(148, 16);
            this.in查询.TabIndex = 42;
            // 
            // do查询
            // 
            this.do查询.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do查询.BackColor = System.Drawing.Color.White;
            this.do查询.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.do查询.FlatAppearance.BorderSize = 0;
            this.do查询.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do查询.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do查询.Location = new System.Drawing.Point(287, 0);
            this.do查询.Name = "do查询";
            this.do查询.Size = new System.Drawing.Size(50, 25);
            this.do查询.TabIndex = 43;
            this.do查询.Text = "查询";
            this.toolTip1.SetToolTip(this.do查询, "导出");
            this.do查询.UseVisualStyleBackColor = false;
            this.do查询.大小 = new System.Drawing.Size(50, 25);
            this.do查询.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do查询.颜色 = System.Drawing.Color.White;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(131, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 1);
            this.label3.TabIndex = 44;
            // 
            // F命令行
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F命令行";
            this.Size = new System.Drawing.Size(900, 500);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeView out命令列表;
        private System.Windows.Forms.RichTextBox out执行结果;
        private System.Windows.Forms.ComboBox in输入;
        private SplitContainer splitContainer1;
        private Utility.WindowsForm.U按钮 do编辑;
        private Utility.WindowsForm.U按钮 do导入;
        private Utility.WindowsForm.U按钮 do清空;
        private Utility.WindowsForm.U按钮 do导出;
        private Utility.WindowsForm.U按钮 do折叠;
        private ToolTip toolTip1;
        private Label label1;
        private Label label2;
        private Utility.WindowsForm.U按钮 do滚屏;
        private Utility.WindowsForm.U按钮 do强制结束;
        private Timer timer1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem do复制;
        private ToolStripMenuItem do查询1;
        private Utility.WindowsForm.U按钮 do查询;
        private TextBox in查询;
        private Label label3;
    }
}
