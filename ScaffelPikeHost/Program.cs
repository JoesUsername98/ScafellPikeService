using Autofac.Core;
using Autofac.Integration.Wcf;
using ScaffelPikeContracts;
using ScaffelPikeServices;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ScaffelPikeHost
{
  internal class Program
  {
    static void Main()
    {
      Bootstrapper.RegisterContainerBuilder();
      ServiceHost selfHost = new ServiceHost(typeof(ScaffelPikeService));
      try
      {
        if (!AutofacHostFactory.Container.ComponentRegistry.TryGetRegistration(new TypedService(typeof(IScaffelPikeService)), out _))
        {
          Console.WriteLine("The service contract has not been registered in the container.");

          Console.ReadLine();
          Environment.Exit(-1);
        }

        selfHost.AddDependencyInjectionBehavior<IScaffelPikeService>(AutofacHostFactory.Container);

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
