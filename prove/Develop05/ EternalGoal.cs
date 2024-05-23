// EternalGoal.cs

using System;

public class EternalGoal : Goal
{
    // コンストラクタ
    public EternalGoal(string name, int points) : base(name, points)
    {
    }

    // 目標を達成したときに呼ばれるメソッドの実装
    public override void Complete()
    {
        Console.WriteLine($"{Name} recorded! You earned {Points} points.");
    }
}
