using System;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        this.Prompt = prompt;
        this.Response = response;
        this.Date = date;
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine($"Date: {Date}");
    }

    public string GetEntryAsCSV()
    {
        return $"{Prompt},{Response},{Date}";
    }
}