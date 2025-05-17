using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<JournalEntry> _entries;

    public Journal()
    {
        _entries = new List<JournalEntry>();
    }

    public void AddEntry(string prompt, string response)
    {
        string date = DateTime.Now.ToShortDateString();
        _entries.Add(new JournalEntry(prompt, response, date));
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries available.");
            return;
        }

        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            if (parts.Length == 3)
            {
                _entries.Add(new JournalEntry(parts[1], parts[2], parts[0]));
            }
        }
    }

    public void SaveToJson(string filename)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(filename, json);
        Console.WriteLine("Journal saved to JSON file successfully.");
    }

    public void LoadFromJson(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        string json = File.ReadAllText(filename);
        _entries = JsonSerializer.Deserialize<List<JournalEntry>>(json);
        Console.WriteLine("Journal loaded from JSON file successfully.");
    }

    public List<JournalEntry> GetEntries()
    {
        return _entries;
    }
}
