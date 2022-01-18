using Autofac.Core;
using Autofac.Integration.Wcf;
using ScaffelPikeLib;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ScaffelPikeHost
{
  internal class Program
  {
    static void Main(string[] args)
    {
      using (var container = Bootstrapper.RegisterContainerBuilder().Build())
      {
        ServiceHost selfHost = new ServiceHost(typeof(ScaffelPikeService));
        try
        {
          IComponentRegistration registration;
          if (!container.ComponentRegistry.TryGetRegistration
                   (new TypedService(typeof(IScaffelPikeService)), out registration))
          {
            Console.WriteLine("The service contract has not been registered in the container.");

            Console.ReadLine();
            Environment.Exit(-1);
          }

          selfHost.AddDependencyInjectionBehavior<IScaffelPikeService>(container);

          selfHost.Open();
          Console.WriteLine("The service is ready." + Environment.NewLine);

          foreach (var endpoint in selfHost.Description.Endpoints)
            Console.WriteLine(PrintServiceStartMetaData(endpoint));

          Console.WriteLine(Environment.NewLine + "Enter q to terminate the service." + Environment.NewLine);
          while (true)
          {
            var stop = Console.ReadLine();
            if (stop == "q")
              break;
          }

          selfHost.Close();
        }
        catch (CommunicationException ce)
        {
          Console.WriteLine("An exception occurred: {0}", ce.Message);
          selfHost.Abort();
          Console.ReadLine();
        }
      }
    }

    private static string PrintServiceStartMetaData(ServiceEndpoint serviceEndpoint)
    {
      string equals = "";
      string dash = "";
      for (int i = 0; i < serviceEndpoint.Address.Uri.AbsoluteUri.Length + 15; i++)
      {
        equals += "=";
        dash += "-";
      }

      string output = equals + Environment.NewLine;
      output += "Starting Service" + Environment.NewLine;
      output += dash + Environment.NewLine;
      output += string.Format("{0,10} : {1,9:C2}", "Service", serviceEndpoint.Name) + Environment.NewLine;
      output += string.Format("{0,10} : {1,9:C2}", "Contract", serviceEndpoint.Contract.Name) + Environment.NewLine;
      output += string.Format("{0,10} : {1,9:C2}", "URI", serviceEndpoint.Address.Uri.AbsoluteUri) + Environment.NewLine;
      output += equals + Environment.NewLine;

      return output;
    }
  }
}
