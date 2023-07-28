using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using ScafellPikeContracts.Heartbeat;

namespace ScafellPikeClientWPF
{
  public static class HeartbeatManagerClientSide
  {
    private static readonly TimeSpan SendingInterval;
    private static readonly TimeSpan AllowableResponseInterval;
    private static Task CleanUpTask;
    public static Dictionary<Guid, HeartbeatDto> Connections { get; private set; }
    static HeartbeatManagerClientSide()
    {
      Connections = new Dictionary<Guid, HeartbeatDto>();
      SendingInterval = new TimeSpan(0, 0, int.Parse(ConfigurationManager.AppSettings["HeartbeatInterval"]));
      AllowableResponseInterval = new TimeSpan(0, 0,
        int.Parse(ConfigurationManager.AppSettings["HeartbeatInterval"]) +
        int.Parse(ConfigurationManager.AppSettings["HeartbeatGraceInterval"])
        );
      InitializeTimer();
    }

    private static void InitializeTimer()
    {
      CleanUpTask = new Task(() => CleanUpConnections());
      CleanUpTask.Start();
    }

    private static void CleanUpConnections()
    {
      while (!CleanUpTask.IsCanceled)
      {
        CleanUpTask.Wait(AllowableResponseInterval);
        foreach (var connection in Connections.Values.ToList())
          if (DateTime.Now - connection.SentAt > AllowableResponseInterval)
          {
            ClientRefs.Log.Warning("HeartbeatManagerClientSide",
              $"Server has not replied since {connection.SentAt}");
            Connections.Remove(connection.Guid);
          }
      }
    }

    /// <summary>
    /// Notify service of your presence and your intention to connect
    /// </summary>
    public static async Task TryEstablishConnectionAsync() // add a cancellation token?
    {
      HeartbeatDto initialHeartbeat = new HeartbeatDto() {
        Guid = ClientRefs.ClientGuid,
        Interval = SendingInterval,
        HeartbeatType = HeartbeatType.Start
      };

      HeartbeatDto continuationHeartbeat = new HeartbeatDto() {
        Guid = ClientRefs.ClientGuid,
        Interval = SendingInterval,
        HeartbeatType = HeartbeatType.Continue
      };

      while (true) // and not cancelled
      {
        await Task.Delay(SendingInterval);

        try
        {
          var heartbeatToSend = (Connections.Count < 1) ? initialHeartbeat : continuationHeartbeat;
          heartbeatToSend.SentAt = DateTime.Now;
          var response = await ClientRefs.ScaffelPikeChannel.Heartbeat(heartbeatToSend);

          if (response == null)
          {
            ClientRefs.Log.Warning("HeartbeatManagerClientSide",
              $"Recieved empty heartbeat");
            continue;
          }

          if (!Connections.ContainsKey(response.Guid))
          {
            ClientRefs.Log.Information("HeartbeatManagerClientSide", $"Connection Established With {response.Guid}");
            Connections.Add(response.Guid, response);
          }
          else if (DateTime.Now - Connections[response.Guid].SentAt > AllowableResponseInterval)
          {
            ClientRefs.Log.Warning("HeartbeatManagerClientSide",
              $"Connection With {response.Guid} took {(DateTime.Now - Connections[response.Guid].SentAt).TotalSeconds.ToString()}s." +
              $" Acceptable {AllowableResponseInterval.TotalSeconds}s");
            Connections[response.Guid] = response;
          }
          else 
          { 
            ClientRefs.Log.Debug("HeartbeatManagerClientSide",
              $"Connection With {response.Guid} took {(DateTime.Now - Connections[response.Guid].SentAt).TotalSeconds}s");
            Connections[response.Guid] = response;
          }
        }
        catch (CommunicationException ex)
        {
          // TODO Restablishing connections 
          // https://stackoverflow.com/questions/2763592/the-communication-object-system-servicemodel-channels-servicechannel-cannot-be
          //
          ClientRefs.Log.Error("No Servers Available", ex);
        }
        catch(Exception ex)
        {
          ClientRefs.Log.Error("Unknown Error", ex);
        }
      }
    }

    /// <summary>
    /// Notify service of your presence is terminateing
    /// </summary>
    public static async Task TerminateConnectionAsync(Guid terminee) // add a cancellation token?
    {
      ClientRefs.Log.Information("HeartbeatManagerClientSide", $"Removing Connection With {terminee}");

      HeartbeatDto finalHeartbeat = new HeartbeatDto() {
        Guid = ClientRefs.ClientGuid,
        Interval = SendingInterval,
        HeartbeatType = HeartbeatType.Stop
      };

      while (Connections.ContainsKey(terminee))
      {
        Task.Delay(SendingInterval);

        try
        {
          var response = await ClientRefs.ScaffelPikeChannel.Heartbeat(finalHeartbeat);
          if (response != null)
            break;
        }
        catch (CommunicationException ex)
        {
          ClientRefs.Log.Error("No Servers Available", ex);
        }

      }
      Connections.Remove(terminee);
      ClientRefs.Log.Information("HeartbeatManagerClientSide", $"Removing Connection With {terminee}");
    }
  }
}
