using System;
using System.IO;
using System.Threading;

public abstract class Activity
{
    // Protected properties for name and description
    protected string Name { get; set; }
    protected string Description { get; set; }

    // Constructor to initialize activity name and description
    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    // Method to log activity completion to a file
    protected void LogActivity(string activityName, int duration)
    {
        string logEntry = $"{DateTime.Now}: {activityName} completed in {duration} seconds.";
        File.AppendAllText("activity_log.txt", logEntry + Environment.NewLine);
    }

    // Method to start the activity
    public void StartActivity(int duration)
    {
        Console.Clear();
        Console.WriteLine($"Starting {Name}...\n");
        Console.WriteLine(Description);
        Console.WriteLine($"\nDuration: {duration} seconds.");
        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(5);
    }

    // Method to end the activity
    public void EndActivity(int duration)
    {
        Console.WriteLine($"\nGood job! You have completed the activity: {Name} in {duration} seconds.");
        ShowSpinner(5);
        LogActivity(Name, duration);
    }

    // Show a spinner animation for pauses
    protected void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            foreach (var c in "|/-\\")
            {
                Console.Write(c);
                Thread.Sleep(200);
                Console.Write("\b \b");
            }
        }
    }

    // Abstract method for performing an activity
    public abstract void PerformActivity(int duration);
}
