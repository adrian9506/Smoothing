namespace DataSmoothing
{
    partial class DataChart
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.AddSeriesButton = new System.Windows.Forms.Button();
            this.seriesListView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(270, -2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(619, 563);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // AddSeriesButton
            // 
            this.AddSeriesButton.Location = new System.Drawing.Point(1, 0);
            this.AddSeriesButton.Name = "AddSeriesButton";
            this.AddSeriesButton.Size = new System.Drawing.Size(270, 23);
            this.AddSeriesButton.TabIndex = 2;
            this.AddSeriesButton.Text = "Dodaj serię";
            this.AddSeriesButton.UseVisualStyleBackColor = true;
            this.AddSeriesButton.Click += new System.EventHandler(this.AddSeriesButton_Click);
            // 
            // seriesListView
            // 
            this.seriesListView.HideSelection = false;
            this.seriesListView.Location = new System.Drawing.Point(1, 24);
            this.seriesListView.Name = "seriesListView";
            this.seriesListView.Size = new System.Drawing.Size(270, 537);
            this.seriesListView.TabIndex = 3;
            this.seriesListView.UseCompatibleStateImageBehavior = false;
            // 
            // DataChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.seriesListView);
            this.Controls.Add(this.AddSeriesButton);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DataChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smoother";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button AddSeriesButton;
        private System.Windows.Forms.ListView seriesListView;
    }
}

