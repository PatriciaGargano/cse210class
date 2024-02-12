using System;
using System.Collections.Generic;

public class Activity
{
    protected DateTime date;
    protected int durationInMinutes;

    public Activity(DateTime date, int durationInMinutes)
    {
        this.date = date;
        this.durationInMinutes = durationInMinutes;
    }

    public virtual double GetDistance()
    {
        return 0; // Base class doesn't have distance calculation
    }

    public virtual double GetSpeed()
    {
        return 0; // Base class doesn't have speed calculation
    }

    public virtual double GetPace()
    {
        return 0; // Base class doesn't have pace calculation
    }

    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} - {GetType().Name} ({durationInMinutes} min)";
    }
}

public class Running : Activity
{
    private double distance; // in miles

    public Running(DateTime date, int durationInMinutes, double distance) : base(date, durationInMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (durationInMinutes / 60.0);
    }

    public override double GetPace()
    {
        return durationInMinutes / distance;
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance: {distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

public class StationaryBicycle : Activity
{
    private double speed; // in mph

    public StationaryBicycle(DateTime date, int durationInMinutes, double speed) : base(date, durationInMinutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60.0 / speed; // Pace in minutes per mile
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Speed: {speed} mph, Pace: {GetPace()} min per mile";
    }
}

public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int durationInMinutes, int laps) : base(date, durationInMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50.0 / 1000 * 0.62; // Convert meters to miles
    }

    public override double GetSpeed()
    {
        return GetDistance() / (durationInMinutes / 60.0);
    }

    public override double GetPace()
    {
        return durationInMinutes / GetDistance();
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        DateTime date1 = new DateTime(2022, 11, 3);
        Running running = new Running(date1, 30, 3.0);
        activities.Add(running);

        DateTime date2 = new DateTime(2022, 11, 4);
        StationaryBicycle bicycle = new StationaryBicycle(date2, 45, 15.0);
        activities.Add(bicycle);

        DateTime date3 = new DateTime(2022, 11, 5);
        Swimming swimming = new Swimming(date3, 60, 20);
        activities.Add(swimming);

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

