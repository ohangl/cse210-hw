using System;

// creativity: added a leveling system: when u gain 1000 points increases your level and gain a new title as a videogame
// a “Level Up!” banner is displayed when you reach a new level.
public class Program
{
    public static void Main(string[] args)
    {
        var tracker = new GoalsTracker();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Display Points & Level");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    tracker.CreateGoal();
                    break;
                case "2":
                    tracker.ListGoals();
                    break;
                case "3":
                    tracker.SaveGoals();
                    break;
                case "4":
                    tracker.LoadGoals();
                    break;
                case "5":
                    tracker.RecordEvent();
                    break;
                case "6":
                    Console.WriteLine($"\nYou have {tracker.GetAccumulatedPoints()} points.");
                    Console.WriteLine($"You are Level {tracker.CurrentLevel}: {tracker.CurrentLevelTitle}\n");
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
