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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.comboBoxDatabase = new System.Windows.Forms.ComboBox();
            this.comboBoxDataset = new System.Windows.Forms.ComboBox();
            this.chartTimeseries = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxGraphInputs = new System.Windows.Forms.GroupBox();
            this.labelDataset = new System.Windows.Forms.Label();
            this.labelDatabase = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeseries)).BeginInit();
            this.groupBoxGraphInputs.SuspendLayout();
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
            this.chartTimeseries.Location = new System.Drawing.Point(0, 45);
            this.chartTimeseries.Name = "chartTimeseries";
            this.chartTimeseries.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTimeseries.Series.Add(series1);
            this.chartTimeseries.Size = new System.Drawing.Size(638, 392);
            this.chartTimeseries.TabIndex = 2;
            this.chartTimeseries.Text = "chart1";
            this.chartTimeseries.Click += new System.EventHandler(this.chart1_Click);
            // 
            // groupBoxGraphInputs
            // 
            this.groupBoxGraphInputs.AutoSize = true;
            this.groupBoxGraphInputs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxGraphInputs.Controls.Add(this.labelDataset);
            this.groupBoxGraphInputs.Controls.Add(this.labelDatabase);
            this.groupBoxGraphInputs.Controls.Add(this.comboBoxDatabase);
            this.groupBoxGraphInputs.Controls.Add(this.comboBoxDataset);
            this.groupBoxGraphInputs.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxGraphInputs.Location = new System.Drawing.Point(0, 0);
            this.groupBoxGraphInputs.MaximumSize = new System.Drawing.Size(400, 45);
            this.groupBoxGraphInputs.MinimumSize = new System.Drawing.Size(400, 45);
            this.groupBoxGraphInputs.Name = "groupBoxGraphInputs";
            this.groupBoxGraphInputs.Size = new System.Drawing.Size(400, 45);
            this.groupBoxGraphInputs.TabIndex = 3;
            this.groupBoxGraphInputs.TabStop = false;
            this.groupBoxGraphInputs.Text = "Data Source";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 437);
            this.Controls.Add(this.groupBoxGraphInputs);
            this.Controls.Add(this.chartTimeseries);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Timeseries Charts";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeseries)).EndInit();
            this.groupBoxGraphInputs.ResumeLayout(false);
            this.groupBoxGraphInputs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox comboBoxDatabase;
    private System.Windows.Forms.ComboBox comboBoxDataset;
    private System.Windows.Forms.DataVisualization.Charting.Chart chartTimeseries;
    private System.Windows.Forms.GroupBox groupBoxGraphInputs;
    private System.Windows.Forms.Label labelDataset;
    private System.Windows.Forms.Label labelDatabase;
  }
}