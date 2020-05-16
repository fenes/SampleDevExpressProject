using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace SampleDevExpressProject.Repository.Implementation
{
    public class BaseRepository
    {
        protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return connection.QueryFirstOrDefault<T>(sql, parameters);
            }
        }

        protected List<T> Query<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        protected int Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return connection.Execute(sql, parameters);
            }
        }

        // Other Helpers...

        private IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Context"].ConnectionString);
            connection.Open();
            return connection;
        }
    }
}