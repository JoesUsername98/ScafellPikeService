using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Quandl.NET;
using Quandl.NET.Model.Response;
using QuandlAPIExt;
using QuandlAPIExt.TransferObjects;
using ScaffelPikeContracts;

namespace ScaffelPikeServices
{
  public static class QuandlManager
  {
    public static ApiKeys ApiKeys { get; private set; }
    public static Dictionary<string, DatabaseQuandlModel> DBCodeMap { get; private set; }
    public static Dictionary<string, DatasetQuandlModel> DSCodeMap { get; private set; }
    public static Dictionary<string, List<DatasetQuandlModel>> DBtoDSMap { get; private set; }
    private static readonly QuandlClientExt client;
    static QuandlManager()
    {
      using (StreamReader r = new StreamReader("secrets.json"))
      {
        string json = r.ReadToEnd();
        ApiKeys = JsonConvert.DeserializeObject<ApiKeysConfig>(json).ApiKeys;
      }
      client = new QuandlClientExt(ServiceRefs.Log, ApiKeys.Quandl);

      DBtoDSMap = new Dictionary<string, List<DatasetQuandlModel>>();
      DBCodeMap = new Dictionary<string, DatabaseQuandlModel>();
      DSCodeMap = new Dictionary<string, DatasetQuandlModel>();
    }

    internal async static Task<List<DatabaseResponse>> QuandlGetDbs()
    {
      ServiceRefs.Log.Information("QuandlGetDbs", $"Start method");

      var databases = await client.GetDatabases();

      foreach (var db in databases.Where(dbs => !dbs.premium))
      {
        if (!DBCodeMap.ContainsKey(db.database_code))
        {
          ServiceRefs.Log.Information("QuandlGetDbs", $"Adding {db.database_code} to DBCodeMap");
          DBCodeMap.Add(db.database_code, db);
        }

        if (!DBtoDSMap.ContainsKey(db.database_code))
        {
          ServiceRefs.Log.Information("QuandlGetDbs", $"Adding {db.database_code} to DBtoDSMap");
          DBtoDSMap.Add(db.database_code, null);
        }
      }

      var output = new List<DatabaseResponse>();
      foreach (var db in DBCodeMap.Values) { output.Add(DatabaseApiToWfcDto(db)); }
      ServiceRefs.Log.Information("QuandlGetDbs", $"End method");
      
      return output;
    }

    internal async static Task<List<DatasetResponse>> QuandlGetDataSets(string dbCode)
    {
      ServiceRefs.Log.Information("QuandlGetDataSets", $"Start method dbCode [{dbCode}]");

      if (!DBCodeMap.ContainsKey(dbCode) && !DBtoDSMap.ContainsKey(dbCode))
      {
        ServiceRefs.Log.Warning("QuandlGetDataSets",
          $"{dbCode} is in DBCodeMap [{DBCodeMap.ContainsKey(dbCode)}] and is in DBtoDSMap [{DBtoDSMap.ContainsKey(dbCode)}]");
        return null;
      }

      if (DBtoDSMap[dbCode] == null)
      {
        ServiceRefs.Log.Information("QuandlGetDataSets", $"Start API Request for DataSet");
        var dataSets = await client.GetInitialDataSetsInDb(dbCode);

        ServiceRefs.Log.Information("QuandlGetDataSets", $"Finish API Request for DataSet");
        DBtoDSMap[dbCode] = dataSets.FindAll(d => !d.premium);//where not premium
      }

      foreach (var ds in DBtoDSMap[dbCode]) 
        if (!DSCodeMap.ContainsKey(ds.dataset_code))
          DSCodeMap.Add(ds.dataset_code, ds);

      List<DatasetResponse> response = new List<DatasetResponse>();
      foreach(var ds in DBtoDSMap[dbCode]) { response.Add(DatasetApiToWfcDto(ds)); }

      ServiceRefs.Log.Information("QuandlGetDataSets", $"End method dbCode [{dbCode}]");
      return response;
    }
    //TODO Modify the arguement and return types be Request and Response Dtos
    internal async static Task<MyTimeseriesDataResponse> QuandlGetTimeSeriesData(string dbCode, string dsCode)
    {
      ServiceRefs.Log.Information("QuandlGetTimeSeriesData", $"Start method dbCode [{dbCode}] dsCode [{dsCode}]");

      if (!DBCodeMap.ContainsKey(dbCode) || !DSCodeMap.ContainsKey(dsCode))
      {
        ServiceRefs.Log.Warning("QuandlGetDataSets",
          $"{dbCode} is in DBCodeMap [{DBCodeMap.ContainsKey(dbCode)}] and is in DBtoDSMap [{DBtoDSMap.ContainsKey(dbCode)}]");
        return null;
      }

      ServiceRefs.Log.Information("QuandlGetDataSets", $"Start API Request for TimeseriesData on dbCode [{dbCode}] dsCode [{dsCode}]");
      var dataSets = await client.GetTimeseriesData(dbCode, dsCode);
      ServiceRefs.Log.Information("QuandlGetDataSets", $"Finish API Request for TimeseriesData  on dbCode [{dbCode}] dsCode [{dsCode}]");

      ServiceRefs.Log.Information("QuandlGetTimeSeriesData", $"End method dbCode [{dbCode}] dsCode [{dsCode}]");

      
      return new MyTimeseriesDataResponse(dataSets.DatasetData);
    }

    private static DatabaseResponse DatabaseApiToWfcDto(DatabaseQuandlModel input)
    {
      return new DatabaseResponse() 
      {
        Id = input.id,
        Code = input.database_code,
        Description = input.description,
        DatasetCount = input.datasets_count,
        Name = input.name,
      };
    }

    private static DatasetResponse DatasetApiToWfcDto(DatasetQuandlModel input)
    {
      return new DatasetResponse() {
        Id = input.id,
        Code = input.dataset_code,
        DatabaseId = input.database_id,
        DatabaseCode = input.database_code,
        Description = input.description,
        Name = input.name,
        Frequency = input.frequency,
        Type = input.type
      };
    }

  }
}

