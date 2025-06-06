using System;

class Program

// creativity: this program logs each completed activity with its name and duration into "activity_log.txt".
// also it displays a summary at the end of the session showing all activities the user completed.

{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Hello and Welcome to the Mindfulness Program\n! Please choose one of the next activities:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("\nChoose an option: ");

            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            };

            if (activity == null) break;

            Console.Write("\nHow long, in seconds, would you like your session? ");
            int duration = int.Parse(Console.ReadLine() ?? "30");

            activity.PerformActivity(duration);
        }


        Console.WriteLine("\nSummary of Completed Activities:");
        if (File.Exists("activity_log.txt"))
        {
            string[] logLines = File.ReadAllLines("activity_log.txt");
            foreach (string line in logLines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("No activities have been logged yet.");
        }

        Console.WriteLine(" Thank you for using the Mindfulness Program! I hope this was a goos experience!");
    }
}
