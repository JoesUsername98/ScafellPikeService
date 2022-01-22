using System.Collections.Generic;
using System.Threading.Tasks;
using ScaffelPikeContracts;

namespace ScaffelPikeDataAccess.Data
{
  public interface IUserData
  {
    Task<UserModel> GetUser(int id);
    Task<IEnumerable<UserModel>> GetUsers();
  }
}