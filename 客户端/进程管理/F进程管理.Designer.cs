namespace 系统管理.客户端
{
    partial class F进程管理
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
            this.label1 = new System.Windows.Forms.Label();
            this.do刷新 = new Utility.WindowsForm.U按钮();
            this.out列表 = new Utility.WindowsForm.ListViewK();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "进程列表";
            // 
            // do刷新
            // 
            this.do刷新.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do刷新.BackColor = System.Drawing.Color.White;
            this.do刷新.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.do刷新.FlatAppearance.BorderSize = 0;
            this.do刷新.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do刷新.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do刷新.Location = new System.Drawing.Point(917, 0);
            this.do刷新.Name = "do刷新";
            this.do刷新.Size = new System.Drawing.Size(80, 25);
            this.do刷新.TabIndex = 40;
            this.do刷新.Text = "停止刷新";
            this.do刷新.UseVisualStyleBackColor = false;
            this.do刷新.大小 = new System.Drawing.Size(80, 25);
            this.do刷新.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do刷新.颜色 = System.Drawing.Color.White;
            // 
            // out列表
            // 
            this.out列表.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out列表.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8});
            this.out列表.FullRowSelect = true;
            this.out列表.HideSelection = false;
            this.out列表.Location = new System.Drawing.Point(3, 25);
            this.out列表.MultiSelect = false;
            this.out列表.Name = "out列表";
            this.out列表.ShowItemToolTips = true;
            this.out列表.Size = new System.Drawing.Size(994, 472);
            this.out列表.TabIndex = 41;
            this.out列表.UseCompatibleStateImageBehavior = false;
            this.out列表.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PID";
            this.columnHeader2.Width = 67;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 226;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "CPU";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "内存(KB)";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 85;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "路径";
            this.columnHeader8.Width = 425;
            // 
            // F进程管理
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.do刷新);
            this.Controls.Add(this.out列表);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F进程管理";
            this.Size = new System.Drawing.Size(1000, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Utility.WindowsForm.U按钮 do刷新;
        private Utility.WindowsForm.ListViewK out列表;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}
