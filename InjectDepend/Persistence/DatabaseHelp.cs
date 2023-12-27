using System.Data.SQLite;


namespace InjectDepend.Persistence
{
    public static class DatabaseHelp
    {

        private static string connectionString = @"Data Source= C:\Users\brenn\.librarymanager\library.db;Version=3";
        
        public static void InitializeDatabase()
        {
            SQLiteConnection.CreateFile(@"C:\Users\brenn\.librarymanager\library.db;Version=3");

            using(var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // TODO : Create tables for the data 
                string createBooksTableQuery = @"
                    CREATE TABLE IF NOT EXISTS books(
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    title TEXT NOT NULL,
                    author TEXT NOT NULL,
                    genre TEXT NOT NULL
                );";

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = createBooksTableQuery;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
