using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureHider
{
    class Program
    {
        static void Main(string[] args)
        {
            Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

            Console.WriteLine("Complete Scripture:");
            scripture.Display();

            while (true)
            {
                Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    break;

                scripture.HideRandomWords();
                Console.Clear();

                Console.WriteLine("Partial Scripture:");
                scripture.Display();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words hidden. Exiting program.");
                    break;
                }
            }
        }
    }

    class Scripture
    {
        private List<Word> words;
        private string reference;

        public Scripture(string referenceText, string scriptureText)
        {
            reference = referenceText;
            words = scriptureText.Split(' ').Select(word => new Word(word)).ToList();
        }

        public void Display()
        {
            Console.WriteLine($"{reference}:");
            foreach (Word word in words)
                Console.Write(word.IsHidden ? "***** " : word.Text + " ");
            Console.WriteLine();
        }

        public void HideRandomWords()
        {
            Random rand = new Random();
            int wordsToHide = Math.Max(1, words.Count / 4);

            for (int i = 0; i < wordsToHide; i++)
                words[rand.Next(words.Count)].Hide();
        }

        public bool AllWordsHidden() => words.All(word => word.IsHidden);
    }

    class Word
    {
        public string Text { get; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public void Hide() => IsHidden = true;
    }
}