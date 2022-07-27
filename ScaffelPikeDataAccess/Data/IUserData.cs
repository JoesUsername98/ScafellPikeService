using System.Collections.Generic;
using System.Threading.Tasks;
using ScafellPikeContracts;

namespace ScafellPikeDataAccess.Data
{
  public interface IUserData
  {
    Task<UserModel> GetUser(int id);
    Task<IEnumerable<UserModel>> GetUsers();
  }
}