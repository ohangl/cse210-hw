using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int goalPoints)
        : base(name, description, goalPoints) { }

    public override void RecordEvent()
    {
       
    }

    public override bool IsComplete() => false;

    public override void ListGoal()
    {
        Console.WriteLine($"[ ] {_name} ({_description})");
    }

    public override int CalculateAGP()
    {
        
        return _goalPoints;
    }

    public override string SaveGoal()
    {
        return $"EternalGoal|{_name}|{_description}|{_goalPoints}";
    }
}
