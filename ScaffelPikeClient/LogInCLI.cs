using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeClient.ScaffelPikeServiceReference;

namespace ScaffelPikeClient
{
  internal class LogInCLI
  {
    public LogInCLI(ScaffelPikeServiceClient client)
    {
      ////Step 1: Create an instance of the WCF proxy.
      bool loop = true;
      try
      {
        Console.WriteLine("Enter STOP to close the client");
        while (loop)
        {
          // Step 2: Call the service operations.
          Console.WriteLine("Enter Username: ");
          var username = Console.ReadLine();
          Console.WriteLine("Enter Password: ");
          var password = Console.ReadLine();
          Console.WriteLine($"Input: {username} and {password}\n");

          loop = (username.ToLower() != "stop" && password.ToLower() != "stop");
          if (!loop)
            continue;

          var output = client.LogIn(username, password);
          Console.WriteLine($"Sucessful: {output.Success}\nName: {output.OtherData}");
          Console.WriteLine();
        }

        // Step 3: Close the client to gracefully close the connection and clean up resources.
        client.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        Console.ReadLine();
        client.Abort();
      }
    }
  }
}
