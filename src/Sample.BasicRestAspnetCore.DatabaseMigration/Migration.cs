using System.Diagnostics;
using System.Reflection;
using DbUp;
using MySql.Data.MySqlClient;

namespace Sample.BasicRestAspnetCore.DatabaseMigration
{
    public class Migration
    {
        public static void Apply(string connectionString, string databaseName)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"create schema if not exists {databaseName};";
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            /*
              Migration Database using DbUp
           */
            var upgrader =
            DeployChanges.To
            .MySqlDatabase(connectionString, databaseName)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Debug.WriteLine(result.Error);
            }
        }
    }
}