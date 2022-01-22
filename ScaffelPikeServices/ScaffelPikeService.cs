using System.Threading.Tasks;
using ScaffelPikeDataAccess.Data;
using ScaffelPikeLogger;
using ScaffelPikeContracts;

namespace ScaffelPikeServices
{
  public class ScaffelPikeService : IScaffelPikeService
  {
    public ScaffelPikeService(ILogger logger, IUserData userDA, string env)
    {
      ServiceReferences.Configure(logger, userDA, env);
      InitService();
    }
    private void InitService()
    {
      ServiceReferences.Logger.Information("InitService", $"Initialise ScaffelPikeService - Start - env:{ServiceReferences.Env}");
      ServiceReferences.Logger.Information("InitService", "Initialise ScaffelPikeService - End");
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
      QuandlManager.Quandl();
    }
  }
}
