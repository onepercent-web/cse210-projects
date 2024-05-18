using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity
{
    private static readonly string[] Prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public void Start()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Reflection Activity.");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.Write("How long, in seconds, would you like for your session? ");
        int duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Get ready...");
        DisplayCountdown(3);

        Random random = new Random();
        int promptIndex = random.Next(Prompts.Length);
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n--- {Prompts[promptIndex]} ---");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine(); 

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            int questionIndex = random.Next(Questions.Length);
            Console.WriteLine($"\n> {Questions[questionIndex]}");
            DisplaySpinner(5); // スピナーアニメーションを表示して考える時間を与える
        }

        Console.WriteLine("\nWell done!!");
        DisplayCountdown(3);
    }

    private void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000); // 1秒待機
        }
        Console.WriteLine();
    }

    private void DisplaySpinner(int duration)
    {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int counter = 0;
        while (DateTime.Now < endTime)
        {
            switch (counter % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            counter++;
            Thread.Sleep(250); // 0.25秒待機
            Console.Write("\b"); // 1文字分戻る
        }
        Console.Write(" "); // 最後のスピナーを消す
        Console.Write("\b"); // スペースを消す
    }
}
