using System.Threading.Tasks;
using ScaffelPikeDataAccess.Data;
using ScaffelPikeLogger;
using ScaffelPikeContracts;
using System.Linq;

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
    /// Just for testing. Will need to 
    /// </summary>
    /// <returns></returns>
    public async Task QuandlModel()
    {
      var databases = await QuandlManager.QuandlGetDbs();
      var plebDbs = databases.Values.Where(db => !db.premium);
      var datasets = await QuandlManager.QuandlGetDataSets("BITFINEX");
      var cryptoSet = datasets.FirstOrDefault(ds => ds.name.Contains("BTC") && ds.name.Contains("ETH")).dataset_code;
      var timeseries = await QuandlManager.QuandlGetTimeSeriesData("BITFINEX", cryptoSet);
    }
  }
}
