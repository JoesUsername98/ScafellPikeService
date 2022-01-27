namespace ScaffelPikeClient
{
  partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.comboBoxDatabase = new System.Windows.Forms.ComboBox();
            this.comboBoxDataset = new System.Windows.Forms.ComboBox();
            this.chartTimeseries = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxQuandlGraphInputs = new System.Windows.Forms.GroupBox();
            this.labelDataset = new System.Windows.Forms.Label();
            this.labelDatabase = new System.Windows.Forms.Label();
            this.tabControlDataSourceProviders = new System.Windows.Forms.TabControl();
            this.tabPageQuandl = new System.Windows.Forms.TabPage();
            this.tabPageYahoo = new System.Windows.Forms.TabPage();
            this.groupBoxYahooGraphInputs = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeseries)).BeginInit();
            this.groupBoxQuandlGraphInputs.SuspendLayout();
            this.tabControlDataSourceProviders.SuspendLayout();
            this.tabPageQuandl.SuspendLayout();
            this.tabPageYahoo.SuspendLayout();
            this.groupBoxYahooGraphInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxDatabase
            // 
            this.comboBoxDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxDatabase.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxDatabase.FormattingEnabled = true;
            this.comboBoxDatabase.Location = new System.Drawing.Point(65, 18);
            this.comboBoxDatabase.Name = "comboBoxDatabase";
            this.comboBoxDatabase.Size = new System.Drawing.Size(136, 21);
            this.comboBoxDatabase.TabIndex = 0;
            this.comboBoxDatabase.SelectedValueChanged += new System.EventHandler(this.comboBoxDatabase_SelectedValueChanged);
            // 
            // comboBoxDataset
            // 
            this.comboBoxDataset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDataset.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxDataset.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxDataset.Enabled = false;
            this.comboBoxDataset.FormattingEnabled = true;
            this.comboBoxDataset.Location = new System.Drawing.Point(257, 18);
            this.comboBoxDataset.Name = "comboBoxDataset";
            this.comboBoxDataset.Size = new System.Drawing.Size(137, 21);
            this.comboBoxDataset.TabIndex = 1;
            this.comboBoxDataset.SelectedValueChanged += new System.EventHandler(this.comboBoxDataset_SelectedValueChanged);
            // 
            // chartTimeseries
            // 
            this.chartTimeseries.BackColor = System.Drawing.Color.Transparent;
            this.chartTimeseries.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartTimeseries.ChartAreas.Add(chartArea1);
            this.chartTimeseries.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Name = "Legend1";
            this.chartTimeseries.Legends.Add(legend1);
            this.chartTimeseries.Location = new System.Drawing.Point(3, 44);
            this.chartTimeseries.Name = "chartTimeseries";
            this.chartTimeseries.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTimeseries.Series.Add(series1);
            this.chartTimeseries.Size = new System.Drawing.Size(759, 392);
            this.chartTimeseries.TabIndex = 2;
            this.chartTimeseries.Text = "chartQuandl";
            this.chartTimeseries.Click += new System.EventHandler(this.chart1_Click);
            // 
            // groupBoxQuandlGraphInputs
            // 
            this.groupBoxQuandlGraphInputs.AutoSize = true;
            this.groupBoxQuandlGraphInputs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxQuandlGraphInputs.Controls.Add(this.labelDataset);
            this.groupBoxQuandlGraphInputs.Controls.Add(this.labelDatabase);
            this.groupBoxQuandlGraphInputs.Controls.Add(this.comboBoxDatabase);
            this.groupBoxQuandlGraphInputs.Controls.Add(this.comboBoxDataset);
            this.groupBoxQuandlGraphInputs.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxQuandlGraphInputs.Location = new System.Drawing.Point(3, 3);
            this.groupBoxQuandlGraphInputs.MaximumSize = new System.Drawing.Size(400, 45);
            this.groupBoxQuandlGraphInputs.MinimumSize = new System.Drawing.Size(400, 45);
            this.groupBoxQuandlGraphInputs.Name = "groupBoxQuandlGraphInputs";
            this.groupBoxQuandlGraphInputs.Size = new System.Drawing.Size(400, 45);
            this.groupBoxQuandlGraphInputs.TabIndex = 3;
            this.groupBoxQuandlGraphInputs.TabStop = false;
            this.groupBoxQuandlGraphInputs.Text = "Data Source";
            // 
            // labelDataset
            // 
            this.labelDataset.AutoSize = true;
            this.labelDataset.Location = new System.Drawing.Point(207, 21);
            this.labelDataset.Name = "labelDataset";
            this.labelDataset.Size = new System.Drawing.Size(44, 13);
            this.labelDataset.TabIndex = 3;
            this.labelDataset.Text = "Dataset";
            // 
            // labelDatabase
            // 
            this.labelDatabase.AutoSize = true;
            this.labelDatabase.Location = new System.Drawing.Point(6, 21);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(53, 13);
            this.labelDatabase.TabIndex = 2;
            this.labelDatabase.Text = "Database";
            // 
            // tabControlDataSourceProviders
            // 
            this.tabControlDataSourceProviders.Controls.Add(this.tabPageQuandl);
            this.tabControlDataSourceProviders.Controls.Add(this.tabPageYahoo);
            this.tabControlDataSourceProviders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDataSourceProviders.Location = new System.Drawing.Point(0, 0);
            this.tabControlDataSourceProviders.Name = "tabControlDataSourceProviders";
            this.tabControlDataSourceProviders.SelectedIndex = 0;
            this.tabControlDataSourceProviders.Size = new System.Drawing.Size(773, 465);
            this.tabControlDataSourceProviders.TabIndex = 4;
            // 
            // tabPageQuandl
            // 
            this.tabPageQuandl.Controls.Add(this.groupBoxQuandlGraphInputs);
            this.tabPageQuandl.Controls.Add(this.chartTimeseries);
            this.tabPageQuandl.Location = new System.Drawing.Point(4, 22);
            this.tabPageQuandl.Name = "tabPageQuandl";
            this.tabPageQuandl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuandl.Size = new System.Drawing.Size(765, 439);
            this.tabPageQuandl.TabIndex = 0;
            this.tabPageQuandl.Text = "Quandl";
            this.tabPageQuandl.UseVisualStyleBackColor = true;
            // 
            // tabPageYahoo
            // 
            this.tabPageYahoo.Controls.Add(this.groupBoxYahooGraphInputs);
            this.tabPageYahoo.Controls.Add(this.chart1);
            this.tabPageYahoo.Location = new System.Drawing.Point(4, 22);
            this.tabPageYahoo.Name = "tabPageYahoo";
            this.tabPageYahoo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageYahoo.Size = new System.Drawing.Size(765, 439);
            this.tabPageYahoo.TabIndex = 1;
            this.tabPageYahoo.Text = "Yahoo";
            this.tabPageYahoo.UseVisualStyleBackColor = true;
            // 
            // groupBoxYahooGraphInputs
            // 
            this.groupBoxYahooGraphInputs.AutoSize = true;
            this.groupBoxYahooGraphInputs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxYahooGraphInputs.Controls.Add(this.label1);
            this.groupBoxYahooGraphInputs.Controls.Add(this.label2);
            this.groupBoxYahooGraphInputs.Controls.Add(this.comboBox1);
            this.groupBoxYahooGraphInputs.Controls.Add(this.comboBox2);
            this.groupBoxYahooGraphInputs.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxYahooGraphInputs.Location = new System.Drawing.Point(3, 3);
            this.groupBoxYahooGraphInputs.MaximumSize = new System.Drawing.Size(400, 45);
            this.groupBoxYahooGraphInputs.MinimumSize = new System.Drawing.Size(400, 45);
            this.groupBoxYahooGraphInputs.Name = "groupBoxYahooGraphInputs";
            this.groupBoxYahooGraphInputs.Size = new System.Drawing.Size(400, 45);
            this.groupBoxYahooGraphInputs.TabIndex = 6;
            this.groupBoxYahooGraphInputs.TabStop = false;
            this.groupBoxYahooGraphInputs.Text = "Data Source";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dataset";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(65, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(257, 18);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(137, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(3, 44);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(759, 392);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chartYahoo";
            this.chart1.Click += new System.EventHandler(this.chart1_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 465);
            this.Controls.Add(this.tabControlDataSourceProviders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Timeseries Charts";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeseries)).EndInit();
            this.groupBoxQuandlGraphInputs.ResumeLayout(false);
            this.groupBoxQuandlGraphInputs.PerformLayout();
            this.tabControlDataSourceProviders.ResumeLayout(false);
            this.tabPageQuandl.ResumeLayout(false);
            this.tabPageQuandl.PerformLayout();
            this.tabPageYahoo.ResumeLayout(false);
            this.tabPageYahoo.PerformLayout();
            this.groupBoxYahooGraphInputs.ResumeLayout(false);
            this.groupBoxYahooGraphInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox comboBoxDatabase;
    private System.Windows.Forms.ComboBox comboBoxDataset;
    private System.Windows.Forms.DataVisualization.Charting.Chart chartTimeseries;
    private System.Windows.Forms.GroupBox groupBoxQuandlGraphInputs;
    private System.Windows.Forms.Label labelDataset;
    private System.Windows.Forms.Label labelDatabase;
    private System.Windows.Forms.TabControl tabControlDataSourceProviders;
    private System.Windows.Forms.TabPage tabPageQuandl;
    private System.Windows.Forms.TabPage tabPageYahoo;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    private System.Windows.Forms.GroupBox groupBoxYahooGraphInputs;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.ComboBox comboBox2;
  }
}