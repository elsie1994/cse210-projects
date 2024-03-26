using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");

        // Create a base "Assignment" object
        Assignment a1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        // Now create the derived class assignments
        MathAssignment a2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}

class Assignment
{
    protected string studentName;
    protected string assignmentTitle;

    public Assignment(string studentName, string assignmentTitle)
    {
        this.studentName = studentName;
        this.assignmentTitle = assignmentTitle;
    }

    public virtual string GetSummary()
    {
        return $"Assignment: {assignmentTitle}, Student: {studentName}";
    }
}

class MathAssignment : Assignment
{
    private string chapter;
    private string pages;

    public MathAssignment(string studentName, string assignmentTitle, string chapter, string pages)
        : base(studentName, assignmentTitle)
    {
        this.chapter = chapter;
        this.pages = pages;
    }

    public string GetHomeworkList()
    {
        return $"Homework for {assignmentTitle}: Chapter {chapter}, Pages {pages}";
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Chapter: {chapter}, Pages: {pages}";
    }
}

class WritingAssignment : Assignment
{
    private string topic;

    public WritingAssignment(string studentName, string assignmentTitle, string topic)
        : base(studentName, assignmentTitle)
    {
        this.topic = topic;
    }

    public string GetWritingInformation()
    {
        return $"Writing topic for {assignmentTitle}: {topic}";
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Topic: {topic}";
    }
}
