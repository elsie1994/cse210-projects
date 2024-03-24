using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userInput = -1;
        while (userInput != 0)
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished: ");

            string userResponse = Console.ReadLine();
            userInput = int.Parse(userResponse);


            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }

        // Part 1: Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");



        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The largest number is: {max}");
    }
}
    