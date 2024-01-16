using System;

public class Job
{
    // Properties for the Job class
    public string JobTitle { get; set; }
    public string Company { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }

    // Display method to show job details
    public void Display()
    {
        Console.WriteLine($"Job Title: {JobTitle}");
        Console.WriteLine($"Company: {Company}");
        Console.WriteLine($"Start Year: {StartYear}");
        Console.WriteLine($"End Year: {EndYear}\n");
    }
}
