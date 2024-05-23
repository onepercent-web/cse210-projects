// Program.cs

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>(); // 目標のリスト
    static int totalScore = 0; // ユーザーの合計スコア

    static void Main(string[] args)
    {
        LoadGoals(); // 保存された目標とスコアを読み込む

        while (true)
        {
            ShowMenu(); // メニューを表示する
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    RecordGoalEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    ShowScore();
                    break;
                case "5":
                    SaveGoals();
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    // メニューを表示するメソッド
    static void ShowMenu()
    {
        Console.WriteLine("Eternal Quest Program");
        Console.WriteLine("1. Create a new goal");
        Console.WriteLine("2. Record a goal event");
        Console.WriteLine("3. Show goals");
        Console.WriteLine("4. Show score");
        Console.WriteLine("5. Save and exit");
    }

    // 新しい目標を作成するメソッド
    static void CreateNewGoal()
    {
        Console.WriteLine("Select the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string typeChoice = Console.ReadLine();

        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter the points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (typeChoice)
        {
            case "1":
                goals.Add(new SimpleGoal(name, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, points));
                break;
            case "3":
                Console.Write("Enter the required completions: ");
                int requiredCompletions = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, requiredCompletions, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid choice, goal not created.");
                break;
        }
    }

    // 目標達成を記録するメソッド
    static void RecordGoalEvent()
    {
        ShowGoals();
        Console.Write("Enter the number of the goal to record: ");
        int goalNumber = int.Parse(Console.ReadLine()) - 1;

        if (goalNumber >= 0 && goalNumber < goals.Count)
        {
            goals[goalNumber].Complete();
            totalScore += goals[goalNumber].Points;
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    // 目標のリストを表示するメソッド
    static void ShowGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            var goal = goals[i];
            Console.WriteLine($"{i + 1}. {goal.Name} - Points: {goal.Points}");
            if (goal is SimpleGoal sg)
                Console.WriteLine($"   Completed: {sg.IsCompleted}");
            else if (goal is ChecklistGoal cg)
                Console.WriteLine($"   Completed: {cg.CurrentCompletions}/{cg.RequiredCompletions}");
        }
    }

    // スコアを表示するメソッド
    static void ShowScore()
    {
        Console.WriteLine($"Total Score: {totalScore}");
    }

    // 目標とスコアを保存するメソッド
    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(totalScore);
            foreach (var goal in goals)
            {
                if (goal is SimpleGoal sg)
                {
                    writer.WriteLine($"Simple|{goal.Name}|{goal.Points}|{sg.IsCompleted}");
                }
                else if (goal is EternalGoal eg)
                {
                    writer.WriteLine($"Eternal|{goal.Name}|{goal.Points}");
                }
                else if (goal is ChecklistGoal cg)
                {
                    writer.WriteLine($"Checklist|{goal.Name}|{goal.Points}|{cg.RequiredCompletions}|{cg.BonusPoints}|{cg.CurrentCompletions}");
                }
            }
        }
    }

    // 目標とスコアを読み込むメソッド
    static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                totalScore = int.Parse(reader.ReadLine());
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Split('|');
                    string type = line[0];
                    string name = line[1];
                    int points = int.Parse(line[2]);

                    switch (type)
                    {
                        case "Simple":
                            bool isCompleted = bool.Parse(line[3]);
                            var sg = new SimpleGoal(name, points);
                            sg.SetIsCompleted(isCompleted);
                            goals.Add(sg);
                            break;
                        case "Eternal":
                            var eg = new EternalGoal(name, points);
                            goals.Add(eg);
                            break;
                        case "Checklist":
                            int requiredCompletions = int.Parse(line[3]);
                            int bonusPoints = int.Parse(line[4]);
                            int currentCompletions = int.Parse(line[5]);
                            var cg = new ChecklistGoal(name, points, requiredCompletions, bonusPoints)
                            {
                                CurrentCompletions = currentCompletions
                            };
                            goals.Add(cg);
                            break;
                    }
                }
            }
        }
    }
}
