using System;using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Mindfulness Program!");
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Start program");
                Console.WriteLine("2. About");
                Console.WriteLine("3. Exit");

                int choice = ReadIntInRange("Enter your choice: ", 1, 3);

                switch (choice)
                {
                    case 1:
                        MindfulnessProgram.Start();
                        break;
                    case 2:
                        About();
                        break;
                    case 3:
                        exit = true;
                        break;
                }
            }
        }

        static void About()
        {
            Console.Clear();
            Console.WriteLine("About");
            Console.WriteLine("This program was created to help individuals practice mindfulness and focus on their mental health.");
            Console.WriteLine("Version 1.0");
            Console.WriteLine("Author: Elsie Essien");
            PauseWithAnimation(5);
        }

        static int ReadIntInRange(string prompt, int min, int max)
        {
            int result;

            while (true)
            {
                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out result) && result >= min && result <= max)
                {
                    return result;
                }

                Console.WriteLine($"Invalid input. Enter a number between {min} and {max}.");
            }
        }

        static void PauseWithAnimation(int seconds)
        {
            Console.Write("Starting in ");
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write($"{i}...");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }

    // Placeholder for MindfulnessProgram class
    static class MindfulnessProgram
    {
        // Placeholder for Start method
        public static void Start()
        {
            Console.WriteLine("Mindfulness program started.");
            // Add your program logic here
        }
    }
}
