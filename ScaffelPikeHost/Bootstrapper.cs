using Autofac;
using ScaffelPikeLib;
using ScaffelPikeLogger;
using ScaffelPikeLogger.Configuration;
using System.Configuration;

namespace ScaffelPikeHost
{
  internal class Bootstrapper
  {
    public static ContainerBuilder RegisterContainerBuilder()
    {
      ContainerBuilder builder = new ContainerBuilder();
      builder.Register(c => new TextLogger((LoggerConfiguration)ConfigurationManager.GetSection("LoggerConfiguration"))).As<ILogger>();
      builder.Register(c => new ScaffelPikeService(c.Resolve<ILogger>())).As<IScaffelPikeService>();
      return builder;
    }
  }
}
