using System;

// Addressクラスは住所の情報を保持します
class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public override string ToString()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

// Eventクラスはイベントの共通情報を保持します
class Event
{
    protected string title;
    protected string description;
    protected DateTime date;
    protected DateTime time;
    protected Address address;

    public Event(string title, string description, DateTime date, DateTime time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetStandardDetails()
    {
        return $"{title}\n{date.ToShortDateString()} @ {time.ToShortTimeString()}\n{address}";
    }

    public virtual string GetFullDetails()
    {
        return $"{GetStandardDetails()}";
    }

    public string GetShortDescription()
    {
        return $"{this.GetType().Name} - {title} - {date.ToShortDateString()}";
    }
}

// Lectureクラスは講演会の情報を保持します
class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, DateTime time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

// Receptionクラスはレセプションの情報を保持します
class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, DateTime time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEmail: {rsvpEmail}";
    }
}

// OutdoorGatheringクラスは屋外集会の情報を保持します
class OutdoorGathering : Event
{
    private string weather;

    public OutdoorGathering(string title, string description, DateTime date, DateTime time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        this.weather = weather;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nWeather: {weather}";
    }
}

// メインプログラム
class Program
{
    static void Main(string[] args)
    {
        // 住所オブジェクトを作成
        Address address1 = new Address("108 Blue St", "Sacramento", "CA", "USA");
        Address address2 = new Address("456 Silver St", "Frankfort", "KY", "USA");
        Address address3 = new Address("246 Oak Circle", "London", "England", "UK");

        // 各イベントオブジェクトを作成
        Event lecture = new Lecture("Object Oriented Programing - Inheritance", "Learn about inheritance in OOP", new DateTime(2023, 1, 1), new DateTime(2023, 1, 1, 9, 0, 0), address1, "Bob the Builder", 100);
        Event reception = new Reception("Graduation - MSD 321 Graduation Party", "Celebrate the graduation of MSD 321", new DateTime(2023, 6, 1), new DateTime(2023, 6, 1, 19, 0, 0), address2, "grad@msd321.com");
        Event outdoorGathering = new OutdoorGathering("Bridge Tour - Tour the London Bridge", "Tour the historic London Bridge", new DateTime(2023, 10, 13), new DateTime(2023, 10, 13, 11, 30, 0), address3, "Sunny");

        // イベントオブジェクトの配列を作成
        Event[] events = { lecture, reception, outdoorGathering };

        // 各イベントの詳細を表示
        foreach (var eventItem in events)
        {
            Console.WriteLine(eventItem.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine($"Type: {eventItem.GetType().Name}");
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(eventItem.GetShortDescription());
            Console.WriteLine("============================");
            Console.WriteLine();
        }
    }
}
