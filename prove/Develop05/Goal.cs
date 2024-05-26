public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Value { get; set; }
    public bool IsCompleted { get; set; }

    protected Goal(string name, string description, int value)
    {
        Name = name;
        Description = description;
        Value = value;
        IsCompleted = false;
    }

    public abstract void RecordEvent();
    public abstract string GetStatus();
}
