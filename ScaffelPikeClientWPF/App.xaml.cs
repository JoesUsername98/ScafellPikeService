using System;
using System.ServiceModel;
using Autofac;
using Autofac.Integration.Wcf;
using ScafellPikeClientWPF.Controller;
using ScafellPikeClientWPF.Models;
using ScafellPikeContracts;
using ScafellPikeClientWPF.Views;
using System.Windows;
using ScafellPikeClientWPF;

namespace ScafellPikeClientWPF
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    public App()
    {
      Bootstrapper.RegisterContainerBuilder();
      try
      {
        ClientRefs.Configure();
        var view = new LogInViewWPF();
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
