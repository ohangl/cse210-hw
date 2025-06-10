using System;
using System.Collections.Generic;
using System.IO;

public class GoalsTracker
{
    private List<Goal> _goals = new List<Goal>();
    private int _accumulatedPoints = 0;

    // --- leveling fields ---
    private int _currentLevel = 1;
    private const int PointsPerLevel = 1000;

    
    public int CurrentLevel => _currentLevel;
    public string CurrentLevelTitle => GetLevelTitle(_currentLevel);

    private string GetLevelTitle(int level)
    {
        switch (level)
        {
        case 1:  return "Faith Seeker";
        case 2:  return "Covenant Keeper";
        case 3:  return "Temple Attendant";
        case 4:  return "Missionary";
        case 5:  return "Prophet";
        default: return "Lightbearer";
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = _accumulatedPoints / PointsPerLevel + 1;
        if (newLevel > _currentLevel)
        {
            _currentLevel = newLevel;
            var title = GetLevelTitle(_currentLevel);
            Console.WriteLine($"\n CONGRATS!! Level Up! You are now Level {_currentLevel}: {title}.\n");
        }
    }
    // --- end leveling ---

    public int GetAccumulatedPoints() => _accumulatedPoints;

    public void CreateGoal()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Choice: ");
        var type = Console.ReadLine();

        Console.Write("Name: ");
        var name = Console.ReadLine();
        Console.Write("Description: ");
        var desc = Console.ReadLine();
        Console.Write("Points for each event: ");
        var pts = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, pts));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, pts));
                break;
            case "3":
                Console.Write("Bonus points when complete: ");
                var bonus = int.Parse(Console.ReadLine());
                Console.Write("Number of times to complete: ");
                var target = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, pts, bonus, target));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            _goals[i].ListGoal();
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nWhich goal did you accomplish?");
        ListGoals();
        Console.Write("Enter goal number: ");
        int idx = int.Parse(Console.ReadLine()) - 1;

        if (idx < 0 || idx >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        var goal = _goals[idx];
        if (goal.IsComplete())
        {
            Console.WriteLine("That goal is already complete.");
            return;
        }

        goal.RecordEvent();
        int earned = goal.CalculateAGP();
        _accumulatedPoints += earned;
        Console.WriteLine($"Congratulations! You earned {earned} points.");
        Console.WriteLine($"Total points: {_accumulatedPoints}");

        // check for level up
        CheckLevelUp();
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        var file = Console.ReadLine();
        using (var writer = new StreamWriter(file))
        {
            writer.WriteLine(_accumulatedPoints);
            foreach (var g in _goals)
                writer.WriteLine(g.SaveGoal());
        }
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        var file = Console.ReadLine();
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        var lines = File.ReadAllLines(file);
        _goals.Clear();
        _accumulatedPoints = int.Parse(lines[0]);

        //  level without congratulating
        _currentLevel = _accumulatedPoints / PointsPerLevel + 1;

        for (int i = 1; i < lines.Length; i++)
        {
            var parts = lines[i].Split('|');
            switch (parts[0])
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        bool.Parse(parts[4])
                    ));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3])
                    ));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]),
                        int.Parse(parts[6])
                    ));
                    break;
            }
        }

        Console.WriteLine("Goals loaded.");
        Console.WriteLine($"You are currently Level {_currentLevel}: {GetLevelTitle(_currentLevel)}");
    }
}
