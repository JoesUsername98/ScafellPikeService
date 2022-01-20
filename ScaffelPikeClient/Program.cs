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
        var client = container.Resolve<IScaffelPikeService>();
        var f = new LogInScreen(client, container.Resolve<ILogger>());
        f.ShowDialog();

      }
    }
  }
}
