using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ScaffelPikeContracts
{
  [ServiceContract(Namespace = "http://ScaeffelPike.Service")]
  public interface IScaffelPikeService
  {
    [OperationContract]
    Task<PasswordDto> LogIn(string username, string password);

    [OperationContract]
    Task<HeartbeatDto> Heartbeat(HeartbeatDto heartbeat);

  }
}
