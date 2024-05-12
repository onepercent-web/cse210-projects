using System;
using System.Collections.Generic;

public class Reference
{

    public string Book { get; set; }
    
    public int Chapter { get; set; }
    
    public int StartVerse { get; set; }
    
    public int EndVerse { get; set; }

    //Class of Reference 
   
    public Reference(string book, int chapter, int startVerse, int endVerse = -1)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }
}

// Class of Words to Handle
public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false; // Words are not initially hidden
    }
}

// Class of Bible Verses to Handle
public class Scripture
{
    public Reference Ref { get; set; }
    public List<Word> Words { get; set; }

    public Scripture(Reference reference, string scriptureText)
    {
        Ref = reference;
        Words = new List<Word>();
        // Split blank-separated text into words
        foreach (var word in scriptureText.Split(' '))
        {
            Words.Add(new Word(word));
        }
    }
}

// Class of Main Program       
class Program
{
    static void Main(string[] args)
    {
        // Display Mosiah 8:20
        Reference reference = new Reference("Mosiah", 8, 20);
        Scripture scripture = new Scripture(reference, "O how marvelous are the works of the Lord, and how long doth he suffer with his people; yea, and how blind and impenetrable are the understandings of the children of men; for they will not seek wisdom, neither do they desire that she should rule over them!");

        Random random = new Random();

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"{scripture.Ref.Book} {scripture.Ref.Chapter}:{scripture.Ref.StartVerse}-{scripture.Ref.EndVerse}");
            
            // Display hidden words
            // Hidden words are show with “_”
            foreach (var word in scripture.Words)
            {
                if (word.IsHidden)
                {
                    Console.Write("_____ ");
                }
                else
                {
                    Console.Write($"{word.Text} ");
                }
            }

            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();
            if (input == "quit")
            {
                break;
            }

            // Randomly hide words
            List<int> indices = new List<int>(); 
            for (int i = 0; i < scripture.Words.Count; i++)
            {
                if (!scripture.Words[i].IsHidden)
                {
                    indices.Add(i);
                }
            }

            if (indices.Count > 0)
            {
                int indexToHide = indices[random.Next(indices.Count)]; // Select the words random
                scripture.Words[indexToHide].IsHidden = true; // Hide the words
            }
            else
            {
                Console.WriteLine("All words are hidden!!");
                Console.ReadKey();
                break;
            }
        }
    }
}