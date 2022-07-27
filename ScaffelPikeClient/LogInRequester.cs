using System;
using ScafellPikeContracts.LogIn;

namespace ScafellPikeClient
{
  internal static class LogInRequester
  {
    internal static LogInResponse RequestLogIn(string username, string password)
    {
      ClientRefs.Log.Information("RequestLogIn", $"Log In Attempt with Username [{username}] Passsword [{password}]");

      var request = new LogInRequest {
        ClientGuid = ClientRefs.ClientGuid,
        Username = username,
        Password = password
      };
      try
      {
        var response = ClientRefs.ScaffelPikeChannel.LogIn(request);
        response.Wait();
        LogInResponse logInResponse = response.Result;

        ClientRefs.Log.Information("RequestLogIn", $"Log In Attempt Successful {logInResponse.SuccesfulRequest}");

        if (logInResponse.SuccesfulRequest)
          ClientRefs.RegisterUser(logInResponse);

        return logInResponse;
      }
      catch(Exception ex)
      {
        ClientRefs.Log.Error($"RequestLogIn", ex);
        return null;
      }
    }

  }
}
