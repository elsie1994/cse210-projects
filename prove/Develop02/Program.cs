using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal _journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Create new journal entry");
            Console.WriteLine("2. Display all journal entries");
            Console.WriteLine("3. Save journal to CSV file");
            Console.WriteLine("4. Load journal from CSV file");
            Console.WriteLine("5. Exit");

            string input = Console.ReadLine();

            if (input == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine("Prompt: " + prompt);
                Console.Write("Response: ");
                string response = Console.ReadLine();
                string date = DateTime.Today.ToShortDateString();

                Entry entry = new Entry(prompt, response, date);
                _journal.AddEntry(entry);

                Console.WriteLine("Entry created successfully!");
            }
            else if (input == "2")
            {
                _journal.DisplayEntries();
            }
            else if (input == "3")
            {
                Console.Write("Enter file name to save journal to: ");
                string fileName = Console.ReadLine();

                _journal.SaveToFile(fileName);
            }
            else if (input == "4")
            {
                Console.Write("Enter file name to load journal from: ");
                string fileName = Console.ReadLine();

                _journal.LoadFromFile(fileName);
            }
            else if (input == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }

            Console.WriteLine();
        }
    }
}