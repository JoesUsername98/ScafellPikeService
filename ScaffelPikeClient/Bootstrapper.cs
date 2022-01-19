using Autofac;
using ScaffelPikeContracts;
using ScaffelPikeLogger;
using ScaffelPikeLogger.Configuration;
using System.Configuration;
using System.ServiceModel;

namespace ScaffelPikeClient
{
  internal class Bootstrapper
  {
    public static ContainerBuilder RegisterContainerBuilder()
    {
      ContainerBuilder builder = new ContainerBuilder();
      builder.Register(c => new TextLogger((LoggerConfiguration)ConfigurationManager.GetSection("LoggerConfiguration"))).As<ILogger>();
      builder.Register(c => new ScaffelPikeServiceClient(
        c.Resolve<ILogger>(), ConfigurationManager.AppSettings["Environment"])).As<IScaffelPikeService>();
      return builder;
    }
  }
}
