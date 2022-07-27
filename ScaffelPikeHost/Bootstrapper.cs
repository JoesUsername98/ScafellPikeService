using Autofac;
using ScafellPikeDataAccess.Data;
using ScafellPikeDataAccess.DbAccess;
using ScafellPikeContracts;
using ScafellPikeLogger;
using ScafellPikeLogger.Configuration;
using ScafellPikeServices;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using System;
using Autofac.Integration.Wcf;

namespace ScaffelPikeHost
{
  internal class Bootstrapper
  {
    public static void RegisterContainerBuilder()
    {
      ContainerBuilder builder = new ContainerBuilder();
      builder.Register(c => new TextLogger((LoggerConfiguration)ConfigurationManager.GetSection("LoggerConfiguration"))).As<ILogger>();
      builder.Register(c => new SqlDataAccess(ConfigurationManager.ConnectionStrings)).As<ISqlDataAccess>();
      builder.Register(c => new UserData(c.Resolve<ISqlDataAccess>())).As<IUserData>();
      builder.Register(c => new ScaffelPikeService(ConfigurationManager.AppSettings["Environment"], new Guid())).As<IScaffelPikeService>();
      AutofacHostFactory.Container = builder.Build();
    }
  }
}
