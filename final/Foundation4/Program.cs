using System;

// Activityクラスはエクササイズの共通情報を保持します
class Activity
{
    protected DateTime date;
    protected int minutes;

    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"Date: {date.ToShortDateString()}, Duration: {minutes} minutes";
    }
}

// Runningクラスはランニングエクササイズの情報を保持します
class Running : Activity
{
    private double distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (minutes / 60.0);
    }

    public override double GetPace()
    {
        return minutes / distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile";
    }
}

// Cyclingクラスはサイクリングエクササイズの情報を保持します
class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetDistance()
    {
        return speed * (minutes / 60.0);
    }

    public override double GetPace()
    {
        return 60.0 / speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Speed: {GetSpeed()} mph, Distance: {GetDistance()} miles, Pace: {GetPace()} min/mile";
    }
}

// Swimmingクラスは水泳エクササイズの情報を保持します
class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (minutes / 60.0);
    }

    public override double GetPace()
    {
        return minutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Laps: {laps}, Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile";
    }
}

// メインプログラム
class Program
{
    static void Main(string[] args)
    {
        Activity running = new Running(DateTime.Now, 30, 3.0);
        Activity cycling = new Cycling(DateTime.Now, 60, 15.0);
        Activity swimming = new Swimming(DateTime.Now, 45, 20);

        Activity[] activities = { running, cycling, swimming };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
