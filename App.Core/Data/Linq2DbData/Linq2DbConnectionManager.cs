using LinqToDB.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace App.Core.Data.Linq2DbData
{
    public class Linq2DbConnectionManager
    {
        private static DataConnection _connection;
        //private static ConcurrentDictionary<string, string> _connectionKeyDict = new ConcurrentDictionary<string, string>();
        private static int _dbConnectionCount;

        static Linq2DbConnectionManager()
        { }

        public static int GetConnectionCount()
        {
            return _dbConnectionCount;
        }

        public static DataConnection Get(string connName)
        {
            if (_connection == null ||
                _connection.Connection.State == System.Data.ConnectionState.Broken ||
                _connection.Connection.State == System.Data.ConnectionState.Closed)
            {
                _connection = CreateInternal(connName);
            }

            return _connection;
        }

        private static DataConnection CreateInternal(string connName)
        {
            var provider = DataConnection.GetDataProvider(connName);

            string connectionString = ConfigurationManager.ConnectionStrings[connName]?.ConnectionString;
            provider.CreateConnection(connectionString);

            Linq2DbInterceptDataConnection connection = new Linq2DbInterceptDataConnection(provider, connectionString);
            connection.OnClosed += Connection_OnClosed;
            _dbConnectionCount++;
            return connection;
        }

        private static void Connection_OnClosed(object sender, EventArgs e)
        {
            if (_connection.Connection.State != System.Data.ConnectionState.Broken &&
                _connection.Connection.State != System.Data.ConnectionState.Closed)
            {
                _connection.Connection.Dispose();
                _connection = null;
            }

            if (_dbConnectionCount > 0)
                _dbConnectionCount--;
        }
    }
}
