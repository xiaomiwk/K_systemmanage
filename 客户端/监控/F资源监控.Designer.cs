namespace 系统管理.客户端
{
    partial class F资源监控
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
            System.Windows.Forms.DataVisualization.Charting.PolylineAnnotation polylineAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.PolylineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.do配置 = new Utility.WindowsForm.U按钮();
            this.label2 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.outCPU占用率 = new System.Windows.Forms.Label();
            this.out内存占用率 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.do配置.Location = new System.Drawing.Point(361, 3);
            this.do配置.Name = "do配置";
            this.do配置.Size = new System.Drawing.Size(52, 25);
            this.do配置.TabIndex = 75;
            this.do配置.Text = "配置";
            this.do配置.UseVisualStyleBackColor = false;
            this.do配置.大小 = new System.Drawing.Size(52, 25);
            this.do配置.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do配置.颜色 = System.Drawing.Color.White;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 74;
            this.label2.Text = "资源";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            polylineAnnotation1.Name = "PolylineAnnotation1";
            this.chart1.Annotations.Add(polylineAnnotation1);
            this.chart1.BorderlineColor = System.Drawing.Color.Gainsboro;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.Maximum = 60D;
            chartArea1.AxisX.Minimum = 1D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 34);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.LegendText = "CPU";
            series1.LegendToolTip = "使用率";
            series1.Name = "CPU";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.LegendText = "内存";
            series2.LegendToolTip = "使用率";
            series2.Name = "内存";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(407, 66);
            this.chart1.TabIndex = 77;
            this.chart1.Text = "chart1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.outCPU占用率);
            this.flowLayoutPanel1.Controls.Add(this.out内存占用率);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(58, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 24);
            this.flowLayoutPanel1.TabIndex = 78;
            // 
            // outCPU占用率
            // 
            this.outCPU占用率.AutoSize = true;
            this.outCPU占用率.ForeColor = System.Drawing.Color.Red;
            this.outCPU占用率.Location = new System.Drawing.Point(3, 0);
            this.outCPU占用率.Name = "outCPU占用率";
            this.outCPU占用率.Size = new System.Drawing.Size(71, 17);
            this.outCPU占用率.TabIndex = 81;
            this.outCPU占用率.Text = "CPU: 100%";
            // 
            // out内存占用率
            // 
            this.out内存占用率.AutoSize = true;
            this.out内存占用率.ForeColor = System.Drawing.Color.Red;
            this.out内存占用率.Location = new System.Drawing.Point(80, 0);
            this.out内存占用率.Name = "out内存占用率";
            this.out内存占用率.Size = new System.Drawing.Size(71, 17);
            this.out内存占用率.TabIndex = 80;
            this.out内存占用率.Text = "内存: 100%";
            // 
            // F资源监控
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.do配置);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F资源监控";
            this.Size = new System.Drawing.Size(416, 103);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Utility.WindowsForm.U按钮 do配置;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label outCPU占用率;
        private System.Windows.Forms.Label out内存占用率;
    }
}
