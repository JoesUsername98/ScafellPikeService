using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeContracts;

namespace ScaffelPikeClient
{
  public static class HeartbeatManagerClientSide
  {
    private static readonly TimeSpan sendingInterval;
    private static readonly TimeSpan allowableResponseInterval;
    public static Dictionary<Guid,DateTime> Connections { get; private set; }
    static HeartbeatManagerClientSide()
    {
      Connections = new Dictionary<Guid,DateTime>();
      sendingInterval = new TimeSpan(0,0,int.Parse(ConfigurationManager.AppSettings["HeartbeatInterval"]));
      allowableResponseInterval = new TimeSpan(0, 0, 
        int.Parse(ConfigurationManager.AppSettings["HeartbeatInterval"]) *
        int.Parse(ConfigurationManager.AppSettings["HeartbeatGraceMultiplier"])
        );
    }
    
    /// <summary>
    /// Notify service of your presence and your intention to connect
    /// </summary>
    public static async Task TryEstablishConnectionAsync() // add a cancellation token?
    {
      HeartbeatDto initialHeartbeat = new HeartbeatDto() 
      {
        Guid = ClientReferences.ClientGuid,
        Interval = sendingInterval,
        HeartbeatType = HeartbeatType.Start
      };

      while(true) // and not cancelled
      {
        Task.Delay(sendingInterval);

        try
        {
          var response = await ClientReferences.ScaffelPikeChannel.Heartbeat(initialHeartbeat);
          var responseInterval = DateTime.Now - Connections[response.Guid];

          if (!Connections.ContainsKey(response.Guid))
          {
            ClientReferences.Logger.Information("HeartbeatManager", $"Initial Connection With {response.Guid}");
            Connections.Add(response.Guid, DateTime.Now);
          }
          else if (responseInterval > allowableResponseInterval)
          {
            ClientReferences.Logger.Warning("HeartbeatManager",
              $"Connection With {response.Guid} took {responseInterval: ss}s. Acceptable {allowableResponseInterval: ss}");
            Connections.Add(response.Guid, DateTime.Now);
          }
          else
            ClientReferences.Logger.Debug("HeartbeatManager",
              $"Connection With {response.Guid} took {responseInterval: ss}s");
        }
        catch(CommunicationException ex)
        {
          ClientReferences.Logger.Error("No Servers Available", ex);
        }


      }
    }

    /// <summary>
    /// Notify service of your presence is terminateing
    /// </summary>
    public static async Task TerminateConnectionAsync(Guid terminee) // add a cancellation token?
    {
      ClientReferences.Logger.Information("HeartbeatManager", $"Removing Connection With {terminee}");

      HeartbeatDto finalHeartbeat = new HeartbeatDto() {
        Guid = ClientReferences.ClientGuid,
        Interval = sendingInterval,
        HeartbeatType = HeartbeatType.Stop
      };

      while (Connections.ContainsKey(terminee))
      {
        Task.Delay(sendingInterval);

        try
        {
          var response = await ClientReferences.ScaffelPikeChannel.Heartbeat(finalHeartbeat);
          if (response != null)
            break;
        }
        catch (CommunicationException ex)
        {
          ClientReferences.Logger.Error("No Servers Available", ex);
        }

      }
      Connections.Remove(terminee);
      ClientReferences.Logger.Information("HeartbeatManager", $"Removing Connection With {terminee}");
    }
  }
}
