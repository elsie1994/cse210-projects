using System;

public class PromptGenerator
{
    static List<string> _prompts = new List<string>()
    {
        "What is one thing that made you proud of yourself today?",
        "What did you learned today?",
        "What are you most grateful for in your life right now?",
        "What is something you've always wanted to learn but haven't yet?",
        "What was the highlight of your day?",
        "What was the most challenging part of your day?",
        "What are some things you can do to take care of yourself today?",
        "What is something you're looking forward to this week?",
        "What is one thing that you would like to change about your daily routine?",
        "What is something that inspires you?",
        "What is one act of kindness you witnessed or received today?"

    };

    public string GetRandomPrompt()
    {
        var random = new Random();
        var index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void AddPrompt(string prompt)
    {
        _prompts.Add(prompt);
    }
}