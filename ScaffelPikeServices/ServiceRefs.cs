using System;
using Autofac;
using Autofac.Integration.Wcf;
using ScafellPikeContracts;
using ScafellPikeDataAccess.Data;
using ScafellPikeLogger;

namespace ScafellPikeServices
{

  //Consider Container Injection in the future
  //https://stackoverflow.com/questions/2042609/injecting-data-to-a-wcf-service/2042858#2042858
  /// <summary>
  /// Used to hold DI objects in the future
  /// </summary>
  public static class ServiceRefs
  {
    public static ILogger Log { get { return AutofacHostFactory.Container.Resolve<ILogger>(); }}
    public static IUserData UserDA { get { return AutofacHostFactory.Container.Resolve<IUserData>(); } }
    public static string Env { get; private set; }
    public static Guid ServerGuid { get; private set; }
    public static DateTime ServerStarTime { get; private set; }

    internal static void Configure(string env, Guid serverGuid)
    {
      Env = env;
      ServerGuid = serverGuid;
      ServerStarTime = DateTime.Now;
    }
  }
}
