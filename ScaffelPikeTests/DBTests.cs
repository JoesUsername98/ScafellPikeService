using Autofac.Extras.Moq;
using Moq;
using ScaffelPikeContracts;
using ScaffelPikeDataAccess.Data;
using ScaffelPikeDataAccess.DbAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ScaffelPikeTests
{
  public class DBTests
  {
    [Fact]
    public async void GetUsers_ValidCall()
    {
      //ARRANGE
      int id = 0;
      var moqUserData = new Mock<IUserData>();
      moqUserData.Setup(x => x.GetUsers()).Returns(Task.FromResult(GetSampleUsers()));
      moqUserData.Setup(x => x.GetUser(id)).Returns(Task.FromResult(GetSampleUsers().FirstOrDefault(u => u.Id == id)));
      var moqInstanceUserData = moqUserData.Object;
      //ACT
      var actual = await moqInstanceUserData.GetUsers();
      var expected = await Task.FromResult(GetSampleUsers());
      //ASSERT
      Assert.NotNull(expected);
      foreach (var user in expected)
      {
        Assert.True(user.Equals(actual.First(a => a.FirstName == user.FirstName)));
      }
    }

    [Fact]
    public async void GetUser_ValidCall()
    {
      //ARRANGE
      foreach (var id in GetSampleUsers().Select(u => u.Id))
      {
        var moqUserData = new Mock<IUserData>();
        moqUserData.Setup(x => x.GetUsers()).Returns(Task.FromResult(GetSampleUsers()));
        moqUserData.Setup(x => x.GetUser(id)).Returns(Task.FromResult(GetSampleUsers().FirstOrDefault(u => u.Id == id)));
        var moqInstanceUserData = moqUserData.Object;
        //ACT
        var actual = await moqInstanceUserData.GetUser(id);
        var expected = await Task.FromResult(GetSampleUsers().FirstOrDefault(u => u.Id == id));
        //ASSERT
        Assert.NotNull(expected);
        Assert.True(expected.Equals(actual));
      }
    }

    [Fact]
    public async void GetUser_InValidCall()
    {
      //ARRANGE
      int id = -1;
      var moqUserData = new Mock<IUserData>();
      moqUserData.Setup(x => x.GetUsers()).Returns(Task.FromResult(GetSampleUsers()));
      moqUserData.Setup(x => x.GetUser(id)).Returns(Task.FromResult(GetSampleUsers().FirstOrDefault(u => u.Id == id)));
      var moqInstanceUserData = moqUserData.Object;
      //ACT
      var actual = await moqInstanceUserData.GetUser(id);
      var expected = await Task.FromResult(GetSampleUsers().FirstOrDefault(u => u.Id == id));
      //ASSERT
      Assert.Null(expected);
      Assert.Null(actual);
    }

    private IEnumerable<UserModel> GetSampleUsers()
    {
      UserModel user1 = new UserModel() {
        FirstName = "Joe",
        Surname = "Osborne",
        Username = "JoesUsername",
        Password = "Ozzy1",
        Id = 10,
        Admin = true
      };

      UserModel user2 = new UserModel() {
        FirstName = "Mark",
        Surname = "Zucc",
        Username = "LizardMan",
        Password = "MetaIsCool",
        Id = 9,
        Admin = false
      };

      UserModel user3 = new UserModel() {
        FirstName = "Tony",
        Surname = "Stark",
        Username = "TonyS",
        Password = "Peppa",
        Id = 11,
        Admin = false
      };

      UserModel user4 = new UserModel() {
        FirstName = "Elon",
        Surname = "Musk",
        Username = "ElonM",
        Password = "MelonUsk",
        Id = 12,
        Admin = false
      };

      var sampleUsers = new List<UserModel>() { user1, user2, user3, user4 };
      return sampleUsers;
    }
  }
}