using Autofac;
using ScaffelPikeLib;
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
      builder.Register(c => new ScaffelPikeServiceClient.ScaffelPikeServiceClient()).As<ScaffelPikeServiceClient.IScaffelPikeService>();
      return builder;
    }
  }
}
