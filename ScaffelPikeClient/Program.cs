using System;
using System.ServiceModel;
using Autofac;
using Autofac.Integration.Wcf;
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
    static void Main()
    {
      Bootstrapper.RegisterContainerBuilder();
      try
      {
        ClientRefs.Configure();
        var view = new LogInView();
        var model = new LogInModel();
        var controller = new LogInController(view, model);
        view.ShowDialog();
      }
      catch (Exception ex)
      {
        AutofacHostFactory.Container.Resolve<ChannelFactory<IScaffelPikeService>>().Abort();
      }
      finally
      {
        AutofacHostFactory.Container.Resolve<ChannelFactory<IScaffelPikeService>>().Close();
      }
    }
  }
}
