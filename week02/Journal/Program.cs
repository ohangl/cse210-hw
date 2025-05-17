using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


/// comment about creativity: 
/// for creativity I added the option to save and load the journal in JSON format.



public class Program
{
    private static Journal _journal = new Journal();
    private static string[] _prompts = new string[]
    {
        "What did I learn today?",
        "What made me happy today?",
        "What could I do better tomorrow?",
        "Who did I talk to today?",
        "What did I eat today that I enjoyed?"
    };

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nJournal Program Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Save the journal to a JSON file");
            Console.WriteLine("6. Load the journal from a JSON file");
            Console.WriteLine("7. Search journal entries");
            Console.WriteLine("8. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    _journal.DisplayEntries();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    SaveJournalToJson();
                    break;
                case "6":
                    LoadJournalFromJson();
                    break;
                case "7":
                    SearchEntries();
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void WriteNewEntry()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Length)];

        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        _journal.AddEntry(prompt, response);
        Console.WriteLine("Entry added.");
    }

    private static void SaveJournal()
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();

        try
        {
            _journal.SaveToFile(filename);
            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    private static void LoadJournal()
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();

        try
        {
            _journal.LoadFromFile(filename);
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }

    private static void SaveJournalToJson()
    {
        Console.Write("Enter the filename to save the journal as JSON: ");
        string filename = Console.ReadLine();

        try
        {
            _journal.SaveToJson(filename);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal to JSON: {ex.Message}");
        }
    }

    private static void LoadJournalFromJson()
    {
        Console.Write("Enter the filename to load the journal from JSON: ");
        string filename = Console.ReadLine();

        try
        {
            _journal.LoadFromJson(filename);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal from JSON: {ex.Message}");
        }
    }

    private static void SearchEntries()
    {
        Console.Write("Enter a keyword to search for: ");
        string keyword = Console.ReadLine();

        var entries = _journal.GetEntries();
        foreach (var entry in entries)
        {
            if (entry.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(entry);
            }
        }
    }
}