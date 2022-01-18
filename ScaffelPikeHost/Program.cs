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

          var service = selfHost.Description.Behaviors.Find<AutofacDependencyInjectionServiceBehavior>();

          foreach (var endpoint in selfHost.Description.Endpoints)
          {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(endpoint.Address.Uri.ToString());
            Console.WriteLine("-------------------------------------------------");
          }

          Console.WriteLine("The service is ready.");
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
