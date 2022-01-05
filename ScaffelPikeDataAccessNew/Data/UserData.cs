using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDataAccess.DbAccess;
using ScaffelPikeDataAccess.Models;

namespace ScaffelPikeDataAccess.Data
{
  public class UserData : IUserData
  {
    private readonly ISqlDataAccess _db;
    public UserData(ISqlDataAccess db)
    {
      _db = db;
    }

    public Task<IEnumerable<UserModel>> GetUsers() =>
      _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });

    public async Task<UserModel?> GetUser(int id)
    {
      var result = await _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_Get", new { Id = id });
      return result.FirstOrDefault();
    }

    public Task InsertUser(UserModel user) =>
      _db.SaveDate(storedProcedure: "dbo.spUser_Insert", new { user.FirstName, user.Surname, user.Username, user.Password });

    public Task UpdateUser(UserModel user) =>
      _db.SaveDate(storedProcedure: "dbo.spUser_Update", user);

    public Task DeleteUser(int id) => _db.SaveDate(storedProcedure: "dbo.spuUser_Update", new { Id = id });
  }
}
