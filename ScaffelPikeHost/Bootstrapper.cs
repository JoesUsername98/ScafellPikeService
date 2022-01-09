using Autofac;
using ScaffelPikeLib;

namespace ScaffelPikeHost
{
  internal class Bootstrapper
  {
    public static ContainerBuilder RegisterContainerBuilder()
    {
      ContainerBuilder builder = new ContainerBuilder();
      builder.Register(c => new ScaffelPikeLogger()).As<IScaffelPikeLogger>();
      builder.Register(c => new ScaffelPikeService(c.Resolve<IScaffelPikeLogger>())).As<IScaffelPikeService>();
      return builder;
    }
  }
}
