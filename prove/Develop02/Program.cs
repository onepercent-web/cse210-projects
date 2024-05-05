using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        //Program start message
        Console.WriteLine("Welcome to the Journal Program!");

  
        Journal journal = new Journal();

        bool isRunning = true;
        while (isRunning)
        {
            // Display choices to the user
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            //Get user selection
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    //Display random questions to users, receive answers, and add to journal
                    journal.WriteNewEntry();
                    break;
                case "2":
                    //Display the journal
                    journal.DisplayJournal();
                    break;
                case "3":
                    //Load the journal from file
                    journal.LoadJournal();
                    break;
                case "4":
                    //Save the journal in file
                    journal.SaveJournal();
                    break;
                case "5":
                    //Finished the program
                    isRunning = false;
                    break;
                default:
                    //Displays error message if invalid selection is made
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

class Journal
{
    private string[] prompts = {
        "Who was the funniest person you met today?",
        "If there is one thing that happened today that you can thank God for, what is it?",
        "In what situation did you feel the Lord's love today?",
        "What was something you found yourself thinking about today?",
        "If today were a holiday, what would you have wanted to do?"
    };

    public void WriteNewEntry()
    {
        //Chose the ramdom question
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");

        //Receive users' answers
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");

        string entry = $"{date}: {prompt}\n{response}\n";

        File.AppendAllText("journal.txt", entry);
    }

 public void DisplayJournal()
    {
        //Displays the contents of the diary file示
        if (File.Exists("journal.txt"))
        {
            string[] entries = File.ReadAllLines("journal.txt");
            foreach (string entry in entries)
            {
                Console.WriteLine(entry);
            }
        }
        else
        {
            // Displays a message if the diary file does not exist
            Console.WriteLine("No entries found.");
        }
    }

    public void SaveJournal()
    {
        // Ask the user for the name of the file to save
        Console.Write("Enter file name to save: ");
        string fileName = Console.ReadLine();

        //Copy and save files
        File.Copy("journal.txt", fileName, true);
        Console.WriteLine("Journal saved successfully.");
    }
    public void LoadJournal()
    {
        // Ask the user for the name of the file to be loaded
        Console.Write("Enter file name to load: ");
        string fileName = Console.ReadLine();

        // Load the file if it exists
        if (File.Exists(fileName))
        {
            File.Copy(fileName, "journal.txt", true);
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            // Displays error message if file not found
            Console.WriteLine("File not found.");
        }
    }
}

