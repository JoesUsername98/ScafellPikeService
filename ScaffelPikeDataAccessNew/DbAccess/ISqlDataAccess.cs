using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeDataAccess.DbAccess;

public interface ISqlDataAccess
{
  Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
  Task SaveDate<T>(string storedProcedure, T parameters, string connectionId = "Default");
}
