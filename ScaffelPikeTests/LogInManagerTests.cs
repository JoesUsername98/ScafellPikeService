using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Moq;
using ScaffelPikeContracts;
using ScaffelPikeDataAccess.Data;
using ScaffelPikeServices;
using Xunit;

namespace ScaffelPikeTests
{
  /// <summary>
  /// Given -> Namespace
  /// When -> Class
  /// Then -> Test/Function
  /// </summary>
  public class LogInManagerTests
  {
    [Fact]
    public async void ProcessLogInRequestAsync_ValidCallAutoMock()
    {
      ////ARRANGE
      //int id = 0;
      //var moqUserData = new Mock<IUserData>();
      //moqUserData.Setup(x => x.GetUsers()).Returns(Task.FromResult(GetSampleUsers()));
      //moqUserData.Setup(x => x.GetUser(id)).Returns(Task.FromResult(GetSampleUsers().FirstOrDefault(u => u.Id == id)));
      //var moqInstanceUserData = moqUserData.Object;

      //ServiceReferences.Configure(moqInstanceUserData;

      //  mock.Mock<ISqlDataAccess>()
      //    .Setup(x => x.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { }, "Default"))
      //    .Returns(Task.FromResult(GetSampleUsers()));
      //  //mock.Mock<IEnumerable<dynamic>>()
      //  // .Setup(m => m.Count).Returns(() => items.Count);

      //  var moqUserModel = mock.Create<UserData>();
      //  var expected = GetSampleUsers();
      //  //ACT
      //  var actual = await moqUserModel.GetUsers();
      //  //ASSERT
      //  Assert.NotNull(expected);
      //  foreach (var user in expected)
      //  {
      //    Assert.True(user.Equals(actual.First(a => a.FirstName == user.FirstName)));
      //  }
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
