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

        public void InsertHabit(Habit habit)
        {
            using var connection = new SqliteConnection(DataSource);

            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO habits (HabitName, Date, Quantity)
                VALUES (@HabitName, @Date, @Quantity)
            ";

            command.Parameters.AddWithValue("@HabitName", habit.HabitName);
            command.Parameters.AddWithValue("@Date", habit.Date.ToString("dd-MM-yyyy"));
            command.Parameters.AddWithValue("@Quantity", habit.Quantity);

            command.ExecuteNonQuery();
        }

        public List<Habit> GetHabits()
        {
            using var connection = new SqliteConnection(DataSource);

            return;
        }
    }
}
