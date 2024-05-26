public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int Bonus { get; set; }

    public ChecklistGoal(string name, string description, int value, int targetCount, int bonus) 
        : base(name, description, value)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        Bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            if (CurrentCount == TargetCount)
            {
                IsCompleted = true;
            }
        }
    }

    public override string GetStatus()
    {
        return IsCompleted 
            ? $"[X] {Name} ({Description}) -- Currently completed: {CurrentCount}/{TargetCount}" 
            : $"[ ] {Name} ({Description}) -- Currently completed: {CurrentCount}/{TargetCount}";
    }
}
