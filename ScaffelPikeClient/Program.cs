using System;
using System.ServiceModel;
using Autofac;
using ScaffelPikeContracts;
using ScaffelPikeLogger;

namespace ScaffelPikeClient
{
  internal class Program
  {
    [STAThread]
    static void Main(string[] args)
    {
      using (var container = Bootstrapper.RegisterContainerBuilder().Build())
      {
        try
        {
          ClientRefs.Configure(container.Resolve<ILogger>(), container.Resolve<IScaffelPikeService>());
          var f = new LogInView();
          f.ShowDialog();
        }
        catch (Exception ex)
        {
          container.Resolve<ChannelFactory<IScaffelPikeService>>().Abort();
        }
        finally
        {
          container.Resolve<ChannelFactory<IScaffelPikeService>>().Close();
        }
      }
    }
  }
}
