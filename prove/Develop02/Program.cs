using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        Menu(journal);
    }

    static void Menu(Journal journal)
    {
        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    DisplayJournal(journal);
                    break;
                case "3":
                    SaveToAFile(journal);
                    break;
                case "4":
                    LoadFromAFile(journal);
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");

        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry(prompt, response, DateTime.Now);
        journal.AddEntry(newEntry);

        Console.WriteLine("Entry added successfully.\n");
    }

    static void DisplayJournal(Journal journal)
    {
        List<Entry> entries = journal.GetEntries();

        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}\nPrompt: {entry.Prompt}\nResponse: {entry.Response}\n");
        }
    }

    static void SaveToAFile(Journal journal)
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in journal.GetEntries())
            {
                writer.WriteLine($"{entry.Date} - {entry.Prompt}: {entry.Response}");
            }
        }

        Console.WriteLine("Journal saved to file successfully.\n");
    }

    static void LoadFromAFile(Journal journal)
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Parse the line to extract date, prompt, and response
                    // Create Entry object and add it to the journal
                }
            }

            Console.WriteLine("Journal loaded from file successfully.\n");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Please provide a valid filename.\n");
        }
    }

    static string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}

class Entry
{
    public string Prompt { get; }
    public string Response { get; }
    public DateTime Date { get; }

    public Entry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}

class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public List<Entry> GetEntries()
    {
        return entries;
    }
}
