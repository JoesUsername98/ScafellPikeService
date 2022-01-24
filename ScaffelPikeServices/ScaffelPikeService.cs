using System.Threading.Tasks;
using ScaffelPikeDataAccess.Data;
using ScaffelPikeLogger;
using ScaffelPikeContracts;
using System.Linq;
using System.Collections.Generic;
using Quandl.NET.Model.Response;

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
    public async Task<List<DatabaseResponse>> GetQuandlDbs()
    {
      return await QuandlManager.QuandlGetDbs();
    }
    /// <summary>
    /// Returns a list of non premium datasets
    /// </summary>
    /// <param name="dbCode"></param>
    /// <returns></returns>
    public async Task<List<DatasetResponse>> GetQuandlDataSets(string dbCode)
    {
      return await QuandlManager.QuandlGetDataSets(dbCode);
    }
    /// <summary>
    /// Returns a list of non Premium timeseries data
    /// </summary>
    /// <param name="dbCode"></param>
    /// <param name="dsCode"></param>
    /// <returns></returns>
    public async Task<MyTimeseriesDataResponse> GetQuandlTimeseries(string dbCode, string dsCode)
    {
      return await QuandlManager.QuandlGetTimeSeriesData(dbCode, dsCode);
    }
  }
}
