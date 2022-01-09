using System;
using System.Threading.Tasks;
using ScaffelPikeDataAccess.Data;
using ScaffelPikeLib;
using System.Linq;

namespace ScaffelPikeLib
{
  public class ScaffelPikeService : IScaffelPikeService
  {
    private readonly IScaffelPikeLogger _logger;
    public ScaffelPikeService(IScaffelPikeLogger logger)
    {
      _logger = logger;
    }
    public async Task<PasswordDto> LogIn(string username, string password)
    {
      return await Task<PasswordDto>.Factory.StartNew(() => {
        return doLogIn(username, password);
      });
    }
    public PasswordDto doLogIn(string username, string password)
    {
      Console.WriteLine($"Recieved Log In Request with Username: {username}, Password: {password}");

      var clientsRequest = new UserData().GetUsers();
      clientsRequest.Wait();
      var client = clientsRequest.Result.FirstOrDefault(c => c.Username == username && c.Password == password);

      if (client !=null)
      {
        Console.WriteLine("Successful");
        return new PasswordDto() { Success = true, OtherData = client.FirstName + client.Surname };
      }

      Console.WriteLine("Failed");
      return new PasswordDto() { Success = false, OtherData = "" };
    }
  }
}
