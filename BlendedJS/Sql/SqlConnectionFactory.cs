﻿using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MySql.Data.MySqlClient;
using Npgsql;

namespace BlendedJS.Sql
{
    public class SqlConnectionFactory
    {
        public  IDbConnection CreateConnection(string provider, string connectionString)
        {
            IDbConnection connection = null;
            if (provider.SafeEquals("MySql"))
                connection = new MySqlConnection();
            if (provider.SafeEquals("Sqlite"))
                connection = new SqliteConnection();
            if (provider.SafeEquals("SqlServer"))
                connection = new SqlConnection();
            if (provider.SafeEquals("PostgreSQL"))
                connection = new NpgsqlConnection();

            //oracle: http://www.oracle.com/technetwork/topics/dotnet/downloads/odpnetcorebeta-4077982.html

            if (connection != null)
                connection.ConnectionString = connectionString;
            return connection;
        }
    }
}