using System;

public class Address
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string ZipCode { get; }

    public Address(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State} {ZipCode}";
    }
}

public abstract class Event
{
    public string Title { get; }
    public string Description { get; }
    public DateTime Date { get; }
    public TimeSpan Time { get; }
    public Address Location { get; }

    public Event(string title, string description, DateTime date, TimeSpan time, Address location)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Location = location;
    }

    public abstract string GetStandardDetails();
    public abstract string GetFullDetails();
    public abstract string GetShortDescription();
}

public class Lecture : Event
{
    public string Speaker { get; }
    public int Capacity { get; }

    public Lecture(string title, string description, DateTime date, TimeSpan time, string speaker, int capacity, Address location)
        : base(title, description, date, time, location)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetStandardDetails()
    {
        return $"Title: {Title}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nLocation: {Location}";
    }

    public override string GetFullDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nSpeaker: {Speaker}\nCapacity: {Capacity}\nLocation: {Location}";
    }

    public override string GetShortDescription()
    {
        return $"{Title}: {Description}";
    }
}

public class Reception : Event
{
    public string RSVPContact { get; }

    public Reception(string title, string description, DateTime date, TimeSpan time, Address location, string rsvpContact)
        : base(title, description, date, time, location)
    {
        RSVPContact = rsvpContact;
    }

    public override string GetStandardDetails()
    {
        return $"Title: {Title}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nLocation: {Location}";
    }

    public override string GetFullDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nRSVP Contact: {RSVPContact}\nLocation: {Location}";
    }

    public override string GetShortDescription()
    {
        return $"{Title}: {Description}";
    }
}

public class OutdoorGathering : Event
{
    public string WeatherForecast { get; }

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address location, string weatherForecast)
        : base(title, description, date, time, location)
    {
        WeatherForecast = weatherForecast;
    }

    public override string GetStandardDetails()
    {
        return $"Title: {Title}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nLocation: {Location}";
    }

    public override string GetFullDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nWeather Forecast: {WeatherForecast}\nLocation: {Location}";
    }

    public override string GetShortDescription()
    {
        return $"{Title}: {Description}";
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // Create some events
        Address address1 = new Address("123 Main St", "New York", "NY", "10001");
        Lecture lecture = new Lecture("Introduction to C#", "Learn the basics of C#", new DateTime(2023, 4, 10), new TimeSpan(14, 0, 0), "John Smith", 50, address1);

        Address address2 = new Address("456 Elm St", "Los Angeles", "CA", "90001");
        Reception reception = new Reception("Spring Mixer", "Join us for drinks and hors d'oeuvres", new DateTime(2023, 4, 15), new TimeSpan(18, 30, 0), address2, "rsvp@example.com");

        Address address3 = new Address("789 Oak St", "Chicago", "IL", "60601");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Picnic in the Park", "Enjoy the outdoors with friends and family", new DateTime(2023, 4, 20), new TimeSpan(11, 0, 0), address3, "Sunny and warm");

        // Generate marketing messages
        Console.WriteLine("Standard details:");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine("*************************************");

        Console.WriteLine("\nFull details:");
        Console.WriteLine("");
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine("_______");
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine("_______");
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine("***********************************");

        Console.WriteLine("\nShort descriptions:");
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine(outdoorGathering.GetShortDescription());

        Console.ReadLine();
    }
}
