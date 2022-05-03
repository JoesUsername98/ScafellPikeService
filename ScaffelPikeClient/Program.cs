using System;
using System.ServiceModel;
using Autofac;
using ScaffelPikeClient.Controller;
using ScaffelPikeClient.Models;
using ScaffelPikeClient.View;
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
          var view = new LogInView();
          var model = new LogInModel() { Username = "", Password = "", Connections = 0 };
          var controller = new LogInController(view, model);
          view.ShowDialog();
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
