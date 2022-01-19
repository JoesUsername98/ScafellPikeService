using System;
using System.Linq;
using ScaffelPikeContracts;

namespace ScaffelPikeServices
{
  public static class LogInManager
  {
    public static PasswordDto ProcessLogInRequest(string username, string password)
    {
      ServiceReferences.Logger.Information("ProcessLogInRequest", "Entered ProcessLogInRequest");

      Console.WriteLine($"Recieved Log In Request with Username: {username}, Password: {password}");
      var clientsRequest = ServiceReferences.UserDA.GetUsers();
      clientsRequest.Wait();
      var client = clientsRequest.Result.FirstOrDefault(c => c.Username == username && c.Password == password);

      if (client != null)
      {
        Console.WriteLine("Successful");
        return new PasswordDto() { Success = true, OtherData = client.FirstName + client.Surname };
      }

      Console.WriteLine("Failed");
      return new PasswordDto() { Success = false, OtherData = "" };
    }
  }
}
