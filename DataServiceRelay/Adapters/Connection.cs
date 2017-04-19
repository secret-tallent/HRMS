using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace DataServiceRelay.Adapters
{
    public static class Connection
    {
        public static SqlConnection GetConnection()
        {
            string defaultConnectionString =  Configuration.GetDefaultConnectionString();

            SqlConnection defaultSqlConnection = new SqlConnection(defaultConnectionString);

            return defaultSqlConnection;
        }
    }
}
