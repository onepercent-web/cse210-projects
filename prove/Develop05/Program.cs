using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        LoadData();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.WriteLine("---------------------");
            Console.Write("Select a choice from the menu: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveData();
                    break;
                case "4":
                    LoadData();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string option = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int value = int.Parse(Console.ReadLine());

        switch (option)
        {
            case "1":
                goals.Add(new SimpleGoal(name, description, value));
                break;
            case "2":
                goals.Add(new EternalGoal(name, description, value));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, value, targetCount, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type. Please try again.");
                break;
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
        Console.WriteLine($"You have {score} points.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            goals[index].RecordEvent();
            score += goals[index].Value;
            if (goals[index] is ChecklistGoal checklistGoal && checklistGoal.IsCompleted)
            {
                score += checklistGoal.Bonus;
            }
            Console.WriteLine("Event recorded.");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void SaveData()
    {
        var data = new
        {
            Score = score,
            Goals = goals
        };
        File.WriteAllText("goals.json", JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
        Console.WriteLine("Data saved successfully.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void LoadData()
    {
        if (File.Exists("goals.json"))
        {
            var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(File.ReadAllText("goals.json"));
            score = data["Score"].GetInt32();
            goals.Clear();
            foreach (var goalData in data["Goals"].EnumerateArray())
            {
                string name = goalData.GetProperty("Name").GetString();
                string description = goalData.GetProperty("Description").GetString();
                int value = goalData.GetProperty("Value").GetInt32();
                bool isCompleted = goalData.GetProperty("IsCompleted").GetBoolean();
                string type = goalData.GetProperty("Type").GetString();

                Goal goal = type switch
                {
                    "SimpleGoal" => new SimpleGoal(name, description, value),
                    "EternalGoal" => new EternalGoal(name, description, value),
                    "ChecklistGoal" => new ChecklistGoal(name, description, value, 
                                        goalData.GetProperty("TargetCount").GetInt32(), 
                                        goalData.GetProperty("Bonus").GetInt32())
                    {
                        CurrentCount = goalData.GetProperty("CurrentCount").GetInt32(),
                        IsCompleted = isCompleted
                    },
                    _ => throw new InvalidOperationException("Unknown goal type.")
                };

                goals.Add(goal);
            }
            Console.WriteLine("Data loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved data found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
