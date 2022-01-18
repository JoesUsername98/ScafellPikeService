using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ScaffelPikeLib
{
  [ServiceContract(Namespace = "http://ScaeffelPike.Service")]
  public interface IScaffelPikeService
  {
    [OperationContract]
    Task<PasswordDto> LogIn(string username, string password);

    //[OperationContract]
    //Task<Guid> RecieveHeartbeat(Guid clientGuid);

    //Guid doRecieveHeartbeat(Guid clientGuid);

    }
}
