using System.ServiceModel.Channels;
using Autofac;
using ScaffelPikeContracts;
using ScaffelPikeLogger;

namespace ScaffelPikeClient
{
  internal class Program
  {
    static void Main(string[] args)
    {
      using (var container = Bootstrapper.RegisterContainerBuilder().Build())
      {
        ClientReferences.Configure(container.Resolve<ILogger>(), container.Resolve<IScaffelPikeService>());
        var f = new LogInScreen();
        f.ShowDialog();

      }
    }
  }
}
