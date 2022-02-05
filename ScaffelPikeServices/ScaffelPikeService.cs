using System.Threading.Tasks;
using ScaffelPikeDataAccess.Data;
using ScaffelPikeLogger;
using ScaffelPikeContracts;
using System.Collections.Generic;
using ScaffelPikeContracts.LogIn;
using ScaffelPikeContracts.Heartbeat;
using ScaffelPikeContracts.Quandl;
using ScaffelPikeContracts.Yahoo;
using YahooFinanceApi;
using System;

namespace ScaffelPikeServices
{
  public class ScaffelPikeService : IScaffelPikeService
  {
    public ScaffelPikeService(ILogger logger, IUserData userDA, string env, Guid serverGuid)
    {
      ServiceRefs.Configure(logger, userDA, env, serverGuid);
      InitService();
    }
    private void InitService()
    {
      ServiceRefs.Log.Information("InitService", $"Initialise ScaffelPikeService - Start - env:{ServiceRefs.Env}");
      ServiceRefs.Log.Information("InitService", "Initialise ScaffelPikeService - End");
    }
    public async Task<LogInResponse> LogIn(LogInRequest logInRequest)
    {
      return await LogInManager.ProcessLogInRequestAsync(logInRequest);
    }

    public Task<HeartbeatDto> Heartbeat(HeartbeatDto incomingHeartbeat)
    {
      return Task<HeartbeatDto>.Factory.StartNew(() => {
        return HeartbeatManagerServerSide.Echo(incomingHeartbeat);
      });
    }

    /// <summary>
    /// Returns a list of non premium dbs
    /// </summary>
    /// <returns></returns>
    public async Task<List<QuandlDatabaseResponse>> GetQuandlDbs()
    {
      return await APIManager.QuandlGetDbs();
    }
    /// <summary>
    /// Returns a list of non premium datasets
    /// </summary>
    /// <param name="dbCode"></param>
    /// <returns></returns>
    public async Task<List<QuandlDatasetResponse>> GetQuandlDataSets(string dbCode)
    {
      return await APIManager.QuandlGetDataSets(dbCode);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbCode"></param>
    /// <param name="dsCode"></param>
    /// <returns>Returns a list of non Premium timeseries data</returns>
    public async Task<QuandlTimeseriesDataResponse> GetQuandlTimeseries(string dbCode, string dsCode)
    {
      return await APIManager.QuandlGetTimeSeriesData(dbCode, dsCode);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tickers"></param>
    /// <returns>A dictionar of security data from yahoo</returns>
    public async Task<YahooSecurityResponse> QueryYahoo(Field[] fields, params string[] tickers)
    {
      return await APIManager.YahooQuery(fields, tickers);
    }

    public Task<List<string>> GetYahooTickers()
    {
      return Task<List<string>>.Factory.StartNew(() => {
        return APIManager.GetYahooTickers();
      });
    }

    public async Task<List<YahooCandleResponse>> GetYahooHistoricalData(string symbol, DateTime? startTime = null, DateTime? endTime = null, Period period = Period.Daily)
    {
      return await APIManager.GetYahooHistoricalData(symbol, startTime, endTime, period);
    }
  }
}
