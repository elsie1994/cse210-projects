using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        ScriptureRange scripture = new ScriptureRange("John 3:16", "John 3:18", new string[]

        {   "For God so loved the world that he gave his only Son, that whoever believes in him should not perish but have eternal life.",
            "For God did not send his Son into the world to condemn the world, but in order that the world might be saved through him.",
            "Whoever believes in him is not condemned, but whoever does not believe is condemned already, because he has not believed in the name of the only Son of God." });

        Console.Clear();
        Console.WriteLine(scripture);

        while (true)
        {
            Console.Write("Press enter to continue or type 'quit': ");
            string input = Console.ReadLine().ToLower();
            if (input == "quit")
            {
                break;
            }
            Console.Clear();
            if (!scripture.HideRandomWord())
            {
                Console.WriteLine("All words are now hidden. Press enter to quit.");
                Console.ReadLine();
                break;
            }
            Console.WriteLine(scripture);
        }
    }
}