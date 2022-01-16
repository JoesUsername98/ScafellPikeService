using System;
using System.Threading.Tasks;
using ScaffelPikeDataAccess.Data;
using System.Linq;
using ScaffelPikeLogger;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace ScaffelPikeLib
{
  public class ScaffelPikeService : IScaffelPikeService
  {
    private readonly ILogger _logger;
    private readonly IUserData _UserDA;
    private readonly string _env;
    private readonly Guid ServerGuid;
    private readonly DateTime ServerStarTime;

    public BackgroundWorker _heartbeatWorker;
    private Dictionary<Guid,DateTime> clients { get; set; }

    public static ScaffelPikeService(ILogger logger, IUserData UserDA, string env)
    {
      _logger = logger;
      _UserDA = UserDA;
      _env = env;
      ServerGuid = Guid.NewGuid();
      ServerStarTime = DateTime.Now;

      InitService();
    }
    private void InitService()
    {
      _logger.Information("InitService", $"Initialise ScaffelPikeService - Start - env:{_env}");

      clients = new Dictionary<Guid, DateTime>();
      _heartbeatWorker = new BackgroundWorker();
      _heartbeatWorker.DoWork += heartbeatWorker_doWork;
      _heartbeatWorker.RunWorkerAsync();

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
    public async Task<Guid> RecieveHeartbeat(Guid clientGuid)
    {
      _logger.Information("RecieveHeartbeat", "Entered RecieveHeartbeat");
      return await Task<Guid>.Factory.StartNew(() => {
        return doRecieveHeartbeat(clientGuid);
      });
    }
    public Guid doRecieveHeartbeat(Guid clientGuid)
    {
      _logger.Information("doRecieveHeartbeat", "Entered doRecieveHeartbeat");
      Console.WriteLine($"Recieved Heartbeat from {clientGuid}");

      if (clients.ContainsKey(clientGuid))
      {
        clients[clientGuid] = DateTime.Now;
        Console.WriteLine($"Recieve repeat heartbeat from {clientGuid} at {DateTime.Now: HH:mm:ss}");
      }
      else
      {
        clients.Add(clientGuid, DateTime.Now);
        Console.WriteLine($"Recieve new heartbeat from {clientGuid} at {DateTime.Now: HH:mm:ss}");
      }

      return ServerGuid; 
    }
    private void heartbeatWorker_doWork(object sender, DoWorkEventArgs e)
    {
      if (!_heartbeatWorker.IsBusy)
        while (!e.Cancel)
        {
          DateTime lastSent = ServerStarTime;
          if (clients.Count() != 0)
            lastSent = clients.First().Value;

          foreach (var client in clients)
          {
            if (DateTime.Now > client.Value.AddSeconds(3))
              Console.WriteLine($"client {client.Key} hasn't sent a heartbeat since {client.Value}");
          }
          Thread.Sleep(3000);
        }
    }
  }
}
