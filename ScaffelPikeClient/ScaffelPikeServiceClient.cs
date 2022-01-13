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
    private readonly ILogger _logger;
    public ScaffelPikeServiceClient(ILogger logger)
    {
      _logger = logger;
      InitClient();
    }

    private void InitClient()
    {

    }
  }
}
