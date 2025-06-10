using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _goalPoints;
    protected bool _status;

    protected Goal(string name, string description, int goalPoints)
    {
        _name = name;
        _description = description;
        _goalPoints = goalPoints;
        _status = false;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract void ListGoal();
    public abstract int CalculateAGP();
    public abstract string SaveGoal();
}
