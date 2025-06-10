using System;

public class ChecklistGoal : Goal
{
    private int _bonusPoints;
    private int _targetCount;
    private int _currentCount;

    public ChecklistGoal(
        string name,
        string description,
        int goalPoints,
        int bonusPoints,
        int targetCount,
        int currentCount = 0
    ) : base(name, description, goalPoints)
    {
        _bonusPoints = bonusPoints;
        _targetCount = targetCount;
        _currentCount = currentCount;
    }

    public override void RecordEvent()
    {
        if (_currentCount < _targetCount)
            _currentCount++;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override void ListGoal()
    {
        var mark = IsComplete() ? "X" : " ";
        Console.WriteLine($"[{mark}] {_name} ({_description}) -- Completed {_currentCount}/{_targetCount}");
    }

    public override int CalculateAGP()
    {
        // base points each time, plus bonus on final
        int earned = _goalPoints;
        if (_currentCount == _targetCount)
            earned += _bonusPoints;
        return earned;
    }

    public override string SaveGoal()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_goalPoints}|{_bonusPoints}|{_targetCount}|{_currentCount}";
    }
}
