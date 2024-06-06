using System;

// Activityクラスはエクササイズの共通情報を保持します
class Activity
{
    // 保護されたメンバー変数（派生クラスからアクセス可能）
    protected DateTime date;
    protected int minutes;

    // コンストラクタで初期化
    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    // 距離を計算して返す仮想メソッド（派生クラスでオーバーライドされる）
    public virtual double GetDistance()
    {
        return 0;
    }

    // 速度を計算して返す仮想メソッド（派生クラスでオーバーライドされる）
    public virtual double GetSpeed()
    {
        return 0;
    }

    // ペースを計算して返す仮想メソッド（派生クラスでオーバーライドされる）
    public virtual double GetPace()
    {
        return 0;
    }

    // サマリー情報を文字列で返すメソッド
    public virtual string GetSummary()
    {
        return $"Date: {date.ToShortDateString()}, Duration: {minutes} minutes";
    }
}

// Runningクラスはランニングエクササイズの情報を保持します
class Running : Activity
{
    // ランニング固有の情報
    private double distance;

    // コンストラクタで初期化
    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    // 距離を返すオーバーライドメソッド
    public override double GetDistance()
    {
        return distance;
    }

    // 速度を計算して返すオーバーライドメソッド
    public override double GetSpeed()
    {
        return distance / (minutes / 60.0);
    }

    // ペースを計算して返すオーバーライドメソッド
    public override double GetPace()
    {
        return minutes / distance;
    }

    // サマリー情報を返すオーバーライドメソッド
    public override string GetSummary()
    {
        return $"{date.ToShortDateString()} Running ({minutes} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed():0.00} mph, Pace: {GetPace():0.00} min per mile";
    }
}

// Cyclingクラスはサイクリングエクササイズの情報を保持します
class Cycling : Activity
{
    // サイクリング固有の情報
    private double distance;

    // コンストラクタで初期化
    public Cycling(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    // 距離を返すオーバーライドメソッド
    public override double GetDistance()
    {
        return distance;
    }

    // 速度を計算して返すオーバーライドメソッド
    public override double GetSpeed()
    {
        return distance / (minutes / 60.0);
    }

    // ペースを計算して返すオーバーライドメソッド
    public override double GetPace()
    {
        return minutes / distance;
    }

    // サマリー情報を返すオーバーライドメソッド
    public override string GetSummary()
    {
        return $"{date.ToShortDateString()} Cycling ({minutes} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed():0.00} mph, Pace: {GetPace():0.00} min per mile";
    }
}

// Swimmingクラスは水泳エクササイズの情報を保持します
class Swimming : Activity
{
    // 水泳固有の情報
    private int laps;

    // コンストラクタで初期化
    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        this.laps = laps;
    }

    // 距離を計算して返すオーバーライドメソッド
    public override double GetDistance()
    {
        return laps * 50 / 1000.0 * 0.62; // 距離をマイルで返す
    }

    // 速度を計算して返すオーバーライドメソッド
    public override double GetSpeed()
    {
        return GetDistance() / (minutes / 60.0);
    }

    // ペースを計算して返すオーバーライドメソッド
    public override double GetPace()
    {
        return minutes / GetDistance();
    }

    // サマリー情報を返すオーバーライドメソッド
    public override string GetSummary()
    {
        return $"{date.ToShortDateString()} Swimming ({minutes} min) - Distance: {GetDistance():0.00} miles, Speed: {GetSpeed():0.00} mph, Pace: {GetPace():0.00} min per mile";
    }
}

// メインプログラム
class Program
{
    static void Main(string[] args)
    {
        // 指定されたデータで各エクササイズオブジェクトを作成
        Activity running = new Running(new DateTime(2024, 6, 3), 20, 2.0); // ランニングの距離は2.0マイル
        Activity cycling = new Cycling(new DateTime(2024, 6, 4), 40, 6.0); // サイクリングの距離は6.0マイル
        Activity swimming = new Swimming(new DateTime(2024, 6, 5), 30, 32); // 水泳のラップ数は32 (1マイル)

        // エクササイズオブジェクトの配列を作成
        Activity[] activities = { running, cycling, swimming };

        // 各エクササイズのサマリー情報を表示
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary()); // サマリー情報を表示
        }
    }
}
