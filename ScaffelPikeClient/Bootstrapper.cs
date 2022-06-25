using Autofac;
using Autofac.Integration.Wcf;
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
    public static void RegisterContainerBuilder()
    {
      ContainerBuilder builder = new ContainerBuilder();
      builder.Register(c => new TextLogger((LoggerConfiguration)ConfigurationManager.GetSection("LoggerConfiguration"))).As<ILogger>();
      builder.Register(c => new ChannelFactory<IScaffelPikeService>("ScaffelPike")).SingleInstance();
      builder.Register(c => c.Resolve<ChannelFactory<IScaffelPikeService>>().CreateChannel()).As<IScaffelPikeService>().UseWcfSafeRelease();
      AutofacHostFactory.Container = builder.Build();
    }
  }
}
