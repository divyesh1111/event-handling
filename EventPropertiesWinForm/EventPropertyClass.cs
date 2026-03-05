using System;
using System.ComponentModel;

namespace EventPropertiesWinForm
{
    // Class demonstrating Event Properties
    public class EventPropertyClass
    {
        // EventHandlerList to store event delegates (memory efficient)
        private EventHandlerList eventList = new EventHandlerList();

        // Keys for events
        private static readonly object Event1Key = new object();
        private static readonly object Event2Key = new object();
        private static readonly object Event3Key = new object();

        // Event Property 1
        public event EventHandler Event1
        {
            add { eventList.AddHandler(Event1Key, value); }
            remove { eventList.RemoveHandler(Event1Key, value); }
        }

        // Event Property 2
        public event EventHandler Event2
        {
            add { eventList.AddHandler(Event2Key, value); }
            remove { eventList.RemoveHandler(Event2Key, value); }
        }

        // Event Property 3
        public event EventHandler Event3
        {
            add { eventList.AddHandler(Event3Key, value); }
            remove { eventList.RemoveHandler(Event3Key, value); }
        }

        // Methods to raise events
        public void RaiseEvent1()
        {
            EventHandler handler = (EventHandler)eventList[Event1Key];
            handler?.Invoke(this, EventArgs.Empty);
        }

        public void RaiseEvent2()
        {
            EventHandler handler = (EventHandler)eventList[Event2Key];
            handler?.Invoke(this, EventArgs.Empty);
        }

        public void RaiseEvent3()
        {
            EventHandler handler = (EventHandler)eventList[Event3Key];
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}