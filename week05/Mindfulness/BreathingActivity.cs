public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "Welcome to the Breathing Activity! This activity will help you relax by pacing your breathing.") { }

    public override void PerformActivity(int duration)
    {
        StartActivity(duration);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in...");
            ShowCountdown(4);
            Console.WriteLine("\nBreathe out...");
            ShowCountdown(4);
        }

        EndActivity(duration);
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
