using System;
using System.Configuration;
using ScaffelPikeContracts;
using ScaffelPikeLogger;

namespace ScaffelPikeClient
{

  //Consider Container Injection in the future
  //https://stackoverflow.com/questions/2042609/injecting-data-to-a-wcf-service/2042858#2042858
  /// <summary>
  /// Used to hold DI objects in the future
  /// </summary>
  public static class ClientRefs
  {
    public static ILogger Log { get; private set; }
    public static string Env { get; private set; }
    public static Guid ClientGuid { get; private set; }
    public static DateTime ClientStarTime { get; private set; }
    public static IScaffelPikeService ScaffelPikeChannel { get; private set; }
    public static UserModel User { get; private set; }

    internal static void Configure(ILogger logger,IScaffelPikeService scaffelPikeChannel)
    {
      Log = logger;
      Env = ConfigurationManager.AppSettings["Environment"];
      ClientGuid = Guid.NewGuid();
      ClientStarTime = DateTime.Now;
      ScaffelPikeChannel = scaffelPikeChannel;
      
    }

    internal static void RegisterUser(LogInResponse user)
    {
      if (User != null)
      {
        Log.Error("RegisterUser", "User already registerd!");
        throw new InvalidOperationException("Cannot register user more than once");
      }

      User = new UserModel();
      User.Admin = user.Admin;
      User.FirstName = user.FirstName;
      User.Surname = user.Surname;
    }
  }
}
