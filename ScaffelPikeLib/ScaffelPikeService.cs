﻿using System;
using System.Threading.Tasks;
using ScaffelPikeDataAccess.Data;
using ScaffelPikeLib;
using System.Linq;

namespace ScaffelPikeLib
{
  public class ScaffelPikeService : IScaffelPikeService
  {
    private readonly string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = ScaffelPikeDB;" +
                                          @"Integrated Security = True; Connect Timeout = 30; Encrypt=False;" +
                                          @"TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    public async Task<PasswordDto> LogIn(string username, string password)
    {
      return await Task<PasswordDto>.Factory.StartNew(() => {
        return doLogIn(username, password);
      });
    }
    private PasswordDto doLogIn(string username, string password)
    {
      Console.WriteLine($"Recieved Log In Request with Username: {username}, Password: {password}");

      var clientsRequest = new UserData().GetUsers();
      clientsRequest.Wait();
      var client = clientsRequest.Result.FirstOrDefault(c => c.Username == username && c.Password == password);

      if (client !=null)
      {
        Console.WriteLine("Successful");
        return new PasswordDto() { Success = true, OtherData = client.FirstName + client.Surname };
      }

      Console.WriteLine("Failed");
      return new PasswordDto() { Success = false, OtherData = "" };
    }
  }
}