using System;
using System.Linq;
using System.Threading.Tasks;
using ScaffelPikeContracts;

namespace ScaffelPikeServices
{
  public static class LogInManager
  {
    public static async Task<LogInResponse> ProcessLogInRequestAsync(LogInRequest logInRequest)
    {

      ServiceReferences.Logger.Information("ProcessLogInRequest",
        $"Log In Request with Username: {logInRequest.Username}, Client: {logInRequest.ClientGuid}");
      
      var allClients = await ServiceReferences.UserDA.GetUsers();
      var client = allClients.FirstOrDefault(c => c.Username == logInRequest.Username && c.Password == logInRequest.Password);

      if (client != null)
      {
        ServiceReferences.Logger.Information("ProcessLogInRequest",
          $"Log In Request with Username: {logInRequest.Username}, Client: {logInRequest.ClientGuid} was succefull");
        return new LogInResponse() 
        { 
          SuccesfulRequest = true,
          FirstName = client.FirstName,
          Surname = client.Surname,
          Admin = client.Admin,
          ServerGuid = ServiceReferences.ServerGuid
        };
      }

      ServiceReferences.Logger.Information("ProcessLogInRequest",
          $"Log In Request with Username: {logInRequest.Username}, Client: {logInRequest.ClientGuid} was unsuccefull");

      return new LogInResponse() 
      {
        SuccesfulRequest = false,
        ServerGuid = ServiceReferences.ServerGuid
      };
    }
  }
}
