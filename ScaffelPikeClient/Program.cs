namespace ScaffelPikeClient
{
  internal class Program
  {
    static void Main(string[] args)
    {
      ScaffelPikeServiceClient.ScaffelPikeServiceClient client = new ScaffelPikeServiceClient.ScaffelPikeServiceClient();
      //new LogInCLI(client);
      LogInScreen f = new LogInScreen(client);
      f.ShowDialog();
    }
  }
}
