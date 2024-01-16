using System;
using System.Collections.Generic;

public class Resume
{
    // Properties for the Resume class
    public string Name { get; set; }
    public List<Job> Jobs { get; set; }

    // Constructor to initialize the Jobs list
    public Resume()
    {
        Jobs = new List<Job>();
    }

    // Display method to show resume information
    public void Display()
    {
        Console.WriteLine($"Resume of {Name}\n");

        foreach (var job in Jobs)
        {
            Console.WriteLine($"Job Title: {job.JobTitle}");
            Console.WriteLine($"Company: {job.Company}");
            Console.WriteLine($"Start Year: {job.StartYear}");
            Console.WriteLine($"End Year: {job.EndYear}\n");
        }
    }
}
