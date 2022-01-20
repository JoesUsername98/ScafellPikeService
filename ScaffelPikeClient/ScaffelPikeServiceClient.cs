using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Threading.Tasks;
using ScaffelPikeContracts;
using ScaffelPikeLogger;

namespace ScaffelPikeClient
{
  public class ScaffelPikeServiceClient : IScaffelPikeService
  {
    public readonly ILogger _logger;
    public readonly string _env;
    private readonly IScaffelPikeService _scaffelPikeChannel;
    public ScaffelPikeServiceClient(ILogger logger, string env)
    {
      _logger = logger;
      _env = env;

      _scaffelPikeChannel = new ChannelFactory<IScaffelPikeService>("WSHttpBinding_IScaffelPikeService").CreateChannel();
      InitClient();
    }

    public Task<PasswordDto> LogIn(string username, string password)
    {
      return _scaffelPikeChannel.LogIn(username, password);
    }

    private void InitClient()
    {
      _logger.Information("InitClient", $"Initialise ScaffelPikeServiceClient - Start - env:{_env}");
      _logger.Information("InitClient", "Initialise ScaffelPikeServiceClient - End");
    }
  }
}
