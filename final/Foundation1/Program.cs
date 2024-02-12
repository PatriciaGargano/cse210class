using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string text)
    {
        Comment comment = new Comment(commenterName, text);
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Video 1", "Author 1", 120);
        video1.AddComment("Commenter A", "This is a great video!");
        video1.AddComment("Commenter B", "I learned a lot from this.");
        videos.Add(video1);

        Video video2 = new Video("Video 2", "Author 2", 180);
        video2.AddComment("Commenter C", "Could you explain this part again?");
        videos.Add(video2);

        Video video3 = new Video("Video 3", "Author 3", 150);
        video3.AddComment("Commenter D", "Amazing content!");
        video3.AddComment("Commenter E", "I disagree with your conclusion.");
        video3.AddComment("Commenter F", "This was very helpful, thanks!");
        videos.Add(video3);

        // Display video info
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
