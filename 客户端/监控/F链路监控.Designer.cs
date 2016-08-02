namespace 系统管理.客户端
{
    partial class F链路监控
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
            this.do配置 = new Utility.WindowsForm.U按钮();
            this.label3 = new System.Windows.Forms.Label();
            this.out列表 = new Utility.WindowsForm.ListViewK();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.out断开数 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.do配置.Location = new System.Drawing.Point(403, 2);
            this.do配置.Name = "do配置";
            this.do配置.Size = new System.Drawing.Size(50, 25);
            this.do配置.TabIndex = 72;
            this.do配置.Text = "配置";
            this.do配置.UseVisualStyleBackColor = false;
            this.do配置.大小 = new System.Drawing.Size(50, 25);
            this.do配置.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do配置.颜色 = System.Drawing.Color.White;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 71;
            this.label3.Text = "链路";
            // 
            // out列表
            // 
            this.out列表.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out列表.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader1,
            this.columnHeader2});
            this.out列表.FullRowSelect = true;
            this.out列表.Location = new System.Drawing.Point(3, 27);
            this.out列表.Name = "out列表";
            this.out列表.ShowItemToolTips = true;
            this.out列表.Size = new System.Drawing.Size(450, 231);
            this.out列表.TabIndex = 70;
            this.out列表.UseCompatibleStateImageBehavior = false;
            this.out列表.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "地址";
            this.columnHeader11.Width = 115;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "通断";
            this.columnHeader12.Width = 39;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "延时(ms)";
            this.columnHeader1.Width = 61;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "描述";
            this.columnHeader2.Width = 197;
            // 
            // out断开数
            // 
            this.out断开数.AutoSize = true;
            this.out断开数.ForeColor = System.Drawing.Color.Red;
            this.out断开数.Location = new System.Drawing.Point(57, 6);
            this.out断开数.Name = "out断开数";
            this.out断开数.Size = new System.Drawing.Size(15, 17);
            this.out断开数.TabIndex = 74;
            this.out断开数.Text = "0";
            // 
            // F链路监控
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.out断开数);
            this.Controls.Add(this.do配置);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.out列表);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F链路监控";
            this.Size = new System.Drawing.Size(456, 261);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utility.WindowsForm.U按钮 do配置;
        private System.Windows.Forms.Label label3;
        private Utility.WindowsForm.ListViewK out列表;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label out断开数;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
