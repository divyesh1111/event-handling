using System;

namespace EventHandlerGenericDemo
{
    // Custom EventArgs class to hold event data
    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public int CurrentTotal { get; set; }
        public DateTime TimeReached { get; set; }
    }

    // Counter class that raises an event with data
    class Counter
    {
        private int threshold;
        private int total;

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        // Event declaration using EventHandler<TEventArgs> delegate (with data)
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;

        // Method to raise the event with data
        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            ThresholdReached?.Invoke(this, e);
        }

        public void Add(int x)
        {
            total += x;
            Console.WriteLine($"Added {x}. Total is now: {total}");

            if (total >= threshold)
            {
                // Create event args with data
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = threshold;
                args.CurrentTotal = total;
                args.TimeReached = DateTime.Now;

                OnThresholdReached(args);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EventHandler<TEventArgs> Delegate Demo (With Data) ===\n");

            // Create counter with threshold of 15
            Counter counter = new Counter(15);

            // Subscribe to the event
            counter.ThresholdReached += Counter_ThresholdReached;

            // Add numbers until threshold is reached
            Console.WriteLine("Adding numbers to counter...\n");
            counter.Add(5);
            counter.Add(6);
            counter.Add(7);  // This will trigger the event (total = 18)

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Event handler method - receives event data
        static void Counter_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("\n*** THRESHOLD REACHED! ***");
            Console.WriteLine($"Threshold Value: {e.Threshold}");
            Console.WriteLine($"Current Total: {e.CurrentTotal}");
            Console.WriteLine($"Time Reached: {e.TimeReached}");
        }
    }
}