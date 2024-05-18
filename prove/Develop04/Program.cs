using System;  //Declaration for use basic C# functions
using System.Threading; //Declaration of function to pause the program

class Program
{
    static void Main(string[] args)
    {
        while (true) // loop. Continues until the user finish the program.
        {
            Console.Clear(); // Clear the console screen
            // Display menu options
            Console.WriteLine("Menu Options:"); 
            // Display options for each activity
            Console.WriteLine("1. Start breathing activity"); 
            Console.WriteLine("2. Start reflecting activity"); 
            Console.WriteLine("3. Start listing activity"); 
            Console.WriteLine("4. Quit"); 
            Console.Write("Select a choice from the menu: "); 
            
            string choice = Console.ReadLine(); // read user answer

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Start();  // start the BreathingActivity
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Start(); // Start the ReflectionActivity
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Start();  // Start the ListingActivity
                    break;
                case "4":
                    return; // end the program
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(1000); // 1 seconds preparation time
                    break;
            }
        }
    }
}
