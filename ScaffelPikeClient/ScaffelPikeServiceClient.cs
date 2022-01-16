using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeLogger;

namespace ScaffelPikeClient.ScaffelPikeServiceClient
{
  public partial class ScaffelPikeServiceClient
  {
    public readonly ILogger _logger;
    public readonly string _env;

    public ScaffelPikeServiceClient(ILogger logger, string env)
    {
      _logger = logger;
      _env = env;
      InitClient();
    }

    private void InitClient()
    {

    }
  }
}
