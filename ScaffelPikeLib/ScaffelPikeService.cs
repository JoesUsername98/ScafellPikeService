using System;
using System.Threading.Tasks;
using ScaffelPikeDataAccess.Data;
using System.Linq;
using ScaffelPikeLogger;

namespace ScaffelPikeLib
{
  public class ScaffelPikeService : IScaffelPikeService
  {
    private readonly ILogger _logger;
    private readonly IUserData _UserDA;
    private readonly string _env;

    public ScaffelPikeService(ILogger logger, IUserData UserDA, string env)
    {
      _logger = logger;
      _UserDA = UserDA;
      _env = env;
      InitService();
    }
    private void InitService()
    {
      _logger.Information("InitService", $"Initialise ScaffelPikeService - Start - env:{_env}");

      _logger.Information("InitService", "Initialise ScaffelPikeService - End");
    }
    public async Task<PasswordDto> LogIn(string username, string password)
    {
      _logger.Information("LogIn","Entered LogIn");
      return await Task<PasswordDto>.Factory.StartNew(() => {
        return doLogIn(username, password);
      });
    }
    public PasswordDto doLogIn(string username, string password)
    {
      _logger.Information("doLogIn", "Entered doLogIn");
      Console.WriteLine($"Recieved Log In Request with Username: {username}, Password: {password}");

      var clientsRequest = _UserDA.GetUsers();
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
