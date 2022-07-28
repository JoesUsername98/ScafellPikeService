using System;
using System.ServiceModel;
using Autofac;
using Autofac.Integration.Wcf;
using ScafellPikeClient.Controller;
using ScafellPikeClient.Models;
using ScafellPikeClient.View;
using ScafellPikeContracts;
using ScafellPikeLogger;

namespace ScafellPikeClient
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
        AutofacHostFactory.Container.Resolve<ChannelFactory<IScafellPikeService>>().Abort();
      }
      finally
      {
        AutofacHostFactory.Container.Resolve<ChannelFactory<IScafellPikeService>>().Close();
      }
    }
  }
}
