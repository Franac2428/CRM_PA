using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class ConnManager : IDisposable
    {
        private readonly IDbConnection _connection;

        public ConnManager(IConfiguration config)
        {
            string connectionString = config.GetConnectionString("CRMDatabase");
            _connection = new SqlConnection(connectionString);
        }

        public T ExecStoredProcScalar<T>(string sql, object param = null)
        {
            using (var connection = _connection)
            {
                connection.Open();
                return connection.ExecuteScalar<T>(sql, param);
            }
        }
        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            using (var connection = _connection)
            {
                connection.Open();
                return connection.Query<T>(sql, param);
            }
        }

        public void Execute(string sql, object param = null)
        {
            using (var connection = _connection)
            {
                connection.Open();
                connection.Execute(sql, param);
            }
        }

        public IEnumerable<T> CallStoredProcedureList<T>(string procedureName, object parameters = null)
        {
            using (var connection = _connection)
            {
                connection.Open();
                return connection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public T CallStoredProcedure<T>(string procedureName, object parameters = null)
        {
            using (var connection = _connection)
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public int StoredProcedureReturnsInt<T>(string procedureName, DynamicParameters parameters, string paramOutputName)
        {
            using (var connection = _connection)
            {
                connection.Open();
                var result = connection.QueryFirstOrDefault<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                int paramOut = parameters.Get<int>(paramOutputName);

                return paramOut;
            }
        }



        public IDbConnection AuxConn()
        {
            var connection = new SqlConnection(_connection.ConnectionString);
            connection.Open();
            return connection;
        }



        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
