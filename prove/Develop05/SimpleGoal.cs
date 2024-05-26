public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int value) : base(name, description, value) { }

    public override void RecordEvent()
    {
        IsCompleted = true;
    }

    public override string GetStatus()
    {
        return IsCompleted ? $"[X] {Name} ({Description})" : $"[ ] {Name} ({Description})";
    }
}
