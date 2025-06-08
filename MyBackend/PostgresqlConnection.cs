using Npgsql;
using System;

namespace MyBackend
{
    public class PostgresqlConnection
    {
        private readonly string _connectionString;

        public PostgresqlConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NpgsqlConnection GetConnection()
        {
            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        // Example usage
        public void TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    Console.WriteLine("Connection to PostgreSQL established successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to PostgreSQL: {ex.Message}");
            }
        }
    }
}