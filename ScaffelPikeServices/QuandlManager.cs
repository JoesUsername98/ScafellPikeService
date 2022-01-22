using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Quandl.NET;
using QuandlAPIExt;
using ScaffelPikeContracts;

namespace ScaffelPikeServices
{
  public static class QuandlManager
  {
    public static ApiKeys ApiKeys { get; private set; } 
    static QuandlManager()
    {
      using (StreamReader r = new StreamReader("secrets.json"))
      {
        string json = r.ReadToEnd();
        ApiKeys = JsonConvert.DeserializeObject<ApiKeysConfig>(json).ApiKeys;
      }
    }
    internal async  static Task Quandl()
    {
      var api = ApiKeys.Quandl;
      var client = new QuandlClient(api);
      var data = await client.Timeseries.GetDataAsync("WIKI", "FB");
      var Metadata = await client.Timeseries.GetMetadataAsync("WIKI", "FB");
      var a = await client.Timeseries.GetDatabaseMetadataAsync("WIKI");
      //QuandlAPICalls.GetAllDataSetsInDb(ApiKeys.Quandl, "WIKI");
      QuandlAPICalls.GetAllDataSetsInDbPages(ApiKeys.Quandl, "WIKI", 1, 1);
    }  
  }
}
