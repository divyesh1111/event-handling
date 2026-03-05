using System;
using System.Collections.Generic;

namespace TemperatureReporterObserver
{
    // Class to handle unsubscription
    public class Unsubscriber : IDisposable
    {
        private List<IObserver<TemperatureData>> _observers;
        private IObserver<TemperatureData> _observer;

        public Unsubscriber(List<IObserver<TemperatureData>> observers, IObserver<TemperatureData> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);
                Console.WriteLine("Observer has been unsubscribed.");
            }
        }
    }
}