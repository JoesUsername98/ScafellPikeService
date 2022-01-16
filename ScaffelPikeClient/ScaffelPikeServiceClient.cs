using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ScaffelPikeLogger;

namespace ScaffelPikeClient.ScaffelPikeServiceClient
{
  public partial class ScaffelPikeServiceClient
  {

    private static readonly Guid ClientGuid;
    private static readonly DateTime ClientStarTime;

    public readonly ILogger _logger;
    public readonly string _env;

    public static BackgroundWorker _heartbeatWorker;
    private static Dictionary<Guid, DateTime> servers { get; set; }

    public ScaffelPikeServiceClient(ILogger logger, string env)
    {
      _logger = logger;
      _env = env;
      
      InitClient();
    }
    static ScaffelPikeServiceClient()
    {
      ClientGuid = Guid.NewGuid();
      ClientStarTime = DateTime.Now;

      servers = new Dictionary<Guid, DateTime>();
      _heartbeatWorker = new BackgroundWorker();
      _heartbeatWorker.DoWork += heartbeatWorker_doWork;
      _heartbeatWorker.RunWorkerAsync();
    }

    private void InitClient()
    {
      _logger.Information("InitClient", $"Initialise ScaffelPikeServiceClient - Start - env:{_env}");

      


      _logger.Information("InitClient", "Initialise ScaffelPikeServiceClient - End");
    }

    private static void heartbeatWorker_doWork(object sender, DoWorkEventArgs e)
    {
      if(!_heartbeatWorker.IsBusy)
        while (!e.Cancel)
        {
          DateTime lastSent = ClientStarTime;
          if (servers.Count() != 0)
            lastSent = servers.First().Value;

          try
          {
            var serverGuid = RecieveHeartbeat(ClientGuid);
            if (servers.ContainsKey(serverGuid))
            {
              servers[serverGuid] = DateTime.Now;
              Console.WriteLine($"Recieve repeat heartbeat from {serverGuid} at {DateTime.Now: HH:mm:ss}");
            }
            else
            {
              servers.Add(serverGuid, DateTime.Now);
              Console.WriteLine($"Recieve new heartbeat from {serverGuid} at {DateTime.Now: HH:mm:ss}");
            }
          }
          catch(Exception ex)
          {
            Console.WriteLine($"No server recieved heartbeat since {lastSent: HH:mm:ss}");
          }
          finally
          {
            Thread.Sleep(3000);
          }
        }
    }
  }
}
