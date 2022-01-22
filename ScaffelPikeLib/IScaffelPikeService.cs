using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ScaffelPikeContracts
{
  [ServiceContract(Namespace = "http://ScaeffelPike.Service")]
  public interface IScaffelPikeService
  {
    [OperationContract]
    Task<LogInResponse> LogIn(LogInRequest request);

    [OperationContract]
    Task<HeartbeatDto> Heartbeat(HeartbeatDto heartbeat);

    [OperationContract]
    Task QuandlModel();
  }
}
