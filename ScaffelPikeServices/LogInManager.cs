using System;
using System.Linq;
using System.Threading.Tasks;
using ScafellPikeContracts.LogIn;

namespace ScafellPikeServices
{
  public static class LogInManager
  {
    public static async Task<LogInResponse> ProcessLogInRequestAsync(LogInRequest logInRequest)
    {

      ServiceRefs.Log.Information("ProcessLogInRequest",
        $"Log In Request with Username: {logInRequest.Username}, Client: {logInRequest.ClientGuid}");
      
      var allClients = await ServiceRefs.UserDA.GetUsers();
      var client = allClients.FirstOrDefault(c => c.Username == logInRequest.Username && c.Password == logInRequest.Password);

      if (client != null)
      {
        ServiceRefs.Log.Information("ProcessLogInRequest",
          $"Log In Request with Username: {logInRequest.Username}, Client: {logInRequest.ClientGuid} was succefull");
        return new LogInResponse() 
        { 
          SuccesfulRequest = true,
          FirstName = client.FirstName,
          Surname = client.Surname,
          Admin = client.Admin,
          ServerGuid = ServiceRefs.ServerGuid
        };
      }

      ServiceRefs.Log.Information("ProcessLogInRequest",
          $"Log In Request with Username: {logInRequest.Username}, Client: {logInRequest.ClientGuid} was unsuccefull");

      return new LogInResponse() 
      {
        SuccesfulRequest = false,
        ServerGuid = ServiceRefs.ServerGuid
      };
    }
  }
}
