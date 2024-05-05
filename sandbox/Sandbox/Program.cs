using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            switch (Console.ReadLine())
            {
                case "1":
                    journal.WriteEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.LoadJournal();
                    break;
                case "4":
                    journal.SaveJournal();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}

// Journal class to handle journal operations
class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void WriteEntry()
    {
        string prompt = Entry.GetRandomPrompt();
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        Entry newEntry = new Entry(prompt, response, DateTime.Now.ToString("yyyy-MM-dd"));
        entries.Add(newEntry);
        Console.WriteLine("Entry added!");
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveJournal()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                sw.WriteLine(entry.ToFileString());
            }
        }
        Console.WriteLine("Journal saved.");
    }

    public void LoadJournal()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        entries.Clear(); // Clear current entries
        using (StreamReader sr = new StreamReader(filename))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                entries.Add(new Entry(parts[0], parts[1], parts[2]));
            }
        }
        Console.WriteLine("Journal loaded.");
    }
}

// Entry class to represent a single journal entry
class Entry
{
    private string prompt;
    private string response;
    private string date;

    public Entry(string prompt, string response, string date)
    {
        this.prompt = prompt;
        this.response = response;
        this.date = date;
    }

    // Return a string representation of the entry
    public override string ToString()
    {
        return $"Date: {date}\nPrompt: {prompt}\nResponse: {response}\n";
    }

    // Return a file-friendly string representation of the entry
    public string ToFileString()
    {
        return $"{prompt}|{response}|{date}";
    }

    // Generate a random prompt
    public static string GetRandomPrompt()
    {
        string[] prompts = new string[]
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        Random rand = new Random();
        return prompts[rand.Next(prompts.Length)];
    }
}
