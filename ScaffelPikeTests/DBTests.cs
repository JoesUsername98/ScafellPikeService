using ScaffelPikeDataAccess.Data;
using ScaffelPikeDataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ScaffelPikeTests
{
  public class DBTests
  {
    //private void CleanseDb()
    //{
    //  var clientsRequest = UserData.GetUsers();
    //  clientsRequest.Wait();

    //  foreach(var client in clientsRequest.Result)
    //    new UserData().DeleteUser(client.Id);

    //  UserModel user1 = new UserModel() 
    //  {
    //    FirstName = "Joe",
    //    Surname = "Osborne",
    //    Username = "JoesUsername",
    //    Password = "Ozzy1",
    //    Admin = true
    //  };
    //  new UserData().InsertUser(user1);

    //  UserModel user2 = new UserModel() 
    //  {
    //    FirstName = "Mark",
    //    Surname = "Zucc",
    //    Username = "LizardMan",
    //    Password = "MetaIsCool",
    //    Admin = false
    //  };
    //  new UserData().InsertUser(user2);

    //  UserModel user3 = new UserModel() 
    //  {
    //    FirstName = "Tony",
    //    Surname = "Stark",
    //    Username = "TonyS",
    //    Password = "Peppa",
    //    Admin = false
    //  };
    //  new UserData().InsertUser(user3);

    //  UserModel user4 = new UserModel() 
    //  {
    //    FirstName = "Elon",
    //    Surname = "Musk",
    //    Username = "ElonM",
    //    Password = "MelonUsk",
    //    Admin = false
    //  };
    //  new UserData().InsertUser(user4);
    //}

    ////TODO: Change to Use Moq and Mocking

    //[Fact]
    //public void GetAllUsers()
    //{
    //  CleanseDb();

    //  var clientsRequest = new UserData().GetUsers();
    //  clientsRequest.Wait();
    //  Assert.Equal(4, clientsRequest.Result.Count());
    //}
    //[Fact]
    //public void GetOneUser()
    //{
    //  CleanseDb();

    //  var allClientsRequest = new UserData().GetUsers();
    //  allClientsRequest.Wait();
    //  var allClients = allClientsRequest.Result;

    //  bool pass = true;
    //  foreach (var client in allClients)
    //  {
    //    var oneClientRequest = new UserData().GetUser(client.Id);
    //    oneClientRequest.Wait();
    //    pass = pass && oneClientRequest.Result.Equals(client);
    //  }

    //  Assert.True(pass);
    //}
    //[Fact]
    //public void UpdateUser()
    //{
    //  CleanseDb();

    //  var AllClientRequest = new UserData().GetUsers();
    //  AllClientRequest.Wait();
    //  var clientToUpdate = AllClientRequest.Result.First();
      
    //  clientToUpdate.Password = "Password123";

    //  new UserData().UpdateUser(clientToUpdate);
    //  var oneClientRequest = new UserData().GetUser(clientToUpdate.Id);
    //  oneClientRequest.Wait();
    //  clientToUpdate = oneClientRequest.Result;

    //  Assert.Equal("Password123", clientToUpdate.Password);
    //}
    //[Fact]
    //public void DeleteUser()
    //{
    //  CleanseDb();

    //  new UserData().DeleteUser(1);

    //  var oneClientRequest = new UserData().GetUser(1);
    //  oneClientRequest.Wait();
    //  var clientToCompare = oneClientRequest.Result;

    //  Assert.Null(clientToCompare);
    //}
    //[Fact]
    //public void InsertUser()
    //{
    //  CleanseDb();

    //  var clientsRequest = new UserData().GetUsers();
    //  clientsRequest.Wait();
    //  var allUsersBefore = clientsRequest.Result;

    //  UserModel userToAdd = new UserModel() 
    //  {
    //    FirstName = "New",
    //    Surname = "User",
    //    Username = "NewUser",
    //    Password = "fido"
    //  };

    //  new UserData().InsertUser(userToAdd);

    //  clientsRequest = new UserData().GetUsers();
    //  clientsRequest.Wait();
    //  var allUsersAfter = clientsRequest.Result;

    //  var addedUser = allUsersAfter.FirstOrDefault(u => u.Username == userToAdd.Username);
    //  var nullUser = allUsersBefore.FirstOrDefault(u => u.Username == userToAdd.Username);

    //  Assert.NotNull(addedUser);
    //  Assert.Null(nullUser);
    //}
  }
}