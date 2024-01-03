using Microsoft.Data.SqlClient;
using System.Text;

namespace AdoDotNetExercose
{
    internal class StartUp
    {
        internal static async Task Main(string[] args)
        {
            //await CreateDatabase();
            //await ValidateDatabaseIsCreated();
            //await CreateTables();
            //await ValidateTablesAreCreated();
            //await InsertDataInTables();

            string villains = await GetAllVillainsAndNumberOfMinions();
            Console.WriteLine(villains);
        }

        internal static async Task CreateDatabase()
        {
            SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING_MASTER);
            await connection.OpenAsync();

            using (connection)
            {
                SqlCommand command = new SqlCommand(SqlQueries.CreateDatabaseMinionsDB, connection);
                await command.ExecuteNonQueryAsync();
            }
        }

        internal static async Task ValidateDatabaseIsCreated()
        {
            SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING_MASTER);
            await connection.OpenAsync();
            string name = "";

            using (connection)
            {
                SqlCommand command = new SqlCommand(SqlQueries.SelectDatabase, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                using (reader)
                {
                    while (reader.Read())
                    {
                        name = (string)reader["name"];
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine($"Databse {name} created");
            }
        }

        internal static async Task CreateTables()
        {
            SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING_MinionsDB);
            await connection.OpenAsync();

            using (connection)
            {
                SqlCommand command = new SqlCommand(SqlQueries.CreateTables, connection);
                await command.ExecuteNonQueryAsync();
            }
        }

        internal static async Task ValidateTablesAreCreated()
        {
            SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING_MinionsDB);
            await connection.OpenAsync();
            List<string> tables = new List<string>();

            using (connection)
            {
                SqlCommand command = new SqlCommand(SqlQueries.SelectTables, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["TABLE_NAME"];
                        tables.Add(name);
                    }
                }
            }

            if (tables.Count > 0)
            {
                foreach (string table in tables)
                {
                    Console.WriteLine($"table {table} was created");
                }
            }
        }

        internal static async Task InsertDataInTables()
        {
            SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING_MinionsDB);
            await connection.OpenAsync();

            using (connection)
            {
                SqlCommand command = new SqlCommand(SqlQueries.InsetrDataInTables, connection);
                await command.ExecuteNonQueryAsync();
            }

            Console.WriteLine("Data inserted");
        }

        internal static async Task<string> GetAllVillainsAndNumberOfMinions()
        {
            SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING_MinionsDB);
            await connection.OpenAsync();

            StringBuilder sb = new StringBuilder();

            using (connection)
            {
                SqlCommand command = new SqlCommand(SqlQueries.GetAllVillainsAndNumberOfMinions, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        int minionsCount = (int)reader["MinionsCount"];
                        sb.Append($"{name} {minionsCount}");
                    }
                }
            }

            return sb.ToString();
        }
    }
}