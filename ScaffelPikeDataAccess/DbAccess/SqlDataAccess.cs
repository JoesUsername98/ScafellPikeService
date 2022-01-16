using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Configuration;

namespace ScaffelPikeDataAccess.DbAccess
{
  public class SqlDataAccess : ISqlDataAccess
  {
    private readonly ConnectionStringSettingsCollection _conStrings;
    public SqlDataAccess(ConnectionStringSettingsCollection connectionString)
    {
      _conStrings = connectionString;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(
      string storedProcedure,
      U parameters,
      string connectionId = "Default")
    {
      using (IDbConnection connection = new SqlConnection(_conStrings[connectionId].ConnectionString))
      {
        return await connection.QueryAsync<T>(storedProcedure, parameters,
          commandType: CommandType.StoredProcedure);
      }
    }

    public async Task SaveDate<T>(
      string storedProcedure,
      T parameters,
      string connectionId = "Default")
    {
      using (IDbConnection connection = new SqlConnection(_conStrings[connectionId].ConnectionString))
      {
        await connection.ExecuteAsync(storedProcedure, parameters,
          commandType: CommandType.StoredProcedure);
      }
    }
  }
}
