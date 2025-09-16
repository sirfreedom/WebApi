using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.SqlClient;

/*
    Esta es la implementacion pura del patron Object Pooling orientado a limitar la cantidad de conexiones abiertas 
*/
namespace WebApi.Data
{

    public class ConnectionCommandPool
    {
        private readonly string _connectionString;
        private readonly ConcurrentBag<SqlConnection> _connectionPool;
        private readonly ConcurrentBag<SqlCommand> _commandPool;
        private readonly int _maxPoolSize;

        public ConnectionCommandPool(string connectionString, int maxPoolSize = 10)
        {
            _connectionString = connectionString;
            _maxPoolSize = maxPoolSize;
            _connectionPool = [];
            _commandPool = [];
        }

        public SqlConnection GetConnection()
        {
            if (_connectionPool.TryTake(out SqlConnection connection))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open(); // Reopen if closed
                }
                return connection;
            }
            else
            {
                // Create a new connection if pool is empty or max size not reached
                if (_connectionPool.Count <= _maxPoolSize)
                {
                    SqlConnection newConnection = new(_connectionString);
                    newConnection.Open();
                    return newConnection;
                }
                else
                {
                    // Optionally, wait or throw an exception if pool is exhausted
                    throw new InvalidOperationException("Connection pool exhausted.");
                }
            }
        }

        public void ReturnConnection(SqlConnection connection)
        {
            if (connection != null && _connectionPool.Count < _maxPoolSize)
            {
                _connectionPool.Add(connection);
            }
            else
            {
                connection?.Dispose(); // Dispose if pool is full or connection is invalid
            }
        }

        public SqlCommand GetCommand()
        {
            if (_commandPool.TryTake(out SqlCommand command))
            {
                return command;
            }
            else
            {
                // Create a new command if pool is empty
                return new SqlCommand();
            }
        }

        public void ReturnCommand(SqlCommand command)
        {
            if (command != null)
            {
                command.Parameters.Clear(); // Clear parameters for reuse
                command.Connection = null; // Detach connection
                _commandPool.Add(command);
            }
        }

        public void Dispose()
        {
            while (_connectionPool.TryTake(out SqlConnection connection))
            {
                connection.Dispose();
            }
            while (_commandPool.TryTake(out SqlCommand command))
            {
                command.Dispose();
            }
        }
    }
}
