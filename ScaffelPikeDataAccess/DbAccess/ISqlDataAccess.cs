using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScafellPikeDataAccess.DbAccess
{
  public interface ISqlDataAccess
  {
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
    Task SaveDate<T>(string storedProcedure, T parameters, string connectionId = "Default");
  }
}