public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int value) : base(name, description, value) { }

    public override void RecordEvent()
    {
        // Eternal goals are never marked as complete
    }

    public override string GetStatus()
    {
        return $"[∞] {Name} ({Description})";
    }
}
