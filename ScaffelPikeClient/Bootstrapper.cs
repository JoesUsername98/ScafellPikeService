using Autofac;
using ScaffelPikeContracts;
using ScaffelPikeLogger;
using ScaffelPikeLogger.Configuration;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ScaffelPikeClient
{
  internal class Bootstrapper
  {
    public static ContainerBuilder RegisterContainerBuilder()
    {
      ContainerBuilder builder = new ContainerBuilder();
      builder.Register(c => new TextLogger((LoggerConfiguration)ConfigurationManager.GetSection("LoggerConfiguration"))).As<ILogger>();
      builder.Register(c => new ChannelFactory<IScaffelPikeService>("WSHttpBinding_IScaffelPikeService").CreateChannel()).As<IScaffelPikeService>();
      builder.Register(c => 
        new ScaffelPikeServiceClient
        (
          c.Resolve<ILogger>(),
          ConfigurationManager.AppSettings["Environment"],
          c.Resolve<IScaffelPikeService>())
        ).As<IScaffelPikeServiceClient>();
      return builder;
    }
  }
}
