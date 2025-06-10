using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int goalPoints, bool completed = false)
        : base(name, description, goalPoints)
    {
        _status = completed;
    }

    public override void RecordEvent()
    {
        if (!_status)
            _status = true;
    }

    public override bool IsComplete() => _status;

    public override void ListGoal()
    {
        var mark = _status ? "X" : " ";
        Console.WriteLine($"[{mark}] {_name} ({_description})");
    }

    public override int CalculateAGP()
    {
        
        return _status ? _goalPoints : 0;
    }

    public override string SaveGoal()
    {
        return $"SimpleGoal|{_name}|{_description}|{_goalPoints}|{_status}";
    }
}
