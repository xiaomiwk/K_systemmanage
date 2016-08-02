using System.Windows.Forms;

namespace 系统管理.客户端
{
    partial class F结束进程
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
            this.do确定 = new Utility.WindowsForm.U按钮();
            this.do取消 = new Utility.WindowsForm.U按钮();
            this.in命令 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 44;
            this.label1.Text = "命令";
            // 
            // do确定
            // 
            this.do确定.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do确定.FlatAppearance.BorderSize = 0;
            this.do确定.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do确定.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do确定.Location = new System.Drawing.Point(100, 96);
            this.do确定.Name = "do确定";
            this.do确定.Size = new System.Drawing.Size(100, 26);
            this.do确定.TabIndex = 48;
            this.do确定.Text = "确定";
            this.do确定.UseVisualStyleBackColor = false;
            this.do确定.大小 = new System.Drawing.Size(100, 26);
            this.do确定.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do确定.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // do取消
            // 
            this.do取消.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do取消.FlatAppearance.BorderSize = 0;
            this.do取消.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do取消.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do取消.Location = new System.Drawing.Point(206, 96);
            this.do取消.Name = "do取消";
            this.do取消.Size = new System.Drawing.Size(100, 26);
            this.do取消.TabIndex = 49;
            this.do取消.Text = "取消";
            this.do取消.UseVisualStyleBackColor = false;
            this.do取消.大小 = new System.Drawing.Size(100, 26);
            this.do取消.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do取消.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // in命令
            // 
            this.in命令.FormattingEnabled = true;
            this.in命令.Location = new System.Drawing.Point(42, 16);
            this.in命令.Name = "in命令";
            this.in命令.Size = new System.Drawing.Size(362, 25);
            this.in命令.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(39, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 34);
            this.label2.TabIndex = 51;
            this.label2.Text = "linux       示例： pkill -f top; \r\nwindows 示例： taskkill /F /T /IM ping.exe";
            // 
            // F结束进程
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.in命令);
            this.Controls.Add(this.do取消);
            this.Controls.Add(this.do确定);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F结束进程";
            this.Size = new System.Drawing.Size(407, 129);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Utility.WindowsForm.U按钮 do确定;
        private Utility.WindowsForm.U按钮 do取消;
        private ComboBox in命令;
        private Label label2;
    }
}
