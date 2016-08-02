namespace 系统管理.客户端
{
    partial class F进程监控
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
            this.do配置 = new Utility.WindowsForm.U按钮();
            this.out列表 = new Utility.WindowsForm.ListViewK();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // do配置
            // 
            this.do配置.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do配置.BackColor = System.Drawing.Color.White;
            this.do配置.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.do配置.FlatAppearance.BorderSize = 0;
            this.do配置.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do配置.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do配置.Location = new System.Drawing.Point(583, 1);
            this.do配置.Name = "do配置";
            this.do配置.Size = new System.Drawing.Size(52, 25);
            this.do配置.TabIndex = 74;
            this.do配置.Text = "配置";
            this.do配置.UseVisualStyleBackColor = false;
            this.do配置.大小 = new System.Drawing.Size(52, 25);
            this.do配置.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do配置.颜色 = System.Drawing.Color.White;
            // 
            // out列表
            // 
            this.out列表.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out列表.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2});
            this.out列表.FullRowSelect = true;
            this.out列表.Location = new System.Drawing.Point(6, 27);
            this.out列表.MultiSelect = false;
            this.out列表.Name = "out列表";
            this.out列表.ShowItemToolTips = true;
            this.out列表.Size = new System.Drawing.Size(631, 118);
            this.out列表.TabIndex = 73;
            this.out列表.UseCompatibleStateImageBehavior = false;
            this.out列表.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "PID";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "名称";
            this.columnHeader5.Width = 148;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "描述";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "CPU";
            this.columnHeader8.Width = 50;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "内存(KB)";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader9.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "线程数";
            this.columnHeader4.Width = 50;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "启动时间";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "路径";
            this.columnHeader2.Width = 180;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 72;
            this.label4.Text = "进程";
            // 
            // F进程监控
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.do配置);
            this.Controls.Add(this.out列表);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F进程监控";
            this.Size = new System.Drawing.Size(637, 148);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Utility.WindowsForm.U按钮 do配置;
        private Utility.WindowsForm.ListViewK out列表;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
