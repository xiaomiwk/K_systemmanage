namespace 系统管理.客户端
{
    partial class F监控主界面
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.out资源 = new System.Windows.Forms.Panel();
            this.out进程 = new System.Windows.Forms.Panel();
            this.do向下折叠 = new Utility.WindowsForm.U按钮();
            this.out链路 = new System.Windows.Forms.Panel();
            this.do清空 = new Utility.WindowsForm.U按钮();
            this.do向上折叠 = new Utility.WindowsForm.U按钮();
            this.label1 = new System.Windows.Forms.Label();
            this.out告警记录 = new Utility.WindowsForm.ListViewK();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.out进程.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.do清空);
            this.splitContainer1.Panel2.Controls.Add(this.do向上折叠);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.out告警记录);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 500);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.TabIndex = 38;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.88889F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.11111F));
            this.tableLayoutPanel1.Controls.Add(this.out资源, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.out进程, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.out链路, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.23077F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.76923F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 312);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // out资源
            // 
            this.out资源.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out资源.Location = new System.Drawing.Point(0, 0);
            this.out资源.Margin = new System.Windows.Forms.Padding(0);
            this.out资源.Name = "out资源";
            this.out资源.Size = new System.Drawing.Size(718, 138);
            this.out资源.TabIndex = 0;
            // 
            // out进程
            // 
            this.out进程.Controls.Add(this.do向下折叠);
            this.out进程.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out进程.Location = new System.Drawing.Point(0, 138);
            this.out进程.Margin = new System.Windows.Forms.Padding(0);
            this.out进程.Name = "out进程";
            this.out进程.Size = new System.Drawing.Size(718, 174);
            this.out进程.TabIndex = 1;
            // 
            // do向下折叠
            // 
            this.do向下折叠.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do向下折叠.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do向下折叠.FlatAppearance.BorderSize = 0;
            this.do向下折叠.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do向下折叠.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do向下折叠.Location = new System.Drawing.Point(418, 168);
            this.do向下折叠.Name = "do向下折叠";
            this.do向下折叠.Size = new System.Drawing.Size(26, 5);
            this.do向下折叠.TabIndex = 42;
            this.toolTip1.SetToolTip(this.do向下折叠, "显示/隐藏告警记录");
            this.do向下折叠.UseVisualStyleBackColor = false;
            this.do向下折叠.大小 = new System.Drawing.Size(26, 5);
            this.do向下折叠.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do向下折叠.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // out链路
            // 
            this.out链路.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out链路.Location = new System.Drawing.Point(718, 0);
            this.out链路.Margin = new System.Windows.Forms.Padding(0);
            this.out链路.Name = "out链路";
            this.tableLayoutPanel1.SetRowSpan(this.out链路, 2);
            this.out链路.Size = new System.Drawing.Size(282, 312);
            this.out链路.TabIndex = 2;
            // 
            // do清空
            // 
            this.do清空.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do清空.BackColor = System.Drawing.Color.White;
            this.do清空.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.do清空.FlatAppearance.BorderSize = 0;
            this.do清空.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do清空.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do清空.Location = new System.Drawing.Point(945, 1);
            this.do清空.Name = "do清空";
            this.do清空.Size = new System.Drawing.Size(52, 25);
            this.do清空.TabIndex = 68;
            this.do清空.Text = "清空";
            this.toolTip1.SetToolTip(this.do清空, "清空界面上的告警记录，另外界面只会显示最近的1000条记录");
            this.do清空.UseVisualStyleBackColor = false;
            this.do清空.大小 = new System.Drawing.Size(52, 25);
            this.do清空.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do清空.颜色 = System.Drawing.Color.White;
            // 
            // do向上折叠
            // 
            this.do向上折叠.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do向上折叠.FlatAppearance.BorderSize = 0;
            this.do向上折叠.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do向上折叠.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do向上折叠.Location = new System.Drawing.Point(418, 0);
            this.do向上折叠.Name = "do向上折叠";
            this.do向上折叠.Size = new System.Drawing.Size(26, 5);
            this.do向上折叠.TabIndex = 41;
            this.toolTip1.SetToolTip(this.do向上折叠, "显示/隐藏CPU等");
            this.do向上折叠.UseVisualStyleBackColor = false;
            this.do向上折叠.大小 = new System.Drawing.Size(26, 5);
            this.do向上折叠.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do向上折叠.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 40;
            this.label1.Text = "告警记录";
            // 
            // out告警记录
            // 
            this.out告警记录.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out告警记录.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.out告警记录.FullRowSelect = true;
            this.out告警记录.Location = new System.Drawing.Point(3, 29);
            this.out告警记录.Name = "out告警记录";
            this.out告警记录.ShowItemToolTips = true;
            this.out告警记录.Size = new System.Drawing.Size(994, 152);
            this.out告警记录.TabIndex = 39;
            this.out告警记录.UseCompatibleStateImageBehavior = false;
            this.out告警记录.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 153;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "类别";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "事件";
            this.columnHeader3.Width = 708;
            // 
            // F监控主界面
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F监控主界面";
            this.Size = new System.Drawing.Size(1000, 500);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.out进程.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private Utility.WindowsForm.ListViewK out告警记录;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Utility.WindowsForm.U按钮 do向上折叠;
        private Utility.WindowsForm.U按钮 do向下折叠;
        private Utility.WindowsForm.U按钮 do清空;
        private System.Windows.Forms.Panel out资源;
        private System.Windows.Forms.Panel out进程;
        private System.Windows.Forms.Panel out链路;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
