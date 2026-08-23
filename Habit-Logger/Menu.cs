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
            }
        }

        public void DisplayMenu()
        {
            Console.WriteLine("============== Habit Logger ==============");
            Console.WriteLine($"|{"|", 41}");
            Console.WriteLine($"{"|",-8}{"1. Add new habbit",-33}|");
            Console.WriteLine($"{"|",-8}{"1. as",-33}|");
            Console.WriteLine($"{"|",-8}{"1. as",-33}|");
            Console.WriteLine($"{"|",-8}{"1. as",-33}|");
            Console.WriteLine($"|{"|",41}");
            Console.WriteLine("==========================================");
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
                   // dbManager.InsertHabit(CreateHabit());
                    break;
                case 2:
                    // View habits
                    break;
                case 3:
                    // Delete habit
                    break;
                case 4:
                    // ?
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
    }
}
