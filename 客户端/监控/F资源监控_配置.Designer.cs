namespace 系统管理.客户端
{
    partial class F资源监控_配置
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
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.do确定 = new Utility.WindowsForm.U按钮();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.in阈值 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.in频率 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.inCPU阈值 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.in内存阈值 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "阈值次数";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(162, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "次";
            this.toolTip1.SetToolTip(this.label5, "1-10, 通过10次中成功的次数表示当前通断");
            // 
            // do确定
            // 
            this.do确定.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do确定.FlatAppearance.BorderSize = 0;
            this.do确定.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do确定.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do确定.Location = new System.Drawing.Point(82, 163);
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
            this.in阈值.Location = new System.Drawing.Point(82, 121);
            this.in阈值.Name = "in阈值";
            this.in阈值.Size = new System.Drawing.Size(72, 25);
            this.in阈值.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(160, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "毫秒/次";
            // 
            // in频率
            // 
            this.in频率.Location = new System.Drawing.Point(82, 6);
            this.in频率.Name = "in频率";
            this.in频率.Size = new System.Drawing.Size(72, 23);
            this.in频率.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "频率";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(160, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 17);
            this.label8.TabIndex = 27;
            this.label8.Text = "表示使用率，0-100";
            // 
            // inCPU阈值
            // 
            this.inCPU阈值.Location = new System.Drawing.Point(82, 83);
            this.inCPU阈值.Name = "inCPU阈值";
            this.inCPU阈值.Size = new System.Drawing.Size(72, 23);
            this.inCPU阈值.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(3, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "CPU阈值";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(3, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "内存阈值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(160, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "表示使用率，0-100";
            // 
            // in内存阈值
            // 
            this.in内存阈值.Location = new System.Drawing.Point(82, 44);
            this.in内存阈值.Name = "in内存阈值";
            this.in内存阈值.Size = new System.Drawing.Size(72, 23);
            this.in内存阈值.TabIndex = 22;
            // 
            // F资源监控_配置
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.inCPU阈值);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.in内存阈值);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.in频率);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.in阈值);
            this.Controls.Add(this.do确定);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F资源监控_配置";
            this.Size = new System.Drawing.Size(341, 192);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private Utility.WindowsForm.U按钮 do确定;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox in阈值;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox in频率;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox inCPU阈值;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox in内存阈值;
    }
}
