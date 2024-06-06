using System;

// Address: class
class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

　　// Constructor: Set each address information
    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

　　// Obtain address information as a string
    public override string ToString()
    {
        return $"{street}\n{city}, {state}, {country}";
    }
}

// Event: class
class Event
{
    protected string title;
    protected string description;
    protected DateTime date;
    protected DateTime time;
    protected Address address;

    // Constructor: Sets common information for events
    public Event(string title, string description, DateTime date, DateTime time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    // Get standard event details
    public string GetStandardDetails()
    {
        return $"{title}\n{date.ToShortDateString()} @ {time.ToShortTimeString()}\n{address}";
    }

    // Get full event details
    public virtual string GetFullDetails()
    {
        return $"{GetStandardDetails()}";
    }

    // Get short event description
    public string GetShortDescription()
    {
        return $"{this.GetType().Name} - {title.Split(" - ")[0]} - {date.ToShortDateString()}";
    }
}

// Lecture: class
class Lecture : Event
{
    private string speaker;
    private int capacity;

    // Constructor: Set lecture information
    public Lecture(string title, string description, DateTime date, DateTime time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }
    // Get full lecture details
    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

// Reception: class
class Reception : Event
{
    private string rsvpEmail;

    // Constructor: Set reception information
    public Reception(string title, string description, DateTime date, DateTime time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    // Get full reception details
    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEmail: {rsvpEmail}";
    }
}

// outdoor: class
class Outdoor : Event
{
    private string weather;
    
    // Constructor: Set outdoor information
    public Outdoor(string title, string description, DateTime date, DateTime time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        this.weather = weather;
    }

    // Get full outdoor details
    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nWeather: {weather}";
    }
}

// Program: class
class Program
{
    static void Main(string[] args)
    {
        // Address list
        Address address1 = new Address("108 Blue St", "Sacramento", "CA", "USA");
        Address address2 = new Address("456 Silver St", "Frankfort", "KY", "USA");
        Address address3 = new Address("153 Light St", "Shibuya Ward", "TOKYO", "JAPAN");

        // Event list
        Event lecture = new Lecture("Object Oriented Programing - Inheritance", "Learn about inheritance in OOP", new DateTime(2024, 10, 2), new DateTime(2024, 10, 2, 18, 0, 0), address1, "Logan White", 500);
        Event reception = new Reception("Graduation - SHS 777 Graduation Party", "Celebrate the graduation of SHS 777", new DateTime(2025, 5, 16), new DateTime(2025, 5, 16, 10, 0, 0), address2, "newstars@shs777.com");
        Event outdoor = new Outdoor("Japan Tour - Tour the Japanese Rice Ball Shops", "Tour the historic Japanese Rice Ball Shops", new DateTime(2024, 7, 1), new DateTime(2024, 7, 1, 9, 30, 0), address3, "Sunny");

        // Create an array of events
        Event[] events = { lecture, reception, outdoor };

        // Display details of each event
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
