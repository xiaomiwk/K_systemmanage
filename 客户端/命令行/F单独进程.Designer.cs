using System.Windows.Forms;

namespace 系统管理.客户端
{
    partial class F单独进程
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
            this.do滚屏 = new Utility.WindowsForm.U按钮();
            this.do清空 = new Utility.WindowsForm.U按钮();
            this.do导出 = new Utility.WindowsForm.U按钮();
            this.label1 = new System.Windows.Forms.Label();
            this.out执行结果 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // do滚屏
            // 
            this.do滚屏.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do滚屏.BackColor = System.Drawing.Color.White;
            this.do滚屏.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.do滚屏.FlatAppearance.BorderSize = 0;
            this.do滚屏.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do滚屏.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do滚屏.Location = new System.Drawing.Point(580, 0);
            this.do滚屏.Name = "do滚屏";
            this.do滚屏.Size = new System.Drawing.Size(70, 25);
            this.do滚屏.TabIndex = 46;
            this.do滚屏.Text = "停止滚屏";
            this.do滚屏.UseVisualStyleBackColor = false;
            this.do滚屏.大小 = new System.Drawing.Size(70, 25);
            this.do滚屏.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do滚屏.颜色 = System.Drawing.Color.White;
            // 
            // do清空
            // 
            this.do清空.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do清空.BackColor = System.Drawing.Color.White;
            this.do清空.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.do清空.FlatAppearance.BorderSize = 0;
            this.do清空.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do清空.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do清空.Location = new System.Drawing.Point(737, 0);
            this.do清空.Name = "do清空";
            this.do清空.Size = new System.Drawing.Size(50, 25);
            this.do清空.TabIndex = 43;
            this.do清空.Text = "清空";
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
            this.do导出.Location = new System.Drawing.Point(671, 0);
            this.do导出.Name = "do导出";
            this.do导出.Size = new System.Drawing.Size(50, 25);
            this.do导出.TabIndex = 42;
            this.do导出.Text = "导出";
            this.do导出.UseVisualStyleBackColor = false;
            this.do导出.大小 = new System.Drawing.Size(50, 25);
            this.do导出.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do导出.颜色 = System.Drawing.Color.White;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 44;
            this.label1.Text = "输出";
            // 
            // out执行结果
            // 
            this.out执行结果.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out执行结果.BackColor = System.Drawing.Color.White;
            this.out执行结果.Font = new System.Drawing.Font("新宋体", 9F);
            this.out执行结果.Location = new System.Drawing.Point(3, 31);
            this.out执行结果.Name = "out执行结果";
            this.out执行结果.ReadOnly = true;
            this.out执行结果.Size = new System.Drawing.Size(784, 466);
            this.out执行结果.TabIndex = 41;
            this.out执行结果.Text = "";
            // 
            // F单独进程
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.do滚屏);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.do清空);
            this.Controls.Add(this.do导出);
            this.Controls.Add(this.out执行结果);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F单独进程";
            this.Size = new System.Drawing.Size(790, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Utility.WindowsForm.U按钮 do滚屏;
        private Label label1;
        private Utility.WindowsForm.U按钮 do清空;
        private Utility.WindowsForm.U按钮 do导出;
        private RichTextBox out执行结果;
    }
}
