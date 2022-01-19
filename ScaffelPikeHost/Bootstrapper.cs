using Autofac;
using ScaffelPikeDataAccess.Data;
using ScaffelPikeDataAccess.DbAccess;
using ScaffelPikeContracts;
using ScaffelPikeLogger;
using ScaffelPikeLogger.Configuration;
using ScaffelPikeServices;
using System.Configuration;

namespace ScaffelPikeHost
{
  internal class Bootstrapper
  {
    public static ContainerBuilder RegisterContainerBuilder()
    {
      ContainerBuilder builder = new ContainerBuilder();
      builder.Register(c => new TextLogger((LoggerConfiguration)ConfigurationManager.GetSection("LoggerConfiguration"))).As<ILogger>();
      builder.Register(c => new SqlDataAccess(ConfigurationManager.ConnectionStrings)).As<ISqlDataAccess>();
      builder.Register(c => new UserData(c.Resolve<ISqlDataAccess>())).As<IUserData>();
      builder.Register(c => new ScaffelPikeService(c.Resolve<ILogger>(), c.Resolve<IUserData>(), ConfigurationManager.AppSettings["Environment"]) ).As<IScaffelPikeService>();
      return builder;
    }
  }
}
