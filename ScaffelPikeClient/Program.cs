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
            clientLoopAsync();
        }
        static async Task clientLoopAsync()
        {
            //Step 1: Create an instance of the WCF proxy.
            ScaffelPikeServiceClient client = new ScaffelPikeServiceClient();
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

                    if (username.ToLower() == "stop" || password.ToLower() == "stop")
                    {
                        loop = false;
                        continue;
                    }
                    //PasswordDto output = client.LogIn(username, password);
                    //PasswordDto output = client.LogIn2AsyncMethod(username, password);

                    Task<PasswordDto> outputTask = client.LogIn3TaskAsync(username, password);
                    outputTask.Wait();
                    PasswordDto output = outputTask.Result;

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
