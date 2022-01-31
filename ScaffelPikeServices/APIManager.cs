using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FinDataApiManager;
using FinDataApiManager.TransferObjects;
using ScaffelPikeContracts;
using ScaffelPikeContracts.Quandl;
using ScaffelPikeContracts.Yahoo;
using YahooFinanceApi;
using System;

namespace ScaffelPikeServices
{
  public static class APIManager
  {
    public static ApiKeys ApiKeys { get; private set; }
    #region Quandl Properties and Fields
    public static Dictionary<string, QuandlDatabaseSurrogate> QuandlDBCodeMap { get; private set; }
    public static Dictionary<string, QuandlDatasetSurrogate> QuandlDSCodeMap { get; private set; }
    public static Dictionary<string, List<QuandlDatasetSurrogate>> QuandlDBtoDSMap { get; private set; }
    private static readonly QuandlClientExt QuandClient;
    #endregion
    #region Yahoo Properties and Fields
    private static readonly YahooClient YahooClient;
    #endregion

    static APIManager()
    {
      using (StreamReader r = new StreamReader("secrets.json"))
      {
        string json = r.ReadToEnd();
        ApiKeys = JsonConvert.DeserializeObject<ApiKeysConfig>(json).ApiKeys;
      }
      #region Quandl Inits
      QuandClient = new QuandlClientExt(ServiceRefs.Log, ApiKeys.Quandl);
      QuandlDBtoDSMap = new Dictionary<string, List<QuandlDatasetSurrogate>>();
      QuandlDBCodeMap = new Dictionary<string, QuandlDatabaseSurrogate>();
      QuandlDSCodeMap = new Dictionary<string, QuandlDatasetSurrogate>();
      #endregion
      #region Yahoo Inits
      YahooClient = new YahooClient(ServiceRefs.Log);
      #endregion
    }

    #region QuandlMethods
    internal async static Task<List<QuandlDatabaseResponse>> QuandlGetDbs()
    {
      ServiceRefs.Log.Information("QuandlGetDbs", $"Start method");

      var databases = await QuandClient.GetDatabases();

      foreach (var db in databases.Where(dbs => !dbs.premium))
      {
        if (!QuandlDBCodeMap.ContainsKey(db.database_code))
        {
          ServiceRefs.Log.Information("QuandlGetDbs", $"Adding {db.database_code} to DBCodeMap");
          QuandlDBCodeMap.Add(db.database_code, db);
        }

        if (!QuandlDBtoDSMap.ContainsKey(db.database_code))
        {
          ServiceRefs.Log.Information("QuandlGetDbs", $"Adding {db.database_code} to DBtoDSMap");
          QuandlDBtoDSMap.Add(db.database_code, null);
        }
      }

      var output = new List<QuandlDatabaseResponse>();
      foreach (var db in QuandlDBCodeMap.Values) { output.Add(QuandlDatabaseApiToWfcDto(db)); }
      ServiceRefs.Log.Information("QuandlGetDbs", $"End method");

      return output;
    }
    internal async static Task<List<QuandlDatasetResponse>> QuandlGetDataSets(string dbCode)
    {
      ServiceRefs.Log.Information("QuandlGetDataSets", $"Start method dbCode [{dbCode}]");

      if (!QuandlDBCodeMap.ContainsKey(dbCode) && !QuandlDBtoDSMap.ContainsKey(dbCode))
      {
        ServiceRefs.Log.Warning("QuandlGetDataSets",
          $"{dbCode} is in DBCodeMap [{QuandlDBCodeMap.ContainsKey(dbCode)}] and is in DBtoDSMap [{QuandlDBtoDSMap.ContainsKey(dbCode)}]");
        return null;
      }

      if (QuandlDBtoDSMap[dbCode] == null)
      {
        ServiceRefs.Log.Information("QuandlGetDataSets", $"Start API Request for DataSet");
        var dataSets = await QuandClient.GetInitialDataSetsInDb(dbCode);

        ServiceRefs.Log.Information("QuandlGetDataSets", $"Finish API Request for DataSet");
        QuandlDBtoDSMap[dbCode] = dataSets.FindAll(d => !d.premium);//where not premium
      }

      foreach (var ds in QuandlDBtoDSMap[dbCode])
        if (!QuandlDSCodeMap.ContainsKey(ds.dataset_code))
          QuandlDSCodeMap.Add(ds.dataset_code, ds);

      List<QuandlDatasetResponse> response = new List<QuandlDatasetResponse>();
      foreach (var ds in QuandlDBtoDSMap[dbCode]) { response.Add(QuandlDatasetApiToWfcDto(ds)); }

      ServiceRefs.Log.Information("QuandlGetDataSets", $"End method dbCode [{dbCode}]");
      return response;
    }
    internal async static Task<QuandlTimeseriesDataResponse> QuandlGetTimeSeriesData(string dbCode, string dsCode)
    {
      ServiceRefs.Log.Information("QuandlGetTimeSeriesData", $"Start method dbCode [{dbCode}] dsCode [{dsCode}]");

      if (!QuandlDBCodeMap.ContainsKey(dbCode) || !QuandlDSCodeMap.ContainsKey(dsCode))
      {
        ServiceRefs.Log.Warning("QuandlGetDataSets",
          $"{dbCode} is in DBCodeMap [{QuandlDBCodeMap.ContainsKey(dbCode)}] and is in DBtoDSMap [{QuandlDBtoDSMap.ContainsKey(dbCode)}]");
        return null;
      }

      ServiceRefs.Log.Information("QuandlGetDataSets", $"Start API Request for TimeseriesData on dbCode [{dbCode}] dsCode [{dsCode}]");
      var dataSets = await QuandClient.GetTimeseriesData(dbCode, dsCode);
      ServiceRefs.Log.Information("QuandlGetDataSets", $"Finish API Request for TimeseriesData  on dbCode [{dbCode}] dsCode [{dsCode}]");

      ServiceRefs.Log.Information("QuandlGetTimeSeriesData", $"End method dbCode [{dbCode}] dsCode [{dsCode}]");


      return new QuandlTimeseriesDataResponse(dataSets.DatasetData);
    }
    private static QuandlDatabaseResponse QuandlDatabaseApiToWfcDto(QuandlDatabaseSurrogate input)
    {
      return new QuandlDatabaseResponse() {
        Id = input.id,
        Code = input.database_code,
        Description = input.description,
        DatasetCount = input.datasets_count,
        Name = input.name,
      };
    }
    private static QuandlDatasetResponse QuandlDatasetApiToWfcDto(QuandlDatasetSurrogate input)
    {
      return new QuandlDatasetResponse() {
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
    #endregion

    #region YahooMethods
    internal async static Task<YahooSecurityResponse> YahooQuery(Field[] fields, params string[] tickers)
    {
      var query = await YahooClient.YahooQuery(fields, tickers);
      if (query == null)
        return null; 

      return new YahooSecurityResponse(query);
    }
    internal static List<string> GetYahooTickers()
    {
      return YahooClient.Tickers;
    }
    internal async static Task<List<YahooCandleResponse>> GetYahooHistoricalData(string symbol, DateTime? startTime, DateTime? endTime, Period period)
    {
      var listToReturn = new List<YahooCandleResponse>();
      try
      {
        var data = await YahooClient.GetYahooHistoricalData(symbol, startTime, endTime, period);

        if(data != null)
          foreach (var candle in data) 
            listToReturn.Add(new YahooCandleResponse(candle)); 
      }
      catch(Exception ex)
      {
        ServiceRefs.Log.Error("GetYahooHistoricalData", ex);
      }
      return listToReturn;
    }
    #endregion
  }
}

