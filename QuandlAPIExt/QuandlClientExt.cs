using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Quandl.NET;
using Quandl.NET.Model.Response;
using FinDataApiManager.TransferObjects;
using ScafellPikeLogger;

namespace FinDataApiManager
{
  public class QuandlClientExt: QuandlClient
  {
    private readonly ILogger _logger;
    private readonly string _apiKey;
    static HttpClient client = new HttpClient();
    public QuandlClientExt(ILogger logger, string apiKey): base(apiKey)
    {
      _logger = logger;
      _apiKey = apiKey;
    }
    #region Datasets
    public async Task<List<QuandlDatasetSurrogate>> GetInitialDataSetsInDb(string dbcode)
    {
      _logger.Information("GetInitialDataSetsInDb", $"API call start {dbcode}");
      List<QuandlDatasetSurrogate> DatsetResponses = new List<QuandlDatasetSurrogate>();
      try
      {
        string request = $"https://www.quandl.com/api/v3/datasets.json?database_code={dbcode}&api_key={_apiKey}";
        HttpResponseMessage response = await client.GetAsync(request);
        if (response.IsSuccessStatusCode)
        {
          _logger.Information("GetInitialDataSetsInDb", "API call successfull");
          string content = await response.Content.ReadAsStringAsync();
          var dataset = JsonConvert.DeserializeObject<QuandlDatasetResponseSurrogate>(content);
          DatsetResponses.AddRange(dataset.datasets);
          _logger.Information("GetInitialDataSetsInDb", "API content serialized");
        }
      }
      catch (Exception ex)
      {
        _logger.Error("GetInitialDataSetsInDb", ex);
      }

      return DatsetResponses;
    }
    /// <summary>
    /// Data seems to be the same each page...
    /// </summary>
    /// <param name="dbcode"></param>
    /// <param name="pagesize"></param>
    /// <param name="startPage"></param>
    /// <param name="endpage"></param>
    /// <returns></returns>
    public async Task<List<QuandlDatasetSurrogate>> GetDataSetsInDbByMultiplePages(string dbcode, int pagesize = 100, int startPage=1, int endpage = 20)
    {
       
      _logger.Information("GetAllDataSetsInDb", $"API call start {dbcode}");
      List<QuandlDatasetSurrogate> DatsetResponses = new List<QuandlDatasetSurrogate>();

      try
      {
        for (int page = startPage; page <= endpage; page++)
        {
          var responses = await GetDataSetsInDbByPage(dbcode, startPage, pagesize);
          if (responses.datasets != null)
          {
            DatsetResponses.AddRange(responses.datasets);
            _logger.Information("GetAllDataSetsInDb",
              $"Retrieved {responses.meta.current_last_item}" + $"/{responses.meta.total_count}");
            Thread.Sleep(40);
          }
        }
      }
      catch(Exception ex)
      {
        _logger.Error("GetAllDataSetsInDb", ex);
      }
      return DatsetResponses;
    }

    public async Task<QuandlDatasetResponseSurrogate> GetDataSetsInDbByPage(string dbcode, int page, int perPage)
    {
      _logger.Information("GetDataSetsInDbByPage", $"API call start {dbcode}, page {page}, perPage {perPage}");
      QuandlDatasetResponseSurrogate DatsetResponse = new QuandlDatasetResponseSurrogate();

      try
      {
        string request = $"https://www.quandl.com/api/v3/datasets.json?database_code={dbcode}&api_key={_apiKey}&current_page={page}&per_page={perPage}";
        if (page > 19) request += '"';
        HttpResponseMessage response = await client.GetAsync(request);
        if (response.IsSuccessStatusCode)
        {
          _logger.Information("GetDataSetsInDbByPage", "API call successfull");
          string content = await response.Content.ReadAsStringAsync();
          DatsetResponse = JsonConvert.DeserializeObject<QuandlDatasetResponseSurrogate>(content);
          _logger.Information("GetDataSetsInDbByPage", "API content serialized");
        }
        else
          ;
      }
      catch(Exception ex)
      {
        _logger.Error("GetDataSetsInDbByPage", ex);
      }
      return DatsetResponse;
    }
    #endregion
    #region Databases
    public async Task<List<QuandlDatabaseSurrogate>> GetDatabases()
    {
      _logger.Information("GetDatabases", $"API call start");
      List<QuandlDatabaseSurrogate> DatabaseResponses = new List<QuandlDatabaseSurrogate>();
      try
      {
        string request = $"https://www.quandl.com/api/v3/databases.json?databases?api_key={_apiKey}";
        HttpResponseMessage response = await client.GetAsync(request);
        if (response.IsSuccessStatusCode)
        {
          _logger.Information("GetDatabases", "API call successfull");
          string content = await response.Content.ReadAsStringAsync();
          var databases = JsonConvert.DeserializeObject<QuandlDatabaseResponseSurrogate>(content);
          DatabaseResponses = databases.databases;
          _logger.Information("GetDatabases", "API content serialized");
        }
      }
      catch (Exception ex)
      {
        _logger.Error("GetDatabases", ex);
      }

      return DatabaseResponses;
    }
    #endregion
    #region TimeSeries
    /// <summary>
    /// Forwarded from Quandl.NET
    /// </summary>
    /// <param name="databaseCode"></param>
    /// <param name="datasetCode"></param>
    /// <param name="limit"></param>
    /// <param name="columnIndex"></param>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <param name="order"></param>
    /// <param name="collapse"></param>
    /// <param name="transform"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<TimeseriesDataResponse> GetTimeseriesData(string databaseCode, string datasetCode, int? limit = null,
      int? columnIndex = null, DateTime? startDate = null, DateTime? endDate = null, Order? order = null,
      Collapse? collapse = null, Transform? transform = null, CancellationToken token = default(CancellationToken))
    {
      try
      {
        // reformat return type into a better format. 
        return await base.Timeseries.GetDataAsync(databaseCode, datasetCode, limit, columnIndex, startDate, endDate, order, collapse, transform, token);
      }
      catch(Exception ex)
      {
        _logger.Error("GetTimeseriesData", ex);
        return null;
      }
    }
    #endregion
  }
}
