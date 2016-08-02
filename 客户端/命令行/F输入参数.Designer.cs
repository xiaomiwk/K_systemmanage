namespace 系统管理.客户端
{
    partial class F输入参数
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
            this.in参数列表 = new Utility.WindowsForm.DataGridViewK();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.do确定 = new Utility.WindowsForm.U按钮();
            this.do取消 = new Utility.WindowsForm.U按钮();
            this.do确定并关闭 = new Utility.WindowsForm.U按钮();
            this.out说明 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.in参数列表)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // in参数列表
            // 
            this.in参数列表.AllowUserToAddRows = false;
            this.in参数列表.AllowUserToDeleteRows = false;
            this.in参数列表.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.in参数列表.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.in参数列表.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.in参数列表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.in参数列表.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.in参数列表.Dock = System.Windows.Forms.DockStyle.Fill;
            this.in参数列表.GridColor = System.Drawing.SystemColors.ControlLight;
            this.in参数列表.Location = new System.Drawing.Point(0, 0);
            this.in参数列表.Name = "in参数列表";
            this.in参数列表.RowHeadersVisible = false;
            this.in参数列表.RowTemplate.Height = 23;
            this.in参数列表.Size = new System.Drawing.Size(619, 121);
            this.in参数列表.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "值";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "默认值";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "说明";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 300;
            // 
            // do确定
            // 
            this.do确定.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do确定.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do确定.FlatAppearance.BorderSize = 0;
            this.do确定.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do确定.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do确定.Location = new System.Drawing.Point(109, 248);
            this.do确定.Name = "do确定";
            this.do确定.Size = new System.Drawing.Size(100, 26);
            this.do确定.TabIndex = 1;
            this.do确定.Text = "确定";
            this.do确定.UseVisualStyleBackColor = false;
            this.do确定.大小 = new System.Drawing.Size(100, 26);
            this.do确定.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do确定.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // do取消
            // 
            this.do取消.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do取消.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do取消.FlatAppearance.BorderSize = 0;
            this.do取消.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do取消.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do取消.Location = new System.Drawing.Point(215, 248);
            this.do取消.Name = "do取消";
            this.do取消.Size = new System.Drawing.Size(100, 26);
            this.do取消.TabIndex = 2;
            this.do取消.Text = "取消";
            this.do取消.UseVisualStyleBackColor = false;
            this.do取消.大小 = new System.Drawing.Size(100, 26);
            this.do取消.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do取消.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // do确定并关闭
            // 
            this.do确定并关闭.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do确定并关闭.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do确定并关闭.FlatAppearance.BorderSize = 0;
            this.do确定并关闭.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do确定并关闭.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do确定并关闭.Location = new System.Drawing.Point(3, 248);
            this.do确定并关闭.Name = "do确定并关闭";
            this.do确定并关闭.Size = new System.Drawing.Size(100, 26);
            this.do确定并关闭.TabIndex = 3;
            this.do确定并关闭.Text = "确定并关闭";
            this.do确定并关闭.UseVisualStyleBackColor = false;
            this.do确定并关闭.大小 = new System.Drawing.Size(100, 26);
            this.do确定并关闭.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do确定并关闭.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // out说明
            // 
            this.out说明.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out说明.Location = new System.Drawing.Point(0, 0);
            this.out说明.Multiline = true;
            this.out说明.Name = "out说明";
            this.out说明.Size = new System.Drawing.Size(619, 114);
            this.out说明.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.in参数列表);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.out说明);
            this.splitContainer1.Size = new System.Drawing.Size(619, 239);
            this.splitContainer1.SplitterDistance = 121;
            this.splitContainer1.TabIndex = 5;
            // 
            // F输入参数
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.do确定并关闭);
            this.Controls.Add(this.do取消);
            this.Controls.Add(this.do确定);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F输入参数";
            this.Size = new System.Drawing.Size(625, 278);
            ((System.ComponentModel.ISupportInitialize)(this.in参数列表)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Utility.WindowsForm.DataGridViewK in参数列表;
        private Utility.WindowsForm.U按钮 do确定;
        private Utility.WindowsForm.U按钮 do取消;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private Utility.WindowsForm.U按钮 do确定并关闭;
        private System.Windows.Forms.TextBox out说明;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
