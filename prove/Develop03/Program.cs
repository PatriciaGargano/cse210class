using System;
using System.Collections.Generic;
using System.Linq;

public class ScriptureWord
{
    public string Word { get; private set; }
    public bool IsHidden { get; set; }

    public ScriptureWord(string word)
    {
        Word = word;
        IsHidden = false;
    }
}

public class ScriptureReference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int VerseStart { get; private set; }
    public int VerseEnd { get; private set; }

    public ScriptureReference(string reference)
    {
        // Assuming the reference is in the format "Book Chapter:Verse" or "Book Chapter:Verse-EndVerse"
        string[] parts = reference.Split(' ');

        Book = parts[0];
        Chapter = int.Parse(parts[1].Split(':')[0]);

        string[] verseParts = parts[1].Split(':')[1].Split('-');
        VerseStart = int.Parse(verseParts[0]);
        VerseEnd = verseParts.Length > 1 ? int.Parse(verseParts[1]) : VerseStart;
    }

    public override string ToString()
    {
        return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
    }
}

public class Scripture
{
    private List<ScriptureWord> words;
    private ScriptureReference reference;

    public Scripture(string reference, string text)
    {
        this.reference = new ScriptureReference(reference);
        words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"{reference} - {GetVisibleText()}");
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, words.Count(word => !word.IsHidden) + 1);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(words.Count);
            words[index].IsHidden = true;
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }

    private string GetVisibleText()
    {
        return string.Join(" ", words.Select(word => word.IsHidden ? "___" : word.Word));
    }
}

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        do
        {
            scripture.Display();

            Console.WriteLine("Press Enter to hide more words, or type 'quit' to end.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            scripture.HideRandomWords();
        } while (!scripture.AllWordsHidden());
    }
}
