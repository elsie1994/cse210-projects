using System;
using System.Collections.Generic;
using System.IO;

namespace Develop05
{
    // Define the Goal class
    public abstract class Goal
    {
        private string name;
        private string description;
        private int value;
        private bool complete;

        public Goal(string name, string description, int value, bool complete = false)
        {
            this.name = name;
            this.description = description;
            this.value = value;
            this.complete = complete;
        }

        public string GetName() => name;
        public string GetDescription() => description;
        public int GetValue() => value;
        public bool IsComplete() => complete;

        public abstract void DisplayEntry();
        public abstract string GetStringRepresentation();
    }

    // Define the SimpleGoal class
    public class SimpleGoal : Goal
    {
        private int progress;

        public SimpleGoal(string name, string description, int value, bool complete = false) : base(name, description, value, complete)
        {
            progress = 0;
        }

        public override void DisplayEntry()
        {
            Console.WriteLine($"{GetName()} - {GetDescription()} - Progress: {progress}/{GetValue()} - Complete: {IsComplete()}");
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{GetName()}~{GetDescription()}~{GetValue()}~{IsComplete()}~{progress}";
        }

        public void RecordProgress(int value)
        {
            progress = value;
        }
    }

    // Define the EternalGoal class
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int value, bool complete = false) : base(name, description, value, complete) { }

        public override void DisplayEntry()
        {
            Console.WriteLine($"{GetName()} - {GetDescription()} - Complete: {IsComplete()}");
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{GetName()}~{GetDescription()}~{GetValue()}~{IsComplete()}";
        }
    }

    // Define the ChecklistGoal class
    public class ChecklistGoal : Goal
    {
        private int count;
        private int progress;

        public ChecklistGoal(string name, string description, int value, bool complete = false, int count = 0) : base(name, description, value, complete)
        {
            this.count = count;
            progress = 0;
        }

        public override void DisplayEntry()
        {
            Console.WriteLine($"{GetName()} - {GetDescription()} - Progress: {progress}/{count} - Complete: {IsComplete()}");
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{GetName()}~{GetDescription()}~{GetValue()}~{IsComplete()}~{count}~{progress}";
        }

        public void RecordProgress(int value)
        {
            progress = value;
        }
    }

    // Define the EternalQuest class
    public class EternalQuest
    {
        private List<Goal> goals;

        public EternalQuest()
        {
            goals = new List<Goal>();
        }

        public void AddGoal(Goal goal)
        {
            goals.Add(goal);
        }

        public void RemoveGoal(string name)
        {
            Goal goalToRemove = goals.Find(goal => goal.GetName() == name);
            if (goalToRemove != null)
            {
                goals.Remove(goalToRemove);
                Console.WriteLine($"Goal '{name}' has been removed.");
            }
            else
            {
                Console.WriteLine($"Goal '{name}' not found.");
            }
        }

        public void DisplayAllGoals()
        {
            foreach (Goal goal in goals)
            {
                goal.DisplayEntry();
            }
        }

        public void LoadGoals(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    string[] tokens = line.Split(':');
                    string goalType = tokens[0];
                    string[] values = tokens[1].Split('~');

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            string name = values[0];
                            string description = values[1];
                            int value = int.Parse(values[2]);
                            bool complete = bool.Parse(values[3]);
                            int progress = int.Parse(values[4]);
                            SimpleGoal simpleGoal = new SimpleGoal(name, description, value, complete);
                            simpleGoal.RecordProgress(progress);
                            AddGoal(simpleGoal);
                            break;
                        case "EternalGoal":
                            string eName = values[0];
                            string eDescription = values[1];
                            int eValue = int.Parse(values[2]);
                            bool eComplete = bool.Parse(values[3]);
                            EternalGoal eternalGoal = new EternalGoal(eName, eDescription, eValue, eComplete);
                            AddGoal(eternalGoal);
                            break;
                        case "ChecklistGoal":
                            string cName = values[0];
                            string cDescription = values[1];
                            int cValue = int.Parse(values[2]);
                            bool cComplete = bool.Parse(values[3]);
                            int cCount = int.Parse(values[4]);
                            ChecklistGoal checklistGoal = new ChecklistGoal(cName, cDescription, cValue, cComplete, cCount);
                            checklistGoal.RecordProgress(int.Parse(values[5]));
                            AddGoal(checklistGoal);
                            break;
                        default:
                            Console.WriteLine($"Unknown goal type '{goalType}' in file.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals from file: {ex.Message}");
            }
        }

        public void SaveGoals(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Goal goal in goals)
                    {
                        writer.WriteLine(goal.GetStringRepresentation());
                    }
                }
                Console.WriteLine("Goals saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals to file: {ex.Message}");
            }
        }
    }
}
