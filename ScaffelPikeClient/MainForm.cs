using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;
using ScaffelPikeContracts;
using YahooFinanceApi;

namespace ScaffelPikeClient
{
  public partial class MainForm : Form
  {
    private List<QuandlDatabaseResponse> Databases { get; set; }
    private QuandlDatabaseResponse DatabaseSelected { get; set; }
    private List<QuandlDatasetResponse> Datasets { get; set; }
    private QuandlDatasetResponse DatasetSelected { get; set; }
    private MyQuandlTimeseriesDataResponse TimeseriesData { get; set; }

    public MainForm()
    {
      InitializeComponent();
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
      Databases = await ClientRefs.ScaffelPikeChannel.GetQuandlDbs();
      //var dbToUse = databases.First(db => db.Code.Contains("BITFINEX"));
      //var datasets = await ClientRefs.ScaffelPikeChannel.GetQuandlDataSets(dbToUse.Code);
      //var dsToUse = datasets.First(ds => ds.Code.Contains("BTC") && ds.Code.Contains("ETH"));
      //var timeseries = await ClientRefs.ScaffelPikeChannel.GetQuandlTimeseries(dbToUse.Code, dsToUse.Code);  // ~0.5mb 

      comboBoxDatabase.Items.AddRange(Databases.Select(db => db.Code).ToArray());
    }

    private void chart1_Click(object sender, EventArgs e)
    {

    }

    private async void comboBoxDatabase_SelectedValueChanged(object sender, EventArgs e)
    {
      comboBoxDataset.Items.Clear();
      comboBoxDataset.ResetText();
      comboBoxDataset.Enabled = true;

      var dbCodeToUse = (string)comboBoxDatabase.SelectedItem;
      DatabaseSelected = Databases.FirstOrDefault(db => db.Code == dbCodeToUse);

      try
      {
        Datasets = await ClientRefs.ScaffelPikeChannel.GetQuandlDataSets(dbCodeToUse);
        comboBoxDataset.Items.AddRange(Datasets.Select(ds => ds.Code).ToArray());
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
      DatasetSelected = Datasets.FirstOrDefault(ds => ds.Code == dsCodeToUse);

      try
      {
        TimeseriesData = await ClientRefs.ScaffelPikeChannel.GetQuandlTimeseries(dbCodeToUse, dsCodeToUse);
        PlotChart();
      }
      catch (Exception ex)
      {
        ClientRefs.Log.Error("comboBoxDataset_SelectedValueChanged", ex);
      }
    }

    private void PlotChart()
    {
      chartTimeseries.ChartAreas.Clear();
      chartTimeseries.Series.Clear();
      chartTimeseries.Titles.Clear();

      chartTimeseries.Titles.Add(DatasetSelected.Name);
      chartTimeseries.Titles[0].Visible = true;

      var priceChartArea = chartTimeseries.ChartAreas.Add("Prices");
      priceChartArea.InnerPlotPosition = new ElementPosition(5, 0, 99, 140);
      priceChartArea.AxisX.CustomLabels.Add(new CustomLabel());//Hide x axis
      var volumeChartArea = chartTimeseries.ChartAreas.Add("Volume");
      volumeChartArea.InnerPlotPosition = new ElementPosition(5, 50, 99, 30);

      for (int i = 1; i < TimeseriesData.Data[0].Length; i++) //For each column
      {
        string seriesName = TimeseriesData.ColumnNames[i];
        var series = new Series(seriesName);
        series.ChartType = seriesName.ToLower().Equals("volume") ? SeriesChartType.Area : SeriesChartType.Line;
        series.XValueType = ChartValueType.DateTime;
        series.YValueType = ChartValueType.Double;

        foreach (var line in TimeseriesData.Data.Where(l => l[0] != null)) //For each row
        {
          double yValue =  line[i]== null ? 0 : (double)line[i];
          series.Points.AddXY(DateTime.Parse((string)line[0]), yValue);
        }

        series.ChartArea = seriesName.ToLower().Equals("volume") ? volumeChartArea.Name : priceChartArea.Name;

        chartTimeseries.Series.Add(series);
      }
      chartTimeseries.Show();
      foreach (var ca in chartTimeseries.ChartAreas) { ca.BackColor = Color.Transparent; }
    }

    private async void chart1_Click_1(object sender, EventArgs e)
    {
      await ClientRefs.ScaffelPikeChannel.GetYahoo("APPL");
      //var data = serializedData.DeserializeSecurity();
    }
  }
}

