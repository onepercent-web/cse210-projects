// SimpleGoal.cs

using System;

public class SimpleGoal : Goal
{
    public bool IsCompleted { get; private set; } // 目標が達成されたかどうか

    // コンストラクタ
    public SimpleGoal(string name, int points) : base(name, points)
    {
        IsCompleted = false;
    }

    // 目標を達成したときに呼ばれるメソッドの実装
    public override void Complete()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"{Name} has been completed! You earned {Points} points.");
        }
    }

    // IsCompleted プロパティの値を設定するメソッド（外部から設定するため）
    public void SetIsCompleted(bool value)
    {
        IsCompleted = value;
    }
}
