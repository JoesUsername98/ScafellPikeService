using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeContracts;

namespace ScaffelPikeServices
{
  public static class HeartbeatManagerServerSide
  {
    public static HeartbeatDto Echo(HeartbeatDto incomingHeartbeat)
    {
      return new HeartbeatDto() {
        Guid = ServiceReferences.ServerGuid,
        Interval = incomingHeartbeat.Interval,
        HeartbeatType = HeartbeatType.Echo
      };
    }
  }
}
