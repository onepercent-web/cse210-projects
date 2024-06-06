using System;

// Activity: class
class Activity
{
    protected DateTime date;
    protected int minutes;

    // Constructor: resetting
    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    // Method: Get distance
    public virtual double GetDistance()
    {
        return 0;
    }

    // Method: Get speed
    public virtual double GetSpeed()
    {
        return 0;
    }

    // Method: Get pace
    public virtual double GetPace()
    {
        return 0;
    }

    // Method: Get summary
    public virtual string GetSummary()
    {
        return $"Date: {date.ToShortDateString()}, Duration: {minutes} minutes";
    }
}

// Running: class
class Running : Activity
{
    private double distance;

    // Constructor: resetting
    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    // Method: Get distance
    public override double GetDistance()
    {
        return distance;
    }

    // Method: Get speed
    public override double GetSpeed()
    {
        return distance / (minutes / 60.0);
    }

    // Method: Get pace
    public override double GetPace()
    {
        return minutes / distance;
    }

    // Method: Get summary
    public override string GetSummary()
    {
        return $"{date.ToShortDateString()} Running ({minutes} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed():0.00} mph, Pace: {GetPace():0.00} min per mile";
    }
}

// Cycling: class
class Cycling : Activity
{
    private double distance;

    // Constructor: resetting
    public Cycling(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    // Method: Get distance 
    public override double GetDistance()
    {
        return distance;
    }

    // Method: speed
    public override double GetSpeed()
    {
        return distance / (minutes / 60.0);
    }

    // Method: Pace
    public override double GetPace()
    {
        return minutes / distance;
    }

    // Method: Get summary
    public override string GetSummary()
    {
        return $"{date.ToShortDateString()} Cycling ({minutes} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed():0.00} mph, Pace: {GetPace():0.00} min per mile";
    }
}

// Swimming: class
class Swimming : Activity
{
    private int laps;

    // Constructor: resetting
    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        this.laps = laps;
    }

    // Method: Get distance 
    public override double GetDistance()
    {
        return laps * 50 / 1000.0 * 0.62; // 距離をマイルで返す
    }

    // Method: speed
    public override double GetSpeed()
    {
        return GetDistance() / (minutes / 60.0);
    }

    // Method: Pace
    public override double GetPace()
    {
        return minutes / GetDistance();
    }

    // Method: Get summary
    public override string GetSummary()
    {
        return $"{date.ToShortDateString()} Swimming ({minutes} min) - Distance: {GetDistance():0.00} miles, Speed: {GetSpeed():0.00} mph, Pace: {GetPace():0.00} min per mile";
    }
}

// Program: class
class Program
{
    static void Main(string[] args)
    {
        // Activity list
        Activity running = new Running(new DateTime(2024, 6, 3), 20, 2.0);
        Activity cycling = new Cycling(new DateTime(2024, 6, 4), 40, 6.0);
        Activity swimming = new Swimming(new DateTime(2024, 6, 5), 30, 32);

        // Create an array of Activity
        Activity[] activities = { running, cycling, swimming };

        // Display summary of each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
