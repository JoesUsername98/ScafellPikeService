using Autofac;
using ScaffelPikeLogger;

namespace ScaffelPikeClient
{
  internal class Program
  {
    static void Main(string[] args)
    {
      using (var container = Bootstrapper.RegisterContainerBuilder().Build().BeginLifetimeScope())
      {
        var client  = container.Resolve<ScaffelPikeServiceClient.IScaffelPikeService>();
        var f = new LogInScreen(client, container.Resolve<ILogger>());
        f.ShowDialog();
      }
    }
  }
}
