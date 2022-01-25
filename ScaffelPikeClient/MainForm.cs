using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ScaffelPikeContracts;

namespace ScaffelPikeClient
{
  public partial class MainForm : Form
  {
    private List<DatabaseResponse> Databases { get; set; }
    private DatabaseResponse DatabaseSelected { get; set; }
    private List<DatasetResponse> Datasets{ get; set; }
    private DatasetResponse DatasetSelected { get; set; }
    private MyTimeseriesDataResponse TimeseriesData { get; set; }

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

      var dbCodeToUse = (string)comboBoxDatabase.SelectedItem;
      DatabaseSelected = Databases.FirstOrDefault(db => db.Code == dbCodeToUse);

      try
      {
        Datasets = await ClientRefs.ScaffelPikeChannel.GetQuandlDataSets(dbCodeToUse);
        comboBoxDataset.Items.AddRange(Datasets.Select(ds => ds.Code).ToArray());
      }
      catch(Exception ex)
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
      }
      catch (Exception ex)
      {
        ClientRefs.Log.Error("comboBoxDataset_SelectedValueChanged", ex);
      }
    }
  }
}
 