namespace IQPlot
{
    partial class IQPlotForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine11 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine12 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IQPlotForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.iqChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.zoomInBtn = new System.Windows.Forms.Button();
            this.zoomOutBtn = new System.Windows.Forms.Button();
            this.dopplerChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.typeLbl = new System.Windows.Forms.Label();
            this.svidLbl = new System.Windows.Forms.Label();
            this.ingTimeLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.scaleLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.freqLbl = new System.Windows.Forms.Label();
            this.zoomInDopplerBtn = new System.Windows.Forms.Button();
            this.zoomOutDopplerBtn = new System.Windows.Forms.Button();
            this.autoScaleChk = new System.Windows.Forms.CheckBox();
            this.autoChk = new System.Windows.Forms.CheckBox();
            this.clLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cn0Lbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.csLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iqChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dopplerChart)).BeginInit();
            this.SuspendLayout();
            // 
            // iqChart
            // 
            chartArea11.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea11.AxisX.InterlacedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea11.AxisX.Interval = 2500D;
            chartArea11.AxisX.IsLabelAutoFit = false;
            chartArea11.AxisX.IsStartedFromZero = false;
            chartArea11.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea11.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea11.AxisX.Maximum = 10000D;
            chartArea11.AxisX.Minimum = -10000D;
            chartArea11.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.Olive;
            chartArea11.AxisX.ScaleBreakStyle.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
            stripLine11.BackColor = System.Drawing.Color.White;
            stripLine11.BackImageTransparentColor = System.Drawing.Color.White;
            stripLine11.BackSecondaryColor = System.Drawing.Color.White;
            stripLine11.BorderColor = System.Drawing.Color.Black;
            stripLine11.BorderWidth = 3;
            stripLine11.Text = "Q";
            stripLine11.TextAlignment = System.Drawing.StringAlignment.Near;
            stripLine11.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea11.AxisX.StripLines.Add(stripLine11);
            chartArea11.AxisX.TitleFont = new System.Drawing.Font("Segoe Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea11.AxisX.TitleForeColor = System.Drawing.Color.Lime;
            chartArea11.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisX2.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea11.AxisX2.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            chartArea11.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea11.AxisY.Interval = 2500D;
            chartArea11.AxisY.IsLabelAutoFit = false;
            chartArea11.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea11.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea11.AxisY.Maximum = 10000D;
            chartArea11.AxisY.Minimum = -10000D;
            stripLine12.BorderColor = System.Drawing.Color.Black;
            stripLine12.BorderWidth = 3;
            stripLine12.Text = "I";
            chartArea11.AxisY.StripLines.Add(stripLine12);
            chartArea11.AxisY.TitleFont = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea11.AxisY.TitleForeColor = System.Drawing.Color.Red;
            chartArea11.AxisY2.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea11.AxisY2.TitleForeColor = System.Drawing.Color.Yellow;
            chartArea11.Name = "ChartArea1";
            chartArea11.Position.Auto = false;
            chartArea11.Position.Height = 100F;
            chartArea11.Position.Width = 100F;
            this.iqChart.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.iqChart.Legends.Add(legend11);
            this.iqChart.Location = new System.Drawing.Point(7, 110);
            this.iqChart.Name = "iqChart";
            this.iqChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series11.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            series11.IsVisibleInLegend = false;
            series11.Legend = "Legend1";
            series11.MarkerBorderColor = System.Drawing.Color.Aqua;
            series11.MarkerColor = System.Drawing.Color.Transparent;
            series11.MarkerSize = 15;
            series11.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series11.Name = "Series1";
            series11.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series11.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.iqChart.Series.Add(series11);
            this.iqChart.Size = new System.Drawing.Size(550, 550);
            this.iqChart.TabIndex = 1;
            this.iqChart.Text = "chart1";
            // 
            // zoomInBtn
            // 
            this.zoomInBtn.Image = ((System.Drawing.Image)(resources.GetObject("zoomInBtn.Image")));
            this.zoomInBtn.Location = new System.Drawing.Point(7, 6);
            this.zoomInBtn.Name = "zoomInBtn";
            this.zoomInBtn.Size = new System.Drawing.Size(40, 40);
            this.zoomInBtn.TabIndex = 2;
            this.zoomInBtn.UseVisualStyleBackColor = true;
            this.zoomInBtn.Click += new System.EventHandler(this.zoomInBtn_Click);
            // 
            // zoomOutBtn
            // 
            this.zoomOutBtn.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutBtn.Image")));
            this.zoomOutBtn.Location = new System.Drawing.Point(53, 6);
            this.zoomOutBtn.Name = "zoomOutBtn";
            this.zoomOutBtn.Size = new System.Drawing.Size(40, 40);
            this.zoomOutBtn.TabIndex = 2;
            this.zoomOutBtn.UseVisualStyleBackColor = true;
            this.zoomOutBtn.Click += new System.EventHandler(this.zoomOutBtn_Click);
            // 
            // dopplerChart
            // 
            chartArea12.AxisX.LabelStyle.Enabled = false;
            chartArea12.AxisY.IsLabelAutoFit = false;
            chartArea12.AxisY.LabelStyle.Interval = 0D;
            chartArea12.Name = "ChartArea1";
            this.dopplerChart.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.dopplerChart.Legends.Add(legend12);
            this.dopplerChart.Location = new System.Drawing.Point(563, 110);
            this.dopplerChart.Name = "dopplerChart";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series12.IsVisibleInLegend = false;
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            this.dopplerChart.Series.Add(series12);
            this.dopplerChart.Size = new System.Drawing.Size(550, 550);
            this.dopplerChart.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Type";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(160, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "SVID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(283, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Integ. Time / Divider";
            // 
            // typeLbl
            // 
            this.typeLbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.typeLbl.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLbl.ForeColor = System.Drawing.Color.Blue;
            this.typeLbl.Location = new System.Drawing.Point(61, 54);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(90, 20);
            this.typeLbl.TabIndex = 4;
            // 
            // svidLbl
            // 
            this.svidLbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.svidLbl.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.svidLbl.ForeColor = System.Drawing.Color.Blue;
            this.svidLbl.Location = new System.Drawing.Point(210, 54);
            this.svidLbl.Name = "svidLbl";
            this.svidLbl.Size = new System.Drawing.Size(64, 20);
            this.svidLbl.TabIndex = 4;
            // 
            // ingTimeLbl
            // 
            this.ingTimeLbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ingTimeLbl.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ingTimeLbl.ForeColor = System.Drawing.Color.Blue;
            this.ingTimeLbl.Location = new System.Drawing.Point(439, 54);
            this.ingTimeLbl.Name = "ingTimeLbl";
            this.ingTimeLbl.Size = new System.Drawing.Size(64, 20);
            this.ingTimeLbl.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(559, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Scale";
            // 
            // scaleLbl
            // 
            this.scaleLbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scaleLbl.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleLbl.ForeColor = System.Drawing.Color.Blue;
            this.scaleLbl.Location = new System.Drawing.Point(611, 55);
            this.scaleLbl.Name = "scaleLbl";
            this.scaleLbl.Size = new System.Drawing.Size(64, 20);
            this.scaleLbl.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(684, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "Frequency";
            // 
            // freqLbl
            // 
            this.freqLbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.freqLbl.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.freqLbl.ForeColor = System.Drawing.Color.Blue;
            this.freqLbl.Location = new System.Drawing.Point(772, 55);
            this.freqLbl.Name = "freqLbl";
            this.freqLbl.Size = new System.Drawing.Size(64, 20);
            this.freqLbl.TabIndex = 4;
            // 
            // zoomInDopplerBtn
            // 
            this.zoomInDopplerBtn.Image = ((System.Drawing.Image)(resources.GetObject("zoomInDopplerBtn.Image")));
            this.zoomInDopplerBtn.Location = new System.Drawing.Point(563, 12);
            this.zoomInDopplerBtn.Name = "zoomInDopplerBtn";
            this.zoomInDopplerBtn.Size = new System.Drawing.Size(40, 40);
            this.zoomInDopplerBtn.TabIndex = 2;
            this.zoomInDopplerBtn.UseVisualStyleBackColor = true;
            this.zoomInDopplerBtn.Click += new System.EventHandler(this.zoomInDopplerBtn_Click);
            // 
            // zoomOutDopplerBtn
            // 
            this.zoomOutDopplerBtn.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutDopplerBtn.Image")));
            this.zoomOutDopplerBtn.Location = new System.Drawing.Point(609, 12);
            this.zoomOutDopplerBtn.Name = "zoomOutDopplerBtn";
            this.zoomOutDopplerBtn.Size = new System.Drawing.Size(40, 40);
            this.zoomOutDopplerBtn.TabIndex = 2;
            this.zoomOutDopplerBtn.UseVisualStyleBackColor = true;
            this.zoomOutDopplerBtn.Click += new System.EventHandler(this.zoomOutDopplerBtn_Click);
            // 
            // autoScaleChk
            // 
            this.autoScaleChk.Appearance = System.Windows.Forms.Appearance.Button;
            this.autoScaleChk.AutoSize = true;
            this.autoScaleChk.Checked = true;
            this.autoScaleChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScaleChk.Image = ((System.Drawing.Image)(resources.GetObject("autoScaleChk.Image")));
            this.autoScaleChk.Location = new System.Drawing.Point(655, 12);
            this.autoScaleChk.Name = "autoScaleChk";
            this.autoScaleChk.Size = new System.Drawing.Size(40, 40);
            this.autoScaleChk.TabIndex = 5;
            this.autoScaleChk.UseVisualStyleBackColor = true;
            this.autoScaleChk.CheckedChanged += new System.EventHandler(this.autoScaleChk_CheckedChanged);
            // 
            // autoChk
            // 
            this.autoChk.Appearance = System.Windows.Forms.Appearance.Button;
            this.autoChk.AutoSize = true;
            this.autoChk.Checked = true;
            this.autoChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoChk.Image = ((System.Drawing.Image)(resources.GetObject("autoChk.Image")));
            this.autoChk.Location = new System.Drawing.Point(99, 6);
            this.autoChk.Name = "autoChk";
            this.autoChk.Size = new System.Drawing.Size(40, 40);
            this.autoChk.TabIndex = 5;
            this.autoChk.UseVisualStyleBackColor = true;
            this.autoChk.CheckedChanged += new System.EventHandler(this.autoChk_CheckedChanged);
            // 
            // clLbl
            // 
            this.clLbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clLbl.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clLbl.ForeColor = System.Drawing.Color.Blue;
            this.clLbl.Location = new System.Drawing.Point(12, 80);
            this.clLbl.Name = "clLbl";
            this.clLbl.Size = new System.Drawing.Size(90, 20);
            this.clLbl.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(120, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "CN0";
            // 
            // cn0Lbl
            // 
            this.cn0Lbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cn0Lbl.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cn0Lbl.ForeColor = System.Drawing.Color.Blue;
            this.cn0Lbl.Location = new System.Drawing.Point(167, 81);
            this.cn0Lbl.Name = "cn0Lbl";
            this.cn0Lbl.Size = new System.Drawing.Size(64, 20);
            this.cn0Lbl.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(252, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 21);
            this.label10.TabIndex = 4;
            this.label10.Text = "Cycle-Slip";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // csLbl
            // 
            this.csLbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.csLbl.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csLbl.ForeColor = System.Drawing.Color.Blue;
            this.csLbl.Location = new System.Drawing.Point(337, 80);
            this.csLbl.Name = "csLbl";
            this.csLbl.Size = new System.Drawing.Size(64, 20);
            this.csLbl.TabIndex = 4;
            this.csLbl.Click += new System.EventHandler(this.csLbl_Click);
            // 
            // IQPlotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 672);
            this.Controls.Add(this.autoChk);
            this.Controls.Add(this.autoScaleChk);
            this.Controls.Add(this.scaleLbl);
            this.Controls.Add(this.freqLbl);
            this.Controls.Add(this.ingTimeLbl);
            this.Controls.Add(this.csLbl);
            this.Controls.Add(this.cn0Lbl);
            this.Controls.Add(this.svidLbl);
            this.Controls.Add(this.clLbl);
            this.Controls.Add(this.typeLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dopplerChart);
            this.Controls.Add(this.zoomOutDopplerBtn);
            this.Controls.Add(this.zoomOutBtn);
            this.Controls.Add(this.zoomInDopplerBtn);
            this.Controls.Add(this.zoomInBtn);
            this.Controls.Add(this.iqChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "IQPlotForm";
            this.Text = "IQ Plot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IQPlotForm_FormClosing);
            this.Load += new System.EventHandler(this.IQPlotForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iqChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dopplerChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart iqChart;
        private System.Windows.Forms.Button zoomInBtn;
        private System.Windows.Forms.Button zoomOutBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart dopplerChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label typeLbl;
        private System.Windows.Forms.Label svidLbl;
        private System.Windows.Forms.Label ingTimeLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label scaleLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label freqLbl;
        private System.Windows.Forms.Button zoomInDopplerBtn;
        private System.Windows.Forms.Button zoomOutDopplerBtn;
        private System.Windows.Forms.CheckBox autoScaleChk;
        private System.Windows.Forms.CheckBox autoChk;
        private System.Windows.Forms.Label clLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label cn0Lbl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label csLbl;
    }
}

