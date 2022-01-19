using System;
using System.Threading.Tasks;
using ScaffelPikeDataAccess.Data;
using System.Linq;
using ScaffelPikeLogger;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.ServiceModel;

namespace ScaffelPikeLib
{
  public class ScaffelPikeService : IScaffelPikeService
  {
    public ScaffelPikeService(ILogger logger, IUserData userDA, string env)
    {
      ServiceReferences.Configure(logger, userDA, env);
      InitService();
    }
    private void InitService()
    {
      ServiceReferences.Logger.Information("InitService", $"Initialise ScaffelPikeService - Start - env:{ServiceReferences.Env}");

      //clients = new Dictionary<Guid, DateTime>();
      //_heartbeatWorker = new BackgroundWorker();
      //_heartbeatWorker.DoWork += heartbeatWorker_doWork;
      //_heartbeatWorker.RunWorkerAsync();

      ServiceReferences.Logger.Information("InitService", "Initialise ScaffelPikeService - End");
    }
    public async Task<PasswordDto> LogIn(string username, string password)
    {
      return await Task<PasswordDto>.Factory.StartNew(() => {
        return LogInManager.ProcessLogInRequest(username, password);
      });
    }
    //public async Task<Guid> RecieveHeartbeat(Guid clientGuid)
    //{
    //  _logger.Information("RecieveHeartbeat", "Entered RecieveHeartbeat");
    //  return await Task<Guid>.Factory.StartNew(() => {
    //    return doRecieveHeartbeat(clientGuid);
    //  });
    //}
    //public Guid doRecieveHeartbeat(Guid clientGuid)
    //{
    //  _logger.Information("doRecieveHeartbeat", "Entered doRecieveHeartbeat");
    //  Console.WriteLine($"Recieved Heartbeat from {clientGuid}");

    //  if (clients.ContainsKey(clientGuid))
    //  {
    //    clients[clientGuid] = DateTime.Now;
    //    Console.WriteLine($"Recieve repeat heartbeat from {clientGuid} at {DateTime.Now: HH:mm:ss}");
    //  }
    //  else
    //  {
    //    clients.Add(clientGuid, DateTime.Now);
    //    Console.WriteLine($"Recieve new heartbeat from {clientGuid} at {DateTime.Now: HH:mm:ss}");
    //  }

    //  return ServerGuid; 
    //}
    //private void heartbeatWorker_doWork(object sender, DoWorkEventArgs e)
    //{
    //  if (!_heartbeatWorker.IsBusy)
    //    while (!e.Cancel)
    //    {
    //      DateTime lastSent = ServerStarTime;
    //      if (clients.Count() != 0)
    //        lastSent = clients.First().Value;

    //      foreach (var client in clients)
    //      {
    //        if (DateTime.Now > client.Value.AddSeconds(3))
    //          Console.WriteLine($"client {client.Key} hasn't sent a heartbeat since {client.Value}");
    //      }
    //      Thread.Sleep(3000);
    //    }
    //}
  }
}
