using System.Threading.Tasks;
using ScaffelPikeDataAccess.Data;
using ScaffelPikeLogger;
using ScaffelPikeContracts;
using System;

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
    public async Task<PasswordDto> LogIn(string username, string password)
    {
      return await Task<PasswordDto>.Factory.StartNew(() => 
      {
        return LogInManager.ProcessLogInRequest(username, password);
      });
    }

    public Task<HeartbeatDto> Heartbeat(HeartbeatDto incomingHeartbeat)
    {
      return Task<HeartbeatDto>.Factory.StartNew(() => 
      { 
        return HeartbeatManagerServerSide.Echo(incomingHeartbeat);
      });
  
    }
  }
}
