class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job
        {
            JobTitle = "Software Engineer",
            Company = "Microsoft",
            StartYear = 2019,
            EndYear = 2022
        };

        Job job2 = new Job
        {
            JobTitle = "Manager",
            Company = "Apple",
            StartYear = 2022,
            EndYear = 2023
        };

        // Display job details using the new Display method
        job1.Display();
        job2.Display();
    }
}
