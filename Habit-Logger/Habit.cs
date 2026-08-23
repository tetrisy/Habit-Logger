using System;
using System.Collections.Generic;
using System.Text;

namespace Habit_Logger
{
    internal class Habit
    {
        public int Id { get; init; }
        public required string HabitName { get; set; }
        public DateOnly Date { get; set; }
        public int Quantity { get; set; }
    }
}
