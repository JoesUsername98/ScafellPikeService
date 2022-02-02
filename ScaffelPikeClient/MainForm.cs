using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ScaffelPikeContracts.Quandl;
using ScaffelPikeContracts.Yahoo;
using static System.Windows.Forms.ListViewItem;

namespace ScaffelPikeClient
{
  public partial class MainForm : Form
  {
    #region Quandl Properties
    private List<QuandlDatabaseResponse> QuandlDatabases { get; set; }
    private QuandlDatabaseResponse QuandlDatabaseSelected { get; set; }
    private List<QuandlDatasetResponse> QuandlDatasets { get; set; }
    private QuandlDatasetResponse QuandlDatasetSelected { get; set; }
    private QuandlTimeseriesDataResponse QuandlTimeseriesData { get; set; }
    #endregion
    #region Yahoo Properties
    private List<string> YahooTickers { get; set; }
    private YahooSecurityResponse YahooSecurityMeta { get; set; }
    private List<YahooCandleResponse> YahooCandlesData { get; set; }
    private bool Updating { get; set; }
    private string TickerName { get; set; }
    #endregion
    public MainForm()
    {
      InitializeComponent();
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
      Updating = true;
      try
      {
        QuandlDatabases = await ClientRefs.ScaffelPikeChannel.GetQuandlDbs();
        YahooTickers = await ClientRefs.ScaffelPikeChannel.GetYahooTickers();
        comboBoxDatabase.Items.AddRange(QuandlDatabases.Select(db => db.Code).ToArray());
        comboBoxTicker.Items.AddRange(YahooTickers.ToArray());
      }
      catch (Exception ex)
      {
        ClientRefs.Log.Error("MainForm_Load", ex);
      }

      dateTimePickerYahooStartDate.Value = DateTime.Now.AddYears(-1);
      dateTimePickerYahooEndDate.Value = DateTime.Now;
      Updating = false;
    }

    #region Quandl
    private async void comboBoxDatabase_SelectedValueChanged(object sender, EventArgs e)
    {
      comboBoxDataset.Items.Clear();
      comboBoxDataset.ResetText();
      comboBoxDataset.Enabled = true;

      var dbCodeToUse = (string)comboBoxDatabase.SelectedItem;
      QuandlDatabaseSelected = QuandlDatabases.FirstOrDefault(db => db.Code == dbCodeToUse);

      try
      {
        QuandlDatasets = await ClientRefs.ScaffelPikeChannel.GetQuandlDataSets(dbCodeToUse);
        comboBoxDataset.Items.AddRange(QuandlDatasets.Select(ds => ds.Code).ToArray());
      }
      catch (Exception ex)
      {
        ClientRefs.Log.Error("comboBoxDatabase_SelectedValueChanged", ex);
      }
    }

    private async void comboBoxDataset_SelectedValueChanged(object sender, EventArgs e)
    {
      var dbCodeToUse = (string)comboBoxDatabase.SelectedItem;
      var dsCodeToUse = (string)comboBoxDataset.SelectedItem;
      QuandlDatasetSelected = QuandlDatasets.FirstOrDefault(ds => ds.Code == dsCodeToUse);

      try
      {
        QuandlTimeseriesData = await ClientRefs.ScaffelPikeChannel.GetQuandlTimeseries(dbCodeToUse, dsCodeToUse);
        PlotChartQuandl();
      }
      catch (Exception ex)
      {
        ClientRefs.Log.Error("comboBoxDataset_SelectedValueChanged", ex);
      }
    }

