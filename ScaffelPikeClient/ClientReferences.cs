﻿using System;
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
  public static class ClientReferences
  {
    public static ILogger Logger { get; private set; }
    public static string Env { get; private set; }
    public static Guid ClientGuid { get; private set; }
    public static DateTime ClientStarTime { get; private set; }
    public static IScaffelPikeService ScaffelPikeChannel { get; private set; }

    internal static void Configure(ILogger logger,IScaffelPikeService scaffelPikeChannel)
    {
      Logger = logger;
      Env = ConfigurationManager.AppSettings["Environment"];
      ClientGuid = Guid.NewGuid();
      ClientStarTime = DateTime.Now;
      ScaffelPikeChannel = scaffelPikeChannel;
    }
  }
}