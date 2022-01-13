using Autofac.Core;
using Autofac.Integration.Wcf;
using ScaffelPikeLib;
using System;
using System.ServiceModel;

namespace ScaffelPikeHost
{
  internal class Program
  {
    static void Main(string[] args)
    {
      // Step 1: Create a URI to serve as the base address.
      //Uri baseAddress = new Uri("http://localhost:8080/ScaffelPikeService/");
      using (var container = Bootstrapper.RegisterContainerBuilder().Build())
      {
        // Step 2: Create a ServiceHost instance.
        ServiceHost selfHost = new ServiceHost(typeof(ScaffelPikeService));
        try
        {
          //// Step 3: Add a service endpoint.
          //selfHost.AddServiceEndpoint(typeof(IScaffelPikeService), new WSHttpBinding(), "ScaffelPikeService");
          //// Step 4: Enable metadata exchange.
          //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
          //smb.HttpGetEnabled = true;
          //selfHost.Description.Behaviors.Add(smb);

          IComponentRegistration registration;
          if (!container.ComponentRegistry.TryGetRegistration
                   (new TypedService(typeof(IScaffelPikeService)), out registration))
          {
            Console.WriteLine("The service contract has not been registered in the container.");

            Console.ReadLine();
            Environment.Exit(-1);
          }

          selfHost.AddDependencyInjectionBehavior<IScaffelPikeService>(container);

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
          Console.ReadLine();
        }
      }
    }
  }
}
