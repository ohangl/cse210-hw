using System;

public class ListingActivity : Activity
{
    private List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", 
        "Welcome to the Listing Activity! This activity helps you reflect on positive aspects of your life.") { }

    public override void PerformActivity(int duration)
    {
        StartActivity(duration);

        var random = new Random();
        Console.WriteLine("\n" + Prompts[random.Next(Prompts.Count)]);
        Console.WriteLine("\nStart listing items!");

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int count = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items.");
        EndActivity(duration);
    }
}
