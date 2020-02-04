using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessCore
{
  public class SqlDataAccess : ISqlDataAccess
  {
    private readonly IConfiguration _config;

    public string ConnectionStringName { get; set; } = "ChartTestConnection";

    public SqlDataAccess(IConfiguration config)
    {
      _config = config;
    }

    public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
    {
      string connectionString = _config.GetConnectionString(ConnectionStringName);
      using IDbConnection connection = new SqlConnection(connectionString);
      var data = await connection.QueryAsync<T>(sql, parameters);
      Console.WriteLine("SQL from data-access string = " + sql);
      return data.ToList();
    }

    public async Task<IEnumerable<T>> LoadChart<T, U>(string sql, U parameters)
    {
      string connectionString = _config.GetConnectionString(ConnectionStringName);
      using IDbConnection connection = new SqlConnection(connectionString);
      var data = await connection.QueryAsync<T>(sql, parameters);
      Console.WriteLine("SQL from data-access string = " + sql);
      return data;
    }

    public async Task SaveData<T>(string sql, T parameters)
    {
      string connectionString = _config.GetConnectionString(ConnectionStringName);
      using IDbConnection connection = new SqlConnection(connectionString);
      await connection.ExecuteAsync(sql, parameters);
    }
  }
}
