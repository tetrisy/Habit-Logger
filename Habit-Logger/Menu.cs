using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Habit_Logger
{
    internal class Menu
    {
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
                ExecuteMenuOption(choice);
            }
        }

        public void DisplayMenu()
        {
            Console.WriteLine("============== Habit Logger ==============");
            Console.WriteLine($"{"|",-8}{"1. sad",-33}|");
            Console.WriteLine($"{"|",-8}{"1. as",-33}|");
            Console.WriteLine($"{"|",-8}{"1. as",-33}|");
            Console.WriteLine($"{"|",-8}{"1. as",-33}|");
            Console.WriteLine("==========================================");
        }

        private int GetUserChoice()
        {
            Console.Write("Choose an option (1-5): ");
            string? choice = Console.ReadLine();

            while (!int.TryParse(choice, out int output))
            {
                Console.Write("Invalid input. Pleae enter a valid number: ");
                choice = Console.ReadLine();
            }

            return Convert.ToInt32(choice);
        }

        private void ExecuteMenuOption(int choice)
        {
            switch (choice)
            {
                case 1:
                    // Add habit
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
            }
        }
    }
}
