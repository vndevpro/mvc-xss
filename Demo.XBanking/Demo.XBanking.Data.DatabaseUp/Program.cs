using DbUp;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace Demo.XBanking.Data.DatabaseUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["XBankingDatabase"].ConnectionString;

            TryCreateDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
        }

        static void TryCreateDatabase(string connectionString)
        {
            if (CheckIfDatabaseInConnectionStringExists(connectionString))
            {
                Console.WriteLine("Database existed!");
                return;
            }

            CreateAssociatedDatabase(connectionString);
        }

        static bool CheckIfDatabaseInConnectionStringExists(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            var databaseName = builder.InitialCatalog;

            builder.InitialCatalog = string.Empty;

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select db_id('" + databaseName + "')";

                    connection.Open();
                    var result = command.ExecuteScalar();

                    return !(result is DBNull);
                }
            }
        }

        static void CreateAssociatedDatabase(string connectionString)
        {
            Console.WriteLine("Creating database...");

            var builder = new SqlConnectionStringBuilder(connectionString);
            var databaseName = builder.InitialCatalog;

            builder.InitialCatalog = string.Empty;

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE DATABASE [" + databaseName + "]";

                    connection.Open();
                    command.ExecuteNonQuery();

                    Console.WriteLine("Database has been created!");
                }
            }
        }
    }
}
