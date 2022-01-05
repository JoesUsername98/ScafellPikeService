using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ScaffelPikeDataAccess.DbAccess;

internal class SqlDataAccess : ISqlDataAccess
{
  private readonly IConfiguration _config;

  internal SqlDataAccess(IConfiguration config)
  {
    this._config = config;
  }

  public async Task<IEnumerable<T>> LoadData<T, U>(
    string storedProcedure,
    U parameters,
    string connectionId = "Default")
  {
    using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId)))
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
    using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId)))
    {
      await connection.ExecuteAsync(storedProcedure, parameters,
        commandType: CommandType.StoredProcedure);
    }
  }
}