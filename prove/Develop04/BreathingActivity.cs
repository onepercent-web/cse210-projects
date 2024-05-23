using System;
using System.Threading;

namespace MindfulnessApp
{
    public class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity()
        {
            Name = "Breathing";
            Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        protected override void ExecuteActivity()
        {
            int halfDuration = Duration / 2;
            for (int i = 0; i < halfDuration; i++)
            {
                Console.WriteLine("Breathe in...");
                ShowCountdown(5);
                Console.WriteLine("Breathe out...");
                ShowCountdown(5);
            }
        }
    }
}
