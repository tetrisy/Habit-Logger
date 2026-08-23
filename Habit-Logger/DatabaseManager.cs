using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

namespace Habit_Logger
{
    internal class DatabaseManager
    {
        private const string DataSource = "Data Source=habits.db";
        public void InitializeDatabase()
        {
            using var connection = new SqliteConnection(DataSource);

            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
            CREATE TABLE IF NOT EXISTS habits (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                HabitName TEXT,
                Date TEXT,
                Quantity INTEGER
            )
            ";

            command.ExecuteNonQuery();
        }
    }
}
