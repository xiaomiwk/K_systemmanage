namespace 系统管理.客户端
{
    partial class F进程监控_配置
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.in监控频率 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.do确定 = new Utility.WindowsForm.U按钮();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.out列表 = new Utility.WindowsForm.DataGridViewK();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.inCPU阈值 = new System.Windows.Forms.TextBox();
            this.do添加 = new Utility.WindowsForm.U按钮_轻();
            this.in进程名 = new System.Windows.Forms.TextBox();
            this.in内存阈值 = new System.Windows.Forms.TextBox();
            this.in阈值次数 = new System.Windows.Forms.TextBox();
            this.in描述 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.out列表)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(136, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "毫秒/次";
            // 
            // in监控频率
            // 
            this.in监控频率.Location = new System.Drawing.Point(58, 3);
            this.in监控频率.Name = "in监控频率";
            this.in监控频率.Size = new System.Drawing.Size(72, 23);
            this.in监控频率.TabIndex = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "频率";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(3, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "列表";
            // 
            // do确定
            // 
            this.do确定.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do确定.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do确定.FlatAppearance.BorderSize = 0;
            this.do确定.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do确定.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do确定.Location = new System.Drawing.Point(58, 241);
            this.do确定.Name = "do确定";
            this.do确定.Size = new System.Drawing.Size(100, 26);
            this.do确定.TabIndex = 70;
            this.do确定.Text = "确定";
            this.do确定.UseVisualStyleBackColor = false;
            this.do确定.大小 = new System.Drawing.Size(100, 26);
            this.do确定.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do确定.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // out列表
            // 
            this.out列表.AllowUserToAddRows = false;
            this.out列表.AllowUserToDeleteRows = false;
            this.out列表.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.out列表.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.out列表.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.out列表.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.out列表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.out列表.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column2});
            this.out列表.GridColor = System.Drawing.SystemColors.ControlLight;
            this.out列表.Location = new System.Drawing.Point(58, 45);
            this.out列表.Name = "out列表";
            this.out列表.RowHeadersVisible = false;
            this.out列表.RowTemplate.Height = 23;
            this.out列表.Size = new System.Drawing.Size(718, 159);
            this.out列表.TabIndex = 10;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "进程名";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "描述";
            this.Column6.Name = "Column6";
            this.Column6.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "CPU阈值";
            this.Column3.Name = "Column3";
            this.Column3.Width = 90;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "内存阈值(MB)";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "阈值次数";
            this.Column5.Name = "Column5";
            this.Column5.Width = 90;
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // inCPU阈值
            // 
            this.inCPU阈值.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inCPU阈值.Location = new System.Drawing.Point(362, 210);
            this.inCPU阈值.Name = "inCPU阈值";
            this.inCPU阈值.Size = new System.Drawing.Size(84, 23);
            this.inCPU阈值.TabIndex = 30;
            this.toolTip1.SetToolTip(this.inCPU阈值, "CPU阈值，为空表示不告警");
            // 
            // do添加
            // 
            this.do添加.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do添加.BackColor = System.Drawing.Color.White;
            this.do添加.FlatAppearance.BorderSize = 0;
            this.do添加.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do添加.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do添加.Location = new System.Drawing.Point(656, 208);
            this.do添加.Name = "do添加";
            this.do添加.Size = new System.Drawing.Size(78, 26);
            this.do添加.TabIndex = 60;
            this.do添加.Text = "添加";
            this.do添加.UseVisualStyleBackColor = false;
            this.do添加.大小 = new System.Drawing.Size(78, 26);
            this.do添加.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do添加.颜色 = System.Drawing.Color.White;
            // 
            // in进程名
            // 
            this.in进程名.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.in进程名.Location = new System.Drawing.Point(58, 210);
            this.in进程名.Name = "in进程名";
            this.in进程名.Size = new System.Drawing.Size(150, 23);
            this.in进程名.TabIndex = 10;
            this.toolTip1.SetToolTip(this.in进程名, "进程名");
            // 
            // in内存阈值
            // 
            this.in内存阈值.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.in内存阈值.Location = new System.Drawing.Point(452, 210);
            this.in内存阈值.Name = "in内存阈值";
            this.in内存阈值.Size = new System.Drawing.Size(112, 23);
            this.in内存阈值.TabIndex = 40;
            this.toolTip1.SetToolTip(this.in内存阈值, "内存阈值，为空表示不告警");
            // 
            // in阈值次数
            // 
            this.in阈值次数.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.in阈值次数.Location = new System.Drawing.Point(570, 210);
            this.in阈值次数.Name = "in阈值次数";
            this.in阈值次数.Size = new System.Drawing.Size(80, 23);
            this.in阈值次数.TabIndex = 50;
            this.toolTip1.SetToolTip(this.in阈值次数, "阈值次数，为空表示不告警");
            // 
            // in描述
            // 
            this.in描述.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.in描述.Location = new System.Drawing.Point(214, 210);
            this.in描述.Name = "in描述";
            this.in描述.Size = new System.Drawing.Size(142, 23);
            this.in描述.TabIndex = 20;
            this.toolTip1.SetToolTip(this.in描述, "描述");
            // 
            // F进程监控_配置
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.in描述);
            this.Controls.Add(this.in阈值次数);
            this.Controls.Add(this.in内存阈值);
            this.Controls.Add(this.inCPU阈值);
            this.Controls.Add(this.do添加);
            this.Controls.Add(this.in进程名);
            this.Controls.Add(this.do确定);
            this.Controls.Add(this.out列表);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.in监控频率);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F进程监控_配置";
            this.Size = new System.Drawing.Size(782, 270);
            ((System.ComponentModel.ISupportInitialize)(this.out列表)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox in监控频率;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private Utility.WindowsForm.U按钮 do确定;
        private System.Windows.Forms.ToolTip toolTip1;
        private Utility.WindowsForm.DataGridViewK out列表;
        private System.Windows.Forms.TextBox inCPU阈值;
        private Utility.WindowsForm.U按钮_轻 do添加;
        private System.Windows.Forms.TextBox in进程名;
        private System.Windows.Forms.TextBox in内存阈值;
        private System.Windows.Forms.TextBox in阈值次数;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
        private System.Windows.Forms.TextBox in描述;
    }
}
