using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ScaffelPikeLib
{
    [ServiceContract(Namespace = "http://ScaeffelPike.Service")]
    public interface IScaffelPikeService
    {
        [OperationContract]
        PasswordDto LogIn(string username, string password);

        //Implement this for log in 
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginLogIn2AsyncMethod(string username, string password, AsyncCallback callback, object asyncState);

        // Note: There is no OperationContractAttribute for the end method.
        PasswordDto EndLogIn2AsyncMethod(IAsyncResult result);
        [OperationContract]
        Task<PasswordDto> LogIn3TaskAsync(string username, string password);
    }
}
