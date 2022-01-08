using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScaffelPikeDataAccess.DbAccess;
using ScaffelPikeDataAccess.Models;

namespace ScaffelPikeDataAccess.Data
{
  public class UserData
  {
    readonly ISqlDataAccess _db;
    public UserData(ISqlDataAccess db)
    {
      _db = db;
    }

    public UserData()
    {
      _db = new SqlDataAccess();
    }
    public Task<IEnumerable<UserModel>> GetUsers() =>
      _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });


    public async Task<UserModel> GetUser(int id)
    {
      var result = await _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_Get", new { Id = id });
      return result.FirstOrDefault();
    }

    public Task InsertUser(UserModel user) =>
        _db.SaveDate(storedProcedure: "dbo.spUser_Insert",
          new { user.FirstName, user.Surname, user.Username, user.Password });

    public Task DeleteUser(int id) =>
      _db.SaveDate(storedProcedure: "dbo.spUser_Delete", new { Id = id });

    public Task UpdateUser(UserModel user) =>
      _db.SaveDate(storedProcedure: "dbo.spUser_Update", user);
  }
}
