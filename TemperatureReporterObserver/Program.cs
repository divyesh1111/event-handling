using System;

namespace TemperatureReporterObserver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("╔════════════════════════════════════════════════════╗");
            // Console.WriteLine("║     TEMPERATURE REPORTER - OBSERVER PATTERN        ║");
            // Console.WriteLine("╚════════════════════════════════════════════════════╝\n");

            // Create the temperature provider (Observable)
            TemperatureReporter weatherStation = new TemperatureReporter("City Weather Station");

            // Create observers
            Console.WriteLine("Creating observers...\n");
            TemperatureObserver observer1 = new TemperatureObserver("Weather App");
            TemperatureObserver observer2 = new TemperatureObserver("News Channel");
            TemperatureObserver observer3 = new TemperatureObserver("Airport Display");

            // Subscribe observers to the provider
            Console.WriteLine("Subscribing observers to weather station...\n");
            observer1.Subscribe(weatherStation);
            observer2.Subscribe(weatherStation);
            observer3.Subscribe(weatherStation);

            // Report temperatures - all observers receive updates
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("FIRST TEMPERATURE REPORT");
            Console.WriteLine(new string('=', 50));
            weatherStation.ReportTemperature(25, "Downtown");

            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("SECOND TEMPERATURE REPORT");
            Console.WriteLine(new string('=', 50));
            weatherStation.ReportTemperature(38, "City Center");

            // Unsubscribe one observer
            observer1.Unsubscribe();

            // Report again - only remaining observers receive update
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("THIRD TEMPERATURE REPORT (After Weather App unsubscribed)");
            Console.WriteLine(new string('=', 50));
            weatherStation.ReportTemperature(5, "Northern District");

            // Unsubscribe another observer
            observer2.Unsubscribe();

            // Report again - only one observer receives update
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("FOURTH TEMPERATURE REPORT (Only Airport Display subscribed)");
            Console.WriteLine(new string('=', 50));
            weatherStation.ReportTemperature(22, "Airport Area");

            // End transmission - signals completion to all remaining observers
            weatherStation.EndTransmission();

            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("DEMONSTRATION COMPLETE");
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}