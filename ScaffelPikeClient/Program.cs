using ScaffelPikeClient.ScaffelPikeServiceReference;
using ScaffelPikeLib;
using System;
using System.Threading.Tasks;

namespace ScaffelPikeClient
{
  internal class Program
  {
    static void Main(string[] args)
    {
      ScaffelPikeServiceClient client = new ScaffelPikeServiceClient();
      //new LogInCLI(client);
      LogInScreen f = new LogInScreen(client);
      f.ShowDialog();
    }
  }
}
