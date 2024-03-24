using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        string response = Console.ReadLine();
        int percentage = int.Parse(response);

        string letterGrade = "";

        int gradeScale;
        gradeScale =  percentage % 10;

        string sign;
        sign = "";

        if (percentage >= 90)
        {
            letterGrade = "A";
        }
        else if (percentage >= 80)
        {
            letterGrade = "B";
        }
        else if (percentage >= 70)
        {
            letterGrade = "C";
        }
        else if (percentage >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        if (gradeScale >= 7)
        {
            sign = "+";
        }
        else if (gradeScale < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }        

        if (letterGrade == "A" && sign == "+")
        {
            sign = "";
        }
        if (letterGrade == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is: {letterGrade}{sign}");

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulation, You passed this course!");
        }
        else
        {
            Console.WriteLine("You Failed this Course. ");
            Console.WriteLine("Please try harder next time!");
        }
    }
}