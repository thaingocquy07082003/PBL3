namespace PBL3_BYME.VIEW
{
    partial class Graphic
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.ChartBDC = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartBDT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ChartBDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartBDT)).BeginInit();
            this.SuspendLayout();
            // 
            // ChartBDC
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartBDC.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartBDC.Legends.Add(legend1);
            this.ChartBDC.Location = new System.Drawing.Point(3, 12);
            this.ChartBDC.Name = "ChartBDC";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "ChartBDC";
            this.ChartBDC.Series.Add(series1);
            this.ChartBDC.Size = new System.Drawing.Size(767, 752);
            this.ChartBDC.TabIndex = 0;
            this.ChartBDC.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.Red;
            title1.Name = "Title1";
            title1.Text = "Biểu đồ doanh thu theo tháng";
            this.ChartBDC.Titles.Add(title1);
            // 
            // ChartBDT
            // 
            chartArea2.Name = "ChartArea1";
            this.ChartBDT.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ChartBDT.Legends.Add(legend2);
            this.ChartBDT.Location = new System.Drawing.Point(769, 12);
            this.ChartBDT.Name = "ChartBDT";
            this.ChartBDT.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "ChartBDT";
            this.ChartBDT.Series.Add(series2);
            this.ChartBDT.Size = new System.Drawing.Size(646, 752);
            this.ChartBDT.TabIndex = 1;
            this.ChartBDT.Text = "chart2";
            title2.DockedToChartArea = "ChartArea1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.ForeColor = System.Drawing.Color.Red;
            title2.Name = "Title1";
            title2.Text = "Biểu đồ thể hiện lượt sử dụng dịch vụ";
            this.ChartBDT.Titles.Add(title2);
            // 
            // Graphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 776);
            this.Controls.Add(this.ChartBDT);
            this.Controls.Add(this.ChartBDC);
            this.Name = "Graphic";
            this.Text = "Graphic";
            ((System.ComponentModel.ISupportInitialize)(this.ChartBDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartBDT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ChartBDC;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartBDT;
    }
}