using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperMVCDemo.Data.DataAccess
{
    public   class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _configuration;
        public SQLDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        #region Get All the Data
        public async Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string connectionId = "connection") 
        {
            using IDbConnection connection = new SqlConnection
                    (_configuration.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
        }
        #endregion


        #region Update and Insert
        public async Task SaveData<T>(string spName, T parameters, string connectionId = "connection")
        {
            using IDbConnection connection = new SqlConnection
                   (_configuration.GetConnectionString(connectionId));

             await connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
        }
        #endregion
    }
}
