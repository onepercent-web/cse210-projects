using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of videos
        List<Video> videos = new List<Video>();

        // Create video 1 and add comments
        Video video1 = new Video("I've been traveling in Japan for 10 days!", "Yellow Blade", 2000);
        video1.AddComment(new Comment("Zero", "Great video!"));
        video1.AddComment(new Comment("Mac", "I learned that Japan has many beautiful places."));
        video1.AddComment(new Comment("Nephi", "Thanks for sharing."));
        

        // Create video 2 and add comments
        Video video2 = new Video("Let's made vegetable tortillas in 100 seconds!", "Genius 100 Second Cooking", 300);
        video2.AddComment(new Comment("Alpha", "I was impressed!"));
        video2.AddComment(new Comment("Lucas", "Very fun video! I love it!"));

        // Create video 3 and add comments
        Video video3 = new Video("Highway Trip with One's Beloved Car", "HARDTOP", 1322);
        video3.AddComment(new Comment("Ruby", "I always like going to highway parking areas."));
        video3.AddComment(new Comment("Berry", "It was a lot of fun to watch."));
        video3.AddComment(new Comment("Aqua", "I can't wait to get my car license soon!!"));
        video3.AddComment(new Comment("Nephi", "Thanks for sharing."));
        
        // Add video to list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Displays information about each video
        foreach (Video video in videos)
        {
            video.ShowVideoDetails();
            Console.WriteLine();
        }
    }
}

// Video: class
class Video
{
    private string title;
    private string author;
    private int length;
    private List<Comment> comments;

    // Constructor: Set video title, author, and length
    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        this.comments = new List<Comment>();
    }

    // Methods to add comments
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // Method to get the number of comments
    public int GetCommentCount()
    {
        return comments.Count;
    }

    // Methods to display video details
    public void ShowVideoDetails()
    {
        Console.WriteLine($"{title} ({length})");
        Console.WriteLine($"Comments({GetCommentCount()})");
        foreach (Comment comment in comments)
        {
            Console.WriteLine($"> {comment.Name}: {comment.Text}");
        }
    }
}

// Comment: class
class Comment
{
    private string name;
    private string text;

    // Constructor: Set comment name and text
    public Comment(string name, string text)
    {
        this.name = name;
        this.text = text;
    }

    // Name Properties
    public string Name
    {
        get { return name; }
    }

    // Text Properties
    public string Text
    {
        get { return text; }
    }
}


