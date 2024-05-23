using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    public abstract class MindfulnessActivity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"Starting {Name} Activity");
            Console.WriteLine(Description);
            Console.Write("Enter duration in seconds: ");
            Duration = int.Parse(Console.ReadLine());

            Console.WriteLine("Prepare to begin...");
            ShowSpinner(3);

            ExecuteActivity();

            Console.WriteLine("Good job!");
            Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
            ShowSpinner(3);
        }

        protected abstract void ExecuteActivity();

        protected void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write("/");
                Thread.Sleep(250);
                Console.Write("\b-");
                Thread.Sleep(250);
                Console.Write("\b\\");
                Thread.Sleep(250);
                Console.Write("\b|");
                Thread.Sleep(250);
                Console.Write("\b");
            }
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}
