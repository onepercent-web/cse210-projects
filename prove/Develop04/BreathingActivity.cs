using System;  //Declaration for use basic C# functions
using System.Threading; //Declaration of function to pause the program

public class BreathingActivity
{
    public void Start()
    {
        Console.Clear(); // Clear the console screen
        Console.WriteLine("Welcome to the Breathing Activity.");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.Write("How long, in seconds, would you like for your session? ");
        int duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Get ready..."); // Display ready message
        Thread.Sleep(3000); // 3 seconds preparation time

        for (int i = 0; i < duration / 6; i++) // 6 seconds for each cycle (3 seconds for inhale + 3 seconds for exhale)
        {
            Console.WriteLine("Breathe in..."); 
            DisplayCountdown(3); // 3 seconds to display
            Console.WriteLine("Now breathe out...");
            DisplayCountdown(3); //Display 3 second countdown
        }

        Console.WriteLine("Well done!!"); //display end message
        Thread.Sleep(3000); // 3 seconds to display
    }

    private void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000); // 1 seconds preparation time
        }
        Console.WriteLine();
    }
}
