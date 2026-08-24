using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;

namespace Habit_Logger
{
    internal class Menu
    {
        private readonly DatabaseManager dbManager;
        public Menu(DatabaseManager dbManager)
        {
            this.dbManager = dbManager;
        }

        public void CallMenu()
        {
            int choice;

            while (true)
            {
                DisplayMenu();
                choice = GetUserChoice();
                if (choice == 0)
                {
                    return;
                }
                Console.Clear();
                ExecuteMenuOption(choice);
                Console.Clear();
            }
        }

        public void DisplayMenu()
        {
            Console.WriteLine("================== Habit Logger ==================");
            Console.WriteLine($"|{"|", 49}");
            Console.WriteLine($"{"|",-8}{"1. Add new habbit",-41}|");
            Console.WriteLine($"{"|",-8}{"2. View habits",-41}|");
            Console.WriteLine($"{"|",-8}{"3. Update habit",-41}|");
            Console.WriteLine($"{"|",-8}{"4. Delete habit",-41}|");
            Console.WriteLine($"{"|",-8}{"0. Exit",-41}|");
            Console.WriteLine($"|{"|",49}");
            Console.WriteLine("==================================================");
        }

        private int GetUserChoice()
        {
            Console.Write("Choose an option (1-5): ");
            string? choice = Console.ReadLine();
            int output;

            while (!int.TryParse(choice, out output))
            {
                Console.Write("Invalid input. Pleae enter a valid number: ");
                choice = Console.ReadLine();
            }

            return output;
        }

        private void ExecuteMenuOption(int choice)
        {
            switch (choice)
            {
                case 1:
                    dbManager.InsertHabit(CreateHabit());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The habit was saved sucesfully!");
                    Console.ResetColor();
                    Console.WriteLine("\nPress any key to go back to menu...");
                    Console.ReadLine();
                    break;
                case 2:
                    ShowHabitsMenu();
                    break;
                case 3:
                    // Update
                    break;
                case 4:
                    DeleteHabit();
                    break;
                case 0:
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please choose between 0-4.");
                    Console.ResetColor();
                    break;
            }
        }

        private Habit CreateHabit()
        {
            Console.Write("Enter habit name: ");
            string? habitName = Console.ReadLine();
            while(string.IsNullOrWhiteSpace(habitName))
            {
                Console.Write("Enter a valid habit name: ");
                habitName = Console.ReadLine();
            }

            Console.Write("Enter date (dd-mm-yyyy). Enter today for today: ");
            string? input = Console.ReadLine();
            DateOnly checkedDate;
            if (input == "today")
            {
                checkedDate = DateOnly.FromDateTime(DateTime.Now);
            }else
            {
                while (!DateOnly.TryParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out checkedDate))
                {
                    Console.Write("Invalid input. Pleae enter a valid date: ");
                    input = Console.ReadLine();
                }
            }

            Console.Write("Enter quantity: ");
            input = Console.ReadLine();
            int habitQuantity;
            while (!int.TryParse(input, out habitQuantity))
            {
                Console.Write("Invalid input. Pleae enter a valid quantity: ");
                input = Console.ReadLine();
            }

            return new Habit(habitName, checkedDate, habitQuantity);
        }

        private void DisplayHabits()
        {
            List<Habit> habits = dbManager.GetHabits();

            if(habits.Count() == 0)
            {
                Console.WriteLine("There are no habit logged. Press any key to go back to menu...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("================== Habits List ===================");
            Console.WriteLine($"| {"ID", -3}{"|", -9} {"Habit", -13}{"|", -5}{"Date", -8}|  {"Qty.", -5}|");
            Console.WriteLine("--------------------------------------------------");
            foreach (Habit habit in habits)
            {
                Console.WriteLine($"| {habit.Id,-3}{"|",-1} {habit.HabitName,-17}{"|",5}{habit.Date,-12}|  {habit.Quantity,-5}|");
            }
            Console.WriteLine("==================================================");
        }

        private void ShowHabitsMenu()
        {
            DisplayHabits();
            Console.WriteLine("\nPress any key to go back to menu...");
            Console.ReadLine();
        }

        private void DeleteHabit()
        {
            DisplayHabits();
            Console.Write("\nEnter ID of the habit you want to delete: ");
            int deleteId = Convert.ToInt32(Console.ReadLine());
            bool deleted = Convert.ToBoolean(dbManager.EraseHabit(deleteId));

            if (deleted)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The habit was deleted succesfully.");
                Console.ResetColor();
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Habit with that ID was not found.");
                Console.ResetColor();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}
