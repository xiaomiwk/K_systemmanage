namespace 系统管理.客户端
{
    partial class F链路监控_配置
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.in超时 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.in频率 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.out地址列表 = new Utility.WindowsForm.DataGridViewK();
            this.do确定 = new Utility.WindowsForm.U按钮();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.in阈值 = new System.Windows.Forms.ComboBox();
            this.do添加 = new Utility.WindowsForm.U按钮_轻();
            this.in地址 = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.in描述 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.out地址列表)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "超时";
            // 
            // in超时
            // 
            this.in超时.Location = new System.Drawing.Point(82, 4);
            this.in超时.Name = "in超时";
            this.in超时.Size = new System.Drawing.Size(72, 23);
            this.in超时.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(160, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "毫秒";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(160, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "毫秒/次";
            // 
            // in频率
            // 
            this.in频率.Location = new System.Drawing.Point(82, 42);
            this.in频率.Name = "in频率";
            this.in频率.Size = new System.Drawing.Size(72, 23);
            this.in频率.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(3, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "频率";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(160, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "次";
            this.toolTip1.SetToolTip(this.label5, "1-10, 通过10次中成功的次数表示当前通断");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(3, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "阈值";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(3, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "地址";
            // 
            // out地址列表
            // 
            this.out地址列表.AllowUserToAddRows = false;
            this.out地址列表.AllowUserToDeleteRows = false;
            this.out地址列表.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.out地址列表.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.out地址列表.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.out地址列表.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.out地址列表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.out地址列表.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2});
            this.out地址列表.GridColor = System.Drawing.SystemColors.ControlLight;
            this.out地址列表.Location = new System.Drawing.Point(82, 123);
            this.out地址列表.Name = "out地址列表";
            this.out地址列表.RowHeadersVisible = false;
            this.out地址列表.RowTemplate.Height = 23;
            this.out地址列表.Size = new System.Drawing.Size(478, 265);
            this.out地址列表.TabIndex = 10;
            // 
            // do确定
            // 
            this.do确定.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do确定.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do确定.FlatAppearance.BorderSize = 0;
            this.do确定.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do确定.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do确定.Location = new System.Drawing.Point(82, 425);
            this.do确定.Name = "do确定";
            this.do确定.Size = new System.Drawing.Size(100, 26);
            this.do确定.TabIndex = 11;
            this.do确定.Text = "确定";
            this.do确定.UseVisualStyleBackColor = false;
            this.do确定.大小 = new System.Drawing.Size(100, 26);
            this.do确定.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do确定.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // in阈值
            // 
            this.in阈值.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.in阈值.FormattingEnabled = true;
            this.in阈值.Location = new System.Drawing.Point(82, 79);
            this.in阈值.Name = "in阈值";
            this.in阈值.Size = new System.Drawing.Size(72, 25);
            this.in阈值.TabIndex = 12;
            // 
            // do添加
            // 
            this.do添加.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do添加.BackColor = System.Drawing.Color.White;
            this.do添加.FlatAppearance.BorderSize = 0;
            this.do添加.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do添加.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do添加.Location = new System.Drawing.Point(444, 392);
            this.do添加.Name = "do添加";
            this.do添加.Size = new System.Drawing.Size(78, 26);
            this.do添加.TabIndex = 16;
            this.do添加.Text = "添加";
            this.do添加.UseVisualStyleBackColor = false;
            this.do添加.大小 = new System.Drawing.Size(78, 26);
            this.do添加.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do添加.颜色 = System.Drawing.Color.White;
            // 
            // in地址
            // 
            this.in地址.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.in地址.Location = new System.Drawing.Point(82, 394);
            this.in地址.Name = "in地址";
            this.in地址.Size = new System.Drawing.Size(150, 23);
            this.in地址.TabIndex = 15;
            this.toolTip1.SetToolTip(this.in地址, "地址");
            // 
            // Column1
            // 
            this.Column1.HeaderText = "地址";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "描述";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column2
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // in描述
            // 
            this.in描述.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.in描述.Location = new System.Drawing.Point(238, 395);
            this.in描述.Name = "in描述";
            this.in描述.Size = new System.Drawing.Size(200, 23);
            this.in描述.TabIndex = 17;
            this.toolTip1.SetToolTip(this.in描述, "描述");
            // 
            // F链路监控_配置
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.in描述);
            this.Controls.Add(this.do添加);
            this.Controls.Add(this.in地址);
            this.Controls.Add(this.in阈值);
            this.Controls.Add(this.do确定);
            this.Controls.Add(this.out地址列表);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.in频率);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.in超时);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F链路监控_配置";
            this.Size = new System.Drawing.Size(563, 454);
            ((System.ComponentModel.ISupportInitialize)(this.out地址列表)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox in超时;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox in频率;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Utility.WindowsForm.DataGridViewK out地址列表;
        private Utility.WindowsForm.U按钮 do确定;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox in阈值;
        private Utility.WindowsForm.U按钮_轻 do添加;
        private System.Windows.Forms.TextBox in地址;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
        private System.Windows.Forms.TextBox in描述;
    }
}
