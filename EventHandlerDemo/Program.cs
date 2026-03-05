using System;

namespace EventHandlerDemo
{
    // Counter class that raises an event when threshold is reached
    class Counter
    {
        private int threshold;
        private int total;

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        // Event declaration using EventHandler delegate (no data)
        public event EventHandler ThresholdReached;

        // Method to raise the event
        protected virtual void OnThresholdReached(EventArgs e)
        {
            ThresholdReached?.Invoke(this, e);
        }

        public void Add(int x)
        {
            total += x;
            Console.WriteLine($"Added {x}. Total is now: {total}");
            
            if (total >= threshold)
            {
                OnThresholdReached(EventArgs.Empty);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EventHandler Delegate Demo (Without Data) ===\n");

            // Create counter with threshold of 10
            Counter counter = new Counter(10);

            // Subscribe to the event
            counter.ThresholdReached += Counter_ThresholdReached;

            // Add numbers until threshold is reached
            Console.WriteLine("Adding numbers to counter...\n");
            counter.Add(3);
            counter.Add(4);
            counter.Add(5);  // This will trigger the event (total = 12)

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Event handler method
        static void Counter_ThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("\n*** THRESHOLD REACHED! ***");
            Console.WriteLine("The counter has exceeded the threshold value.");
        }
    }
}