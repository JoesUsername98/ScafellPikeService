using Autofac;
using ScaffelPikeDataAccess.Data;
using ScaffelPikeDataAccess.DbAccess;
using ScaffelPikeContracts;
using ScaffelPikeLogger;
using ScaffelPikeLogger.Configuration;
using ScaffelPikeServices;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

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
      builder.Register(c => new ScaffelPikeService(c.Resolve<ILogger>(), c.Resolve<IUserData>(), ConfigurationManager.AppSettings["Environment"], getApiKeys())).As<IScaffelPikeService>();
      return builder;
    }
    private static ApiKeys getApiKeys()
    {
      ApiKeys keys;
      using (StreamReader r = new StreamReader("secrets.json"))
      {
        string json = r.ReadToEnd();
        keys = JsonConvert.DeserializeObject<ApiKeysConfig>(json).ApiKeys;
      }
      return keys;
    }
  }
}
