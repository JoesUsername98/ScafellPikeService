namespace ScaffelPikeClient
{
  partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.comboBoxDatabase = new System.Windows.Forms.ComboBox();
            this.comboBoxDataset = new System.Windows.Forms.ComboBox();
            this.chartQuandl = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxQuandlGraphInputs = new System.Windows.Forms.GroupBox();
            this.labelDataset = new System.Windows.Forms.Label();
            this.labelDatabase = new System.Windows.Forms.Label();
            this.tabControlDataSourceProviders = new System.Windows.Forms.TabControl();
            this.tabPageQuandl = new System.Windows.Forms.TabPage();
            this.tabPageYahoo = new System.Windows.Forms.TabPage();
            this.listViewYahoo = new System.Windows.Forms.ListView();
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHigh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOpen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderClose = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAdjClose = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxYahooGraphInputs = new System.Windows.Forms.GroupBox();
            this.textBoxTickerYahoo = new System.Windows.Forms.TextBox();
            this.buttonGetDataYahoo = new System.Windows.Forms.Button();
            this.dateTimePickerYahooEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerYahooStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelYahooEndDate = new System.Windows.Forms.Label();
            this.labelYahooStartDate = new System.Windows.Forms.Label();
            this.labelTicker = new System.Windows.Forms.Label();
            this.chartYahoo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartQuandl)).BeginInit();
            this.groupBoxQuandlGraphInputs.SuspendLayout();
            this.tabControlDataSourceProviders.SuspendLayout();
            this.tabPageQuandl.SuspendLayout();
            this.tabPageYahoo.SuspendLayout();
            this.groupBoxYahooGraphInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartYahoo)).BeginInit();
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
            // chartQuandl
            // 
            this.chartQuandl.BackColor = System.Drawing.Color.Transparent;
            this.chartQuandl.BorderlineColor = System.Drawing.Color.BlueViolet;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartQuandl.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Name = "Legend1";
            this.chartQuandl.Legends.Add(legend1);
            this.chartQuandl.Location = new System.Drawing.Point(3, 44);
            this.chartQuandl.Name = "chartQuandl";
            this.chartQuandl.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartQuandl.Series.Add(series1);
            this.chartQuandl.Size = new System.Drawing.Size(759, 392);
            this.chartQuandl.TabIndex = 2;
            this.chartQuandl.Text = "chartQuandl";
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
            this.tabControlDataSourceProviders.Size = new System.Drawing.Size(758, 616);
            this.tabControlDataSourceProviders.TabIndex = 4;
            // 
            // tabPageQuandl
            // 
            this.tabPageQuandl.Controls.Add(this.groupBoxQuandlGraphInputs);
            this.tabPageQuandl.Controls.Add(this.chartQuandl);
            this.tabPageQuandl.Location = new System.Drawing.Point(4, 22);
            this.tabPageQuandl.Name = "tabPageQuandl";
            this.tabPageQuandl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuandl.Size = new System.Drawing.Size(750, 590);
            this.tabPageQuandl.TabIndex = 0;
            this.tabPageQuandl.Text = "Quandl";
            this.tabPageQuandl.UseVisualStyleBackColor = true;
            // 
            // tabPageYahoo
            // 
            this.tabPageYahoo.Controls.Add(this.listViewYahoo);
            this.tabPageYahoo.Controls.Add(this.groupBoxYahooGraphInputs);
            this.tabPageYahoo.Controls.Add(this.chartYahoo);
            this.tabPageYahoo.Location = new System.Drawing.Point(4, 22);
            this.tabPageYahoo.Name = "tabPageYahoo";
            this.tabPageYahoo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageYahoo.Size = new System.Drawing.Size(750, 590);
            this.tabPageYahoo.TabIndex = 1;
            this.tabPageYahoo.Text = "Yahoo";
            this.tabPageYahoo.UseVisualStyleBackColor = true;
            // 
            // listViewYahoo
            // 
            this.listViewYahoo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDate,
            this.columnHeaderHigh,
            this.columnHeaderLow,
            this.columnHeaderOpen,
            this.columnHeaderClose,
            this.columnHeaderAdjClose});
            this.listViewYahoo.HideSelection = false;
            this.listViewYahoo.Location = new System.Drawing.Point(168, 485);
            this.listViewYahoo.Name = "listViewYahoo";
            this.listViewYahoo.Size = new System.Drawing.Size(335, 97);
            this.listViewYahoo.TabIndex = 7;
            this.listViewYahoo.UseCompatibleStateImageBehavior = false;
            this.listViewYahoo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Date";
            this.columnHeaderDate.Width = 76;
            // 
            // columnHeaderHigh
            // 
            this.columnHeaderHigh.Text = "High";
            this.columnHeaderHigh.Width = 45;
            // 
            // columnHeaderLow
            // 
            this.columnHeaderLow.Text = "Low";
            this.columnHeaderLow.Width = 44;
            // 
            // columnHeaderOpen
            // 
            this.columnHeaderOpen.Text = "Open";
            this.columnHeaderOpen.Width = 41;
            // 
            // columnHeaderClose
            // 
            this.columnHeaderClose.Text = "Close";
            this.columnHeaderClose.Width = 49;
            // 
            // columnHeaderAdjClose
            // 
            this.columnHeaderAdjClose.Text = "Adj.Close";
            this.columnHeaderAdjClose.Width = 56;
            // 
            // groupBoxYahooGraphInputs
            // 
            this.groupBoxYahooGraphInputs.AutoSize = true;
            this.groupBoxYahooGraphInputs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxYahooGraphInputs.Controls.Add(this.textBoxTickerYahoo);
            this.groupBoxYahooGraphInputs.Controls.Add(this.buttonGetDataYahoo);
            this.groupBoxYahooGraphInputs.Controls.Add(this.dateTimePickerYahooEndDate);
            this.groupBoxYahooGraphInputs.Controls.Add(this.dateTimePickerYahooStartDate);
            this.groupBoxYahooGraphInputs.Controls.Add(this.labelYahooEndDate);
            this.groupBoxYahooGraphInputs.Controls.Add(this.labelYahooStartDate);
            this.groupBoxYahooGraphInputs.Controls.Add(this.labelTicker);
            this.groupBoxYahooGraphInputs.Location = new System.Drawing.Point(3, 3);
            this.groupBoxYahooGraphInputs.MaximumSize = new System.Drawing.Size(160, 45);
            this.groupBoxYahooGraphInputs.MinimumSize = new System.Drawing.Size(740, 45);
            this.groupBoxYahooGraphInputs.Name = "groupBoxYahooGraphInputs";
            this.groupBoxYahooGraphInputs.Size = new System.Drawing.Size(740, 45);
            this.groupBoxYahooGraphInputs.TabIndex = 6;
            this.groupBoxYahooGraphInputs.TabStop = false;
            this.groupBoxYahooGraphInputs.Text = "Data Source";
            // 
            // textBoxTickerYahoo
            // 
            this.textBoxTickerYahoo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxTickerYahoo.Location = new System.Drawing.Point(49, 18);
            this.textBoxTickerYahoo.Name = "textBoxTickerYahoo";
            this.textBoxTickerYahoo.Size = new System.Drawing.Size(126, 20);
            this.textBoxTickerYahoo.TabIndex = 11;
            // 
            // buttonGetDataYahoo
            // 
            this.buttonGetDataYahoo.Location = new System.Drawing.Point(664, 16);
            this.buttonGetDataYahoo.Name = "buttonGetDataYahoo";
            this.buttonGetDataYahoo.Size = new System.Drawing.Size(66, 23);
            this.buttonGetDataYahoo.TabIndex = 10;
            this.buttonGetDataYahoo.Text = "Get Data";
            this.buttonGetDataYahoo.UseVisualStyleBackColor = true;
            this.buttonGetDataYahoo.Click += new System.EventHandler(this.buttonGetDataYahoo_Click);
            // 
            // dateTimePickerYahooEndDate
            // 
            this.dateTimePickerYahooEndDate.AllowDrop = true;
            this.dateTimePickerYahooEndDate.CustomFormat = "\"ddd dd MMM yyyy\"";
            this.dateTimePickerYahooEndDate.Location = new System.Drawing.Point(477, 19);
            this.dateTimePickerYahooEndDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerYahooEndDate.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerYahooEndDate.Name = "dateTimePickerYahooEndDate";
            this.dateTimePickerYahooEndDate.Size = new System.Drawing.Size(179, 20);
            this.dateTimePickerYahooEndDate.TabIndex = 9;
            this.dateTimePickerYahooEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerYahooEndDate_ValueChanged);
            // 
            // dateTimePickerYahooStartDate
            // 
            this.dateTimePickerYahooStartDate.AllowDrop = true;
            this.dateTimePickerYahooStartDate.CustomFormat = "\"ddd dd MMM yyyy\"";
            this.dateTimePickerYahooStartDate.Location = new System.Drawing.Point(239, 19);
            this.dateTimePickerYahooStartDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerYahooStartDate.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerYahooStartDate.Name = "dateTimePickerYahooStartDate";
            this.dateTimePickerYahooStartDate.Size = new System.Drawing.Size(179, 20);
            this.dateTimePickerYahooStartDate.TabIndex = 8;
            this.dateTimePickerYahooStartDate.Value = new System.DateTime(2021, 1, 31, 20, 27, 0, 0);
            this.dateTimePickerYahooStartDate.ValueChanged += new System.EventHandler(this.dateTimePickerYahooStartDate_ValueChanged);
            // 
            // labelYahooEndDate
            // 
            this.labelYahooEndDate.AutoSize = true;
            this.labelYahooEndDate.Location = new System.Drawing.Point(424, 21);
            this.labelYahooEndDate.Name = "labelYahooEndDate";
            this.labelYahooEndDate.Size = new System.Drawing.Size(52, 13);
            this.labelYahooEndDate.TabIndex = 4;
            this.labelYahooEndDate.Text = "End Date";
            // 
            // labelYahooStartDate
            // 
            this.labelYahooStartDate.AutoSize = true;
            this.labelYahooStartDate.Location = new System.Drawing.Point(181, 21);
            this.labelYahooStartDate.Name = "labelYahooStartDate";
            this.labelYahooStartDate.Size = new System.Drawing.Size(55, 13);
            this.labelYahooStartDate.TabIndex = 3;
            this.labelYahooStartDate.Text = "Start Date";
            // 
            // labelTicker
            // 
            this.labelTicker.AutoSize = true;
            this.labelTicker.Location = new System.Drawing.Point(6, 21);
            this.labelTicker.Name = "labelTicker";
            this.labelTicker.Size = new System.Drawing.Size(37, 13);
            this.labelTicker.TabIndex = 2;
            this.labelTicker.Text = "Ticker";
            // 
            // chartYahoo
            // 
            this.chartYahoo.BackColor = System.Drawing.Color.Transparent;
            this.chartYahoo.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chartYahoo.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Name = "Legend1";
            this.chartYahoo.Legends.Add(legend2);
            this.chartYahoo.Location = new System.Drawing.Point(3, 89);
            this.chartYahoo.Name = "chartYahoo";
            this.chartYahoo.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Stock;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 4;
            this.chartYahoo.Series.Add(series2);
            this.chartYahoo.Size = new System.Drawing.Size(744, 392);
            this.chartYahoo.TabIndex = 5;
            this.chartYahoo.Text = "chartYahoo";
            this.chartYahoo.PostPaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.chartYahoo_PostPaint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 616);
            this.Controls.Add(this.tabControlDataSourceProviders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Timeseries Charts";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartQuandl)).EndInit();
            this.groupBoxQuandlGraphInputs.ResumeLayout(false);
            this.groupBoxQuandlGraphInputs.PerformLayout();
            this.tabControlDataSourceProviders.ResumeLayout(false);
            this.tabPageQuandl.ResumeLayout(false);
            this.tabPageQuandl.PerformLayout();
            this.tabPageYahoo.ResumeLayout(false);
            this.tabPageYahoo.PerformLayout();
            this.groupBoxYahooGraphInputs.ResumeLayout(false);
            this.groupBoxYahooGraphInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartYahoo)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox comboBoxDatabase;
    private System.Windows.Forms.ComboBox comboBoxDataset;
    private System.Windows.Forms.DataVisualization.Charting.Chart chartQuandl;
    private System.Windows.Forms.GroupBox groupBoxQuandlGraphInputs;
    private System.Windows.Forms.Label labelDataset;
    private System.Windows.Forms.Label labelDatabase;
    private System.Windows.Forms.TabControl tabControlDataSourceProviders;
    private System.Windows.Forms.TabPage tabPageQuandl;
    private System.Windows.Forms.TabPage tabPageYahoo;
    private System.Windows.Forms.DataVisualization.Charting.Chart chartYahoo;
    private System.Windows.Forms.GroupBox groupBoxYahooGraphInputs;
    private System.Windows.Forms.Label labelTicker;
    private System.Windows.Forms.ListView listViewYahoo;
    private System.Windows.Forms.ColumnHeader columnHeaderDate;
    private System.Windows.Forms.ColumnHeader columnHeaderHigh;
    private System.Windows.Forms.ColumnHeader columnHeaderLow;
    private System.Windows.Forms.ColumnHeader columnHeaderOpen;
    private System.Windows.Forms.ColumnHeader columnHeaderClose;
    private System.Windows.Forms.ColumnHeader columnHeaderAdjClose;
    private System.Windows.Forms.DateTimePicker dateTimePickerYahooEndDate;
    private System.Windows.Forms.DateTimePicker dateTimePickerYahooStartDate;
    private System.Windows.Forms.Label labelYahooEndDate;
    private System.Windows.Forms.Label labelYahooStartDate;
    private System.Windows.Forms.Button buttonGetDataYahoo;
    private System.Windows.Forms.TextBox textBoxTickerYahoo;
  }
}