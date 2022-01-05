using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScaffelPikeDataAccess.DbAccess;
using ScaffelPikeDataAccess.Models;

namespace ScaffelPikeDataAccess.Data
{
    public class UserData
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
            return result.FirstOrDefault;
        }
    }
}
