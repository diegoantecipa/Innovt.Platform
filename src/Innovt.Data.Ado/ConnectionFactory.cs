﻿using System;
using System.Data;
using System.Data.SqlClient;
using Innovt.Core.Utilities;
using Innovt.Data.DataSources;
using Innovt.Data.Exceptions;
using Innovt.Data.Model;
using Npgsql;

namespace Innovt.Data.Ado
{
    public class ConnectionFactory:IConnectionFactory 
    {
        public IDbConnection Create(IDataSource dataSource)
        {
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));

            var connectionString = dataSource.GetConnectionString();

            if (connectionString.IsNullOrEmpty())
                throw new ConnectionStringException($"Data source {dataSource.Name}");

            return dataSource.Provider switch
            {
                Provider.PostgreSqL => new NpgsqlConnection(connectionString),
                Provider.MsSql => new SqlConnection(connectionString),
                _ => new SqlConnection(connectionString)
            };
        }
    }
}