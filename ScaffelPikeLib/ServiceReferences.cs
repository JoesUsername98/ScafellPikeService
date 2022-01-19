using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDataAccess.Data;
using ScaffelPikeLogger;

namespace ScaffelPikeLib
{
  //Used To hold DI objects
  public static class ServiceReferences
  {
    public static ILogger Logger { get; private set; }
    public static IUserData UserDA { get; private set; }
    public static string Env { get; private set; }
    public static Guid ServerGuid { get; private set; }
    public static DateTime ServerStarTime { get; private set; }

    internal static void Configure(ILogger logger, IUserData userDA, string env)
    {
      Logger = logger;
      UserDA = userDA;
      Env = env;
      ServerGuid = Guid.NewGuid();
      ServerStarTime = DateTime.Now;
    }
  }
}
