using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeClient
{
  public class HeartbeatManager
  {
    private readonly Guid _guid;
    public HeartbeatManager()
    {
      _guid = Guid.NewGuid();
    }

  }
}
