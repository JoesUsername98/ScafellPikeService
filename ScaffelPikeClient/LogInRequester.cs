using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeContracts;

namespace ScaffelPikeClient
{
  internal static class LogInRequester
  {
    internal static LogInResponse RequestLogIn(string username, string password)
    {
      ClientReferences.Logger.Information("RequestLogIn", $"Log In Attempt with Username [{username}] Passsword [{password}]");

      var request = new LogInRequest {
        ClientGuid = ClientReferences.ClientGuid,
        Username = username,
        Password = password
      };
      try
      {
        var response = ClientReferences.ScaffelPikeChannel.LogIn(request);
        response.Wait();
        LogInResponse logInResponse = response.Result;

        ClientReferences.Logger.Information("RequestLogIn", $"Log In Attempt Successful {logInResponse.SuccesfulRequest}");

        if (logInResponse.SuccesfulRequest)
          ClientReferences.RegisterUser(logInResponse);

        return logInResponse;
      }
      catch(Exception ex)
      {
        ClientReferences.Logger.Error($"RequestLogIn", ex);
        return null;
      }
    }

  }
}
