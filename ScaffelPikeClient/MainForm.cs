using System;
using System.Linq;
using System.Windows.Forms;

namespace ScaffelPikeClient
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
      var databases = await ClientRefs.ScaffelPikeChannel.GetQuandlDbs();
      var dbToUse = databases.First(db => db.Code.Contains("BITFINEX"));
      var datasets = await ClientRefs.ScaffelPikeChannel.GetQuandlDataSets(dbToUse.Code);
      var dsToUse = datasets.First(ds => ds.Code.Contains("BTC") && ds.Code.Contains("ETH"));
      var timeseries = await ClientRefs.ScaffelPikeChannel.GetQuandlTimeseries(dbToUse.Code, dsToUse.Code);  // ~0.5mb 
    }
  }
}
 