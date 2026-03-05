using System;

namespace TemperatureReporterObserver
{
    // Observer class - implements IObserver<T>
    public class TemperatureObserver : IObserver<TemperatureData>
    {
        private string observerName;
        private IDisposable unsubscriber;

        public TemperatureObserver(string name)
        {
            observerName = name;
        }

        // Method to subscribe to a provider
        public void Subscribe(IObservable<TemperatureData> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        // Method to unsubscribe
        public void Unsubscribe()
        {
            Console.WriteLine($"\n{observerName} is unsubscribing...");
            unsubscriber?.Dispose();
        }

        // Called when new data is available
        public void OnNext(TemperatureData value)
        {
            Console.WriteLine($"  [{observerName}] Received update:");
            Console.WriteLine($"    Location: {value.Location}");
            Console.WriteLine($"    Temperature: {value.Temperature}°C");
            Console.WriteLine($"    Time: {value.TimeRecorded:HH:mm:ss}");
            
            // Add temperature status
            if (value.Temperature > 35)
                Console.WriteLine($"    Status: HOT! Stay hydrated!");
            else if (value.Temperature < 10)
                Console.WriteLine($"    Status: COLD! Dress warmly!");
            else
                Console.WriteLine($"    Status: Pleasant temperature.");
        }

        // Called when an error occurs
        public void OnError(Exception error)
        {
            Console.WriteLine($"  [{observerName}] Error: {error.Message}");
        }

        // Called when the provider has finished sending data
        public void OnCompleted()
        {
            Console.WriteLine($"  [{observerName}] Transmission completed. No more data.");
        }
    }
}