using System;

public class Address
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

    public string GetAddress()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}

public abstract class Event
{
    private string title;
    private string description;
    private DateTime dateTime;
    private Address address;

    public Event(string title, string description, DateTime dateTime, Address address)
    {
        this.title = title;
        this.description = description;
        this.dateTime = dateTime;
        this.address = address;
    }

    public string GetTitle()
    {
        return title;
    }

    public string GetDescription()
    {
        return description;
    }

    public DateTime GetDateTime()
    {
        return dateTime;
    }

    public Address GetAddress()
    {
        return address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Event: {title}\nDescription: {description}\nDate: {dateTime.ToShortDateString()}\nTime: {dateTime.ToShortTimeString()}\nAddress: {address.GetAddress()}";
    }

    public abstract string GetFullDetails();

    public abstract string GetShortDescription();
}

public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime dateTime, Address address, string speaker, int capacity)
        : base(title, description, dateTime, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return GetStandardDetails() + $"\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Lecture\nEvent: {GetTitle()}\nDate: {GetDateTime().ToShortDateString()}";
    }
}

public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime dateTime, Address address, string rsvpEmail)
        : base(title, description, dateTime, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return GetStandardDetails() + $"\nType: Reception\nRSVP Email: {rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Reception\nEvent: {GetTitle()}\nDate: {GetDateTime().ToShortDateString()}";
    }
}

public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime dateTime, Address address, string weatherForecast)
        : base(title, description, dateTime, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return GetStandardDetails() + $"\nType: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Outdoor Gathering\nEvent: {GetTitle()}\nDate: {GetDateTime().ToShortDateString()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Lecture lecture = new Lecture("Tech Talk", "Discussion on AI", DateTime.Now, address1, "John Doe", 50);
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(lecture.GetShortDescription());

        Address address2 = new Address("456 Oak St", "Anothercity", "NY", "USA");
        Reception reception = new Reception("Networking Event", "Meet and greet", DateTime.Now, address2, "info@example.com");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(reception.GetShortDescription());

        Address address3 = new Address("789 Pine St", "Cityville", "FL", "USA");
        OutdoorGathering gathering = new OutdoorGathering("Community Picnic", "Fun in the sun", DateTime.Now, address3, "Sunny");
        Console.WriteLine(gathering.GetStandardDetails());
        Console.WriteLine(gathering.GetFullDetails());
        Console.WriteLine(gathering.GetShortDescription());
    }
}
