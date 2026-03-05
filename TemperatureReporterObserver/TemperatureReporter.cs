using System;
using System.Collections.Generic;

namespace TemperatureReporterObserver
{
    // Provider class - implements IObservable<T>
    public class TemperatureReporter : IObservable<TemperatureData>
    {
        private List<IObserver<TemperatureData>> observers;
        private string stationName;

        public TemperatureReporter(string name)
        {
            observers = new List<IObserver<TemperatureData>>();
            stationName = name;
        }

        // Subscribe method - returns IDisposable for unsubscription
        public IDisposable Subscribe(IObserver<TemperatureData> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                Console.WriteLine($"New observer subscribed to {stationName}. Total observers: {observers.Count}");
            }
            return new Unsubscriber(observers, observer);
        }

        // Method to report temperature to all observers
        public void ReportTemperature(int temperature, string location)
        {
            Console.WriteLine($"\n--- {stationName} reporting temperature ---");
            
            TemperatureData data = new TemperatureData
            {
                Temperature = temperature,
                Location = location,
                TimeRecorded = DateTime.Now
            };

            foreach (var observer in observers)
            {
                observer.OnNext(data);
            }
        }

        // Method to report an error
        public void ReportError(Exception error)
        {
            foreach (var observer in observers)
            {
                observer.OnError(error);
            }
        }

        // Method to signal completion
        public void EndTransmission()
        {
            Console.WriteLine($"\n--- {stationName} ending transmission ---");
            
            foreach (var observer in observers.ToArray())
            {
                observer.OnCompleted();
            }
            
            observers.Clear();
        }
    }
}