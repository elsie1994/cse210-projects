using System;
using System.Collections.Generic;
using ExerciseTracker; // Assuming ExerciseTracker is the namespace where Activity, RunningActivity, CyclingActivity, and SwimmingActivity are defined.

class Program
{
    static void Main(string[] args)
    {
        // create a list of activities
        List<Activity> activities = new List<Activity>();
        
        // add some activities to the list
        activities.Add(new RunningActivity(DateTime.Parse("2023-01-25"), 30, 9.0));
        activities.Add(new CyclingActivity(DateTime.Parse("2023-02-15"), 45, 15));
        activities.Add(new SwimmingActivity(DateTime.Parse("2023-05-09"), 30, 30));

        // iterate through the list and display the summary of each activity
        foreach (Activity activity in activities)
        {
            Console.WriteLine(new string('-', 90));
            Console.WriteLine();
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
            Console.WriteLine(new string('-', 90));
            Console.WriteLine();
        }
    }
}
