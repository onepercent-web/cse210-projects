// ChecklistGoal.cs

using System;

public class ChecklistGoal : Goal
{
    public int RequiredCompletions { get; private set; } // 目標達成に必要な回数
    public int CurrentCompletions { get; set; } // 現在の達成回数
    public int BonusPoints { get; private set; } // ボーナスポイント

    // コンストラクタ
    public ChecklistGoal(string name, int points, int requiredCompletions, int bonusPoints)
        : base(name, points)
    {
        RequiredCompletions = requiredCompletions;
        BonusPoints = bonusPoints;
        CurrentCompletions = 0;
    }

    // 目標を達成したときに呼ばれるメソッドの実装
    public override void Complete()
    {
        CurrentCompletions++;
        Console.WriteLine($"{Name} recorded! You earned {Points} points.");

        if (CurrentCompletions >= RequiredCompletions)
        {
            Console.WriteLine($"Congratulations! You completed {Name} and earned a bonus of {BonusPoints} points.");
            CurrentCompletions = 0; // 目標をリセットして再度チャレンジ可能にする場合
        }
    }
}
