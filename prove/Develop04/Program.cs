using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ExecuteBreathingActivity();
                    break;

                case "2":
                    ExecuteReflectionActivity();
                    break;

                case "3":
                    ExecuteListingActivity();
                    break;

                case "4":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    static void ExecuteBreathingActivity()
    {
        Console.Write("Enter the duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        BreathingActivity breathingActivity = new BreathingActivity();
        breathingActivity.StartActivity(duration);
    }

    static void ExecuteReflectionActivity()
    {
        Console.Write("Enter the duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        ReflectionActivity reflectionActivity = new ReflectionActivity();
        reflectionActivity.StartActivity(duration);
    }

    static void ExecuteListingActivity()
    {
        Console.Write("Enter the duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        ListingActivity listingActivity = new ListingActivity();
        listingActivity.StartActivity(duration);
    }
}

class Activity
{
    public string Name { get; }
    public string Description { get; }

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void StartActivity(int duration)
    {
        ShowStartMessage();
        Thread.Sleep(3000);
        ShowPrepareMessage();
        Thread.Sleep(3000);
        PerformActivity(duration);
        ShowEndMessage(duration);
        Thread.Sleep(3000);
    }

    protected virtual void ShowStartMessage()
    {
        Console.WriteLine($"\nStarting {Name} Activity:");
        Console.WriteLine(Description);
        Console.WriteLine("Please set the duration for the activity.");
    }

    protected void ShowPrepareMessage()
    {
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);
    }

    protected void ShowEndMessage(int duration)
    {
        Console.WriteLine($"Good job! You have completed the activity.");
        Console.WriteLine($"{Name} Activity Time: {duration} seconds");
    }

    protected virtual void PerformActivity(int duration)
    {
        // To be overridden by subclasses
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity(int duration)
    {
        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000);
        }
    }
}

class ReflectionActivity : Activity
{
    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void PerformActivity(int duration)
    {
        string[] prompts =
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        Random random = new Random();

        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            Thread.Sleep(2000);
            AskReflectionQuestions();
        }
    }

    private void AskReflectionQuestions()
    {
        string[] questions =
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "Will you do this again?",
            "Are you going to share your experience with others?",
            "Will you recommend this activity"
        };

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(2000);
        }
    }
}

class ListingActivity : Activity
{
    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity(int duration)
    {
        string[] prompts =
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        Random random = new Random();

        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            Thread.Sleep(5000);  // Give more time for listing
            ListItems();
        }
    }

    private void ListItems()
    {
        List<string> items = new List<string>();

        Console.WriteLine("Enter items (type 'done' to finish): ");
        while (true)
        {
            string item = Console.ReadLine();
            if (item.ToLower() == "done")
                break;

            items.Add(item);
        }

        Console.WriteLine($"\nNumber of items entered: {items.Count}");
    }
}