    private void PlotChartQuandl()
    {
      chartQuandl.ChartAreas.Clear();
      chartQuandl.Series.Clear();
      chartQuandl.Titles.Clear();

      chartQuandl.Titles.Add(QuandlDatasetSelected.Name);
      chartQuandl.Titles[0].Visible = true;

      var priceChartArea = chartQuandl.ChartAreas.Add("Prices");
      priceChartArea.InnerPlotPosition = new ElementPosition(5, 0, 99, 140);
      priceChartArea.AxisX.CustomLabels.Add(new CustomLabel());//Hide x axis
      var volumeChartArea = chartQuandl.ChartAreas.Add("Volume");
      volumeChartArea.InnerPlotPosition = new ElementPosition(5, 50, 99, 30);

      for (int i = 1; i < QuandlTimeseriesData.Data[0].Length; i++) //For each column
      {
        string seriesName = QuandlTimeseriesData.ColumnNames[i];
        var series = new Series(seriesName);
        series.ChartType = seriesName.ToLower().Equals("volume") ? SeriesChartType.Area : SeriesChartType.Line;
        series.XValueType = ChartValueType.DateTime;
        series.YValueType = ChartValueType.Double;

        foreach (var line in QuandlTimeseriesData.Data.Where(l => l[0] != null)) //For each row
        {
          double yValue = line[i] == null ? 0 : (double)line[i];
          series.Points.AddXY(DateTime.Parse((string)line[0]), yValue);
        }

        series.ChartArea = seriesName.ToLower().Equals("volume") ? volumeChartArea.Name : priceChartArea.Name;

        chartQuandl.Series.Add(series);
      }
      chartQuandl.Show();
      foreach (var ca in chartQuandl.ChartAreas) { ca.BackColor = Color.Transparent; }
    }

    #endregion

