using ScaffelPikeLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeHost
{
  internal class Program
  {
    static void Main(string[] args)
    {
      // Step 1: Create a URI to serve as the base address.
      Uri baseAddress = new Uri("http://localhost:8080/ScaffelPikeService/");

      // Step 2: Create a ServiceHost instance.
      ServiceHost selfHost = new ServiceHost(typeof(ScaffelPikeService), baseAddress);
      try
      {
        // Step 3: Add a service endpoint.
        selfHost.AddServiceEndpoint(typeof(IScaffelPikeService), new WSHttpBinding(), "ScaffelPikeService");
        // Step 4: Enable metadata exchange.
        ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
        smb.HttpGetEnabled = true;
        selfHost.Description.Behaviors.Add(smb);

        // Step 5: Start the service.
        selfHost.Open();
        Console.WriteLine("The service is ready.");

        foreach (var endpoint in selfHost.Description.Endpoints)
        {
          Console.WriteLine("-------------------------------------------------");
          Console.WriteLine(endpoint.Address.Uri.ToString());
          Console.WriteLine("-------------------------------------------------");
        }

        // Close the ServiceHost to stop the service.

        Console.WriteLine("Enter q to terminate the service.");
        Console.WriteLine();
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
      }
    }
  }
}
