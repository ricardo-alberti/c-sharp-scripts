using System;
using System.Data;
using System.Data.SQLite;

class ChessDatabase
{
    static void Main()
    {
        string connectionString = "Data Source=ChessDatabase.db;Version=3;";

        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            // Create a table (assuming it doesn't exist)
            string createTableQuery = "CREATE TABLE IF NOT EXISTS ChessPlayers (Id INTEGER PRIMARY KEY, Name TEXT, Rating INTEGER)";
            using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection))
            {
                createTableCommand.ExecuteNonQuery();
            }

            // Insert a sample chess player
            string insertQuery = "INSERT INTO ChessPlayers (Name, Rating) VALUES ('Magnus Carlsen', 2850)";
            using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
            {
                insertCommand.ExecuteNonQuery();
            }

            // Query and display players
            string selectQuery = "SELECT * FROM ChessPlayers";
            using (SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection))
            {
                using (SQLiteDataReader reader = selectCommand.ExecuteReader())
                {
                    Console.WriteLine("Chess Players:");
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        string name = reader["Name"].ToString();
                        int rating = Convert.ToInt32(reader["Rating"]);
                        Console.WriteLine($"ID: {id}, Name: {name}, Rating: {rating}");
                    }
                }
            }

            connection.Close();
        }
    }
}