    #region Yahoo
    private void comboBoxTicker_SelectedValueChanged(object sender, EventArgs e)
    {
      UpdateYahooData();
    }
    private void comboBoxTicker_TextUpdate(object sender, EventArgs e)
    {
      UpdateYahooData();
    }
    private void dateTimePickerYahooEndDate_ValueChanged(object sender, EventArgs e)
    {
      UpdateYahooData();
    }
    private void dateTimePickerYahooStartDate_ValueChanged(object sender, EventArgs e)
    {
      UpdateYahooData();
    }
    private async void UpdateYahooData()
    {
      if (Updating) 
        return;

      var ticker = comboBoxTicker.Text.ToUpper();
      var startTime = dateTimePickerYahooStartDate.Value;
      var endTime = dateTimePickerYahooEndDate.Value;
      try
      {
        YahooSecurityMeta = await ClientRefs.ScaffelPikeChannel.QueryYahoo(null, ticker);

        if(YahooSecurityMeta != null)
          TickerName = YahooSecurityMeta.SecurityData.First().Key ?? "";

        YahooCandlesData = await ClientRefs.ScaffelPikeChannel.GetYahooHistoricalData(ticker, startTime, endTime);
      }
      catch (Exception ex)
      {
        ClientRefs.Log.Error("chartYahoo_Click", ex);
        MessageBox.Show(ex.Message);
      }
      PlotChartYahoo();
      FillListViewYahoo();
    }
    private void FillListViewYahoo()
    {
      if (YahooCandlesData == null) return;
      if (YahooCandlesData.Count == 0) return;

      var round = 2;
      foreach (var candle in YahooCandlesData)
      {
        ListViewItem row = new ListViewItem();
        row.Tag = candle;
        row.Text = candle.DateTime.ToString("dd/MM/yyyy");
        row.SubItems.Add(new ListViewSubItem() {
          Tag = Math.Round(candle.High, round),
          Text = Math.Round(candle.High, round).ToString()
        });
        row.SubItems.Add(new ListViewSubItem() {
          Tag = Math.Round(candle.Low, round),
          Text = Math.Round(candle.Low, round).ToString()
        });
        row.SubItems.Add(new ListViewSubItem() {
          Tag = Math.Round(candle.Open, round),
          Text = Math.Round(candle.Open, round).ToString()
        });
        row.SubItems.Add(new ListViewSubItem() {
          Tag = Math.Round(candle.Close, round),
          Text = Math.Round(candle.Close, round).ToString()
        });
        row.SubItems.Add(new ListViewSubItem() {
          Tag = Math.Round(candle.AdjustedClose, round),
          Text = Math.Round(candle.AdjustedClose, round).ToString()
        });
        listViewYahoo.Items.Add(row);
      }
      listViewYahoo.Show();
    }
    private void PlotChartYahoo()
    {
      if (YahooCandlesData == null) return; 
      if (YahooCandlesData.Count == 0) return;

      chartYahoo.ChartAreas.Clear();
      chartYahoo.Series.Clear();
      chartYahoo.Titles.Clear();

      chartYahoo.Titles.Add(TickerName);
      chartYahoo.Titles[0].Visible = true;

      var candleChartArea = chartYahoo.ChartAreas.Add("Prices");
      candleChartArea.InnerPlotPosition = new ElementPosition(5, 0, 99, 130);
      candleChartArea.AxisX.CustomLabels.Add(new CustomLabel());//Hide x axis
      var volumeChartArea = chartYahoo.ChartAreas.Add("Volume");
      volumeChartArea.InnerPlotPosition = new ElementPosition(5, 50, 99, 30);

      var candleSeries = new Series("Stock");
      candleSeries.ChartType = SeriesChartType.Stock;
      candleSeries.ChartArea = candleChartArea.Name;
      candleSeries["OpenCloseStyle"] = "Candlestick";
      candleSeries["ShowOpenClose"] = "Open";
      candleSeries["PointWidth"] = "0.8";
      candleSeries["PriceUpColor"] = "Green";
      candleSeries["PriceDownColor"] = "Red";
      candleSeries.XValueMember = "Day";
      candleSeries.YValueMembers = "High,Low,Open,Close";
      candleSeries.YValuesPerPoint = 4;
      candleSeries.XValueType = ChartValueType.DateTime;
      candleSeries.YValueType = ChartValueType.Double;

      var YMin = YahooCandlesData.Select(candle => (double)candle.Low).ToList().Min();
      var YMax = YahooCandlesData.Select(candle => (double)candle.High).ToList().Max();
      var YRange = YMax - YMin;
      candleChartArea.AxisY.Minimum = Math.Floor(YMin  -  0.1 * YRange);
      candleChartArea.AxisY.Maximum = Math.Ceiling(YMax + 0.1 * YRange);

      var volumeSeries = new Series("Volume");
      volumeSeries.ChartType = SeriesChartType.Column;
      volumeSeries.ChartArea = volumeChartArea.Name;
      volumeSeries.XValueType = ChartValueType.DateTime;
      volumeSeries.YValueType = ChartValueType.Int64;

      //Add data
      foreach (var candle in YahooCandlesData) //For each row
      {
        candleSeries.Points.AddXY(candle.DateTime, candle.High, candle.Low, candle.Open, candle.Close);
        volumeSeries.Points.AddXY(candle.DateTime, candle.Volume);
      }


      chartYahoo.Series.Add(candleSeries);
      chartYahoo.Series.Add(volumeSeries);

      chartYahoo.Show();
      foreach (var ca in chartYahoo.ChartAreas) { ca.BackColor = Color.Transparent; }
    }
    #endregion

    private void chartYahoo_PostPaint(object sender, ChartPaintEventArgs e)
    {
      ChartArea ca = chartYahoo.ChartAreas[0];
      Series s = chartYahoo.Series[0];
      Pen hiPen = new Pen(Color.Black,2);
      Pen loPen = new Pen(Color.Black,2);


      if (e.ChartElement == s)
        foreach (DataPoint dp in s.Points)
        {
          float x = (float)ca.AxisX.ValueToPixelPosition(dp.XValue);
          float y_hi = (float)ca.AxisY.ValueToPixelPosition(dp.YValues[0]);
          float y_low = (float)ca.AxisY.ValueToPixelPosition(dp.YValues[1]);
          float y_open = (float)ca.AxisY.ValueToPixelPosition(dp.YValues[2]);
          float y_close = (float)ca.AxisY.ValueToPixelPosition(dp.YValues[3]);

          e.ChartGraphics.Graphics.DrawLine(loPen, x, y_low, x, Math.Max(y_close, y_open));
          e.ChartGraphics.Graphics.DrawLine(hiPen, x, y_hi, x, Math.Min(y_close, y_open));
        }
    }
    
  }
}

