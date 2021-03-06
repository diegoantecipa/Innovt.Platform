﻿using System;
using Innovt.Data.Exceptions;
using Innovt.Data.Model;
using Microsoft.Extensions.Configuration;

namespace Innovt.Data.DataSources
{
    /// <summary>
    /// The Default DataSource is using ConfigurationManager
    /// </summary>
    public abstract class DataSourceBase : IDataSource
    {
        private  string connectionString = null;

        public string Name { get; set; }

        public Provider Provider { get; private set; }

        protected DataSourceBase( string name, string connectionString,Provider provider = Provider.MsSql)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Provider = provider;
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }


        protected DataSourceBase(IConfiguration configuration,string connectionStringName,
            Provider provider = Provider.MsSql)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (connectionStringName == null) throw new ArgumentNullException(nameof(connectionStringName));


            this.Provider = provider;
            SetConnectionString(configuration, connectionStringName);
        }

        protected DataSourceBase(IConfiguration configuration, string name, string connectionStringName,Provider provider = Provider.MsSql)
        {
            this.Provider = provider;
            this.Name = name;

            SetConnectionString(configuration, connectionStringName);
        }

        private void SetConnectionString(IConfiguration configuration, string name)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (name == null) throw new ArgumentNullException(nameof(name));

            var localConnectionString = configuration.GetConnectionString(name);

            if (string.IsNullOrEmpty(localConnectionString))
                throw new ConnectionStringException($"Connection string {name} not found or null.");

            this.Name = name;
            this.connectionString = localConnectionString;
        }

        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}