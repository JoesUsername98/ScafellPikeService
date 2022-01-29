using System.Threading.Tasks;
using ScaffelPikeDataAccess.Data;
using ScaffelPikeLogger;
using ScaffelPikeContracts;
using System.Linq;
using System.Collections.Generic;
using Quandl.NET.Model.Response;
using YahooFinanceApi;
using Newtonsoft.Json;

namespace ScaffelPikeServices
{
  public class ScaffelPikeService : IScaffelPikeService
  {
    public ScaffelPikeService(ILogger logger, IUserData userDA, string env)
    {
      ServiceRefs.Configure(logger, userDA, env);
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
      return Task<HeartbeatDto>.Factory.StartNew(() => 
      { 
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
    /// <returns>A seriealized object of security data</returns>
    public async Task<string> GetYahoo(params string[] tickers)
    {
      var a = await APIManager.YahooGetSecurityData(tickers);
      var b = JsonConvert.SerializeObject(a);
      return b;
    }
  }
}
