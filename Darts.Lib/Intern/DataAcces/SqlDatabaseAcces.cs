using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Darts.Lib.DataAcces
{
    public class SqlDatabaseAccess
    {
        private string _connectionString;

        public SqlDatabaseAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
