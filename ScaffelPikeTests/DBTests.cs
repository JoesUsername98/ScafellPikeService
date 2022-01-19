
using Autofac.Extras.Moq;
using Moq;
using ScaffelPikeDataAccess.Data;
using ScaffelPikeDataAccess.DbAccess;
using ScaffelPikeDataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ScaffelPikeTests
{
  public class DBTests
  {
    //TODO: Change to Use Moq and Mocking

    [Fact]
    public async void GetUsers_ValidCall()
    {
      //Automock doesn't like tasks
      //using (var mock = AutoMock.GetLoose())
      //{
      //  mock.Mock<ISqlDataAccess>()
      //    .Setup(x => x.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { }, "Default"))
      //    .Returns(GetSampleUsersTask());

      //  var moqUserData = mock.Create<UserData>();

      //  var expected = GetSampleUsers();

      //  var actualTask = await moqUserData.GetUsers();

      //  Assert.True(actualTask != null);
      //  Assert.Equal(expected.Count(), actualTask.Count());
      //}

      var mockUserData = new Mock<ISqlDataAccess>(MockBehavior.Loose);
      mockUserData
        .Setup(m => m.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { }, "Default"))
        .Returns(GetSampleUsersTask());
      var service = new UserData(mockUserData.Object);

      var expected = GetSampleUsers();
      var actual =  await service.GetUsers();

      Assert.True(actual != null);
      Assert.Equal(expected.Count(), actual.Count());
    }

    private IEnumerable<UserModel> GetSampleUsers()
    {
      UserModel user1 = new UserModel() {
        FirstName = "Joe",
        Surname = "Osborne",
        Username = "JoesUsername",
        Password = "Ozzy1",
        Admin = true
      };

      UserModel user2 = new UserModel() {
        FirstName = "Mark",
        Surname = "Zucc",
        Username = "LizardMan",
        Password = "MetaIsCool",
        Admin = false
      };

      UserModel user3 = new UserModel() {
        FirstName = "Tony",
        Surname = "Stark",
        Username = "TonyS",
        Password = "Peppa",
        Admin = false
      };

      UserModel user4 = new UserModel() {
        FirstName = "Elon",
        Surname = "Musk",
        Username = "ElonM",
        Password = "MelonUsk",
        Admin = false
      };

      var sampleUsers =  new List<UserModel>() { user1, user2, user3, user4};
      return sampleUsers;
    }
    private Task<IEnumerable<UserModel>> GetSampleUsersTask() 
    {
      var task = new Task<IEnumerable<UserModel>>( () => GetSampleUsers());
      task.RunSynchronously();
      return task;
    }

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

    //  UserModel userToAdd = new UserModel() {
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