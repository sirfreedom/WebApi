using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
/*
    Esta es la implementacion pura del patron Object Pooling orientado a limitar la cantidad de conexiones abiertas 
*/
namespace WebApi.Data
{

    public class ConnectionCommandPool : IDisposable
    {
        private readonly string _connectionString;
        private readonly ConcurrentBag<SqlConnection> _connectionPool = new();
        private readonly ConcurrentBag<SqlCommand> _commandPool = new();
        private readonly int _maxPoolSize;
        private int _currentConnectionCount = 0;
        private bool _disposed = false;

        public ConnectionCommandPool(string connectionString, int maxPoolSize = 10)
        {
            _connectionString = connectionString;
            _maxPoolSize = maxPoolSize;
        }

        public SqlConnection GetConnection()
        {
            if (_disposed) throw new ObjectDisposedException(nameof(ConnectionCommandPool));

            if (_connectionPool.TryTake(out var connection))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                else if (connection.State == ConnectionState.Broken)
                {
                    connection.Dispose();
                    Interlocked.Decrement(ref _currentConnectionCount);
                    return GetConnection(); // Retry
                }
                return connection;
            }
            else
            {
                if (Interlocked.Increment(ref _currentConnectionCount) <= _maxPoolSize)
                {
                    var newConnection = new SqlConnection(_connectionString);
                    newConnection.Open();
                    return newConnection;
                }
                else
                {
                    Interlocked.Decrement(ref _currentConnectionCount);
                    throw new InvalidOperationException("Connection pool exhausted.");
                }
            }
        }

        public void ReturnConnection(SqlConnection connection)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(ConnectionCommandPool));

            if (connection == null) return;

            if (connection.State == ConnectionState.Open)
            {
                // Opcional: rollback transacciones abiertas aquí
                if (_connectionPool.Count < _maxPoolSize)
                {
                    _connectionPool.Add(connection);
                    return;
                }
            }

            connection.Dispose();
            Interlocked.Decrement(ref _currentConnectionCount);
        }

        public SqlCommand GetCommand()
        {
            if (_disposed) throw new ObjectDisposedException(nameof(ConnectionCommandPool));

            if (_commandPool.TryTake(out var command))
            {
                return command;
            }
            else
            {
                return new SqlCommand();
            }
        }

        public void ReturnCommand(SqlCommand command)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(ConnectionCommandPool));

            if (command == null) return;

            command.Parameters.Clear();
            command.Connection = null;
            _commandPool.Add(command);
        }

        public void Dispose()
        {
            if (_disposed) return;

            while (_connectionPool.TryTake(out var connection))
            {
                connection.Dispose();
            }
            while (_commandPool.TryTake(out var command))
            {
                command.Dispose();
            }
            _disposed = true;
        }
    }





}
