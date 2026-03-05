using System;
using System.Windows.Forms;

namespace EventPropertiesWinForm
{
    public partial class Form1 : Form
    {
        private EventPropertyClass eventPropertyClass;

        public Form1()
        {
            InitializeComponent();
            InitializeEventPropertyClass();
        }

        private void InitializeEventPropertyClass()
        {
            eventPropertyClass = new EventPropertyClass();

            // Subscribe to all events
            eventPropertyClass.Event1 += EventPropertyClass_Event1;
            eventPropertyClass.Event2 += EventPropertyClass_Event2;
            eventPropertyClass.Event3 += EventPropertyClass_Event3;

            lstOutput.Items.Add("Event Properties Demo initialized.");
            lstOutput.Items.Add("Subscribed to Event1, Event2, and Event3.");
            lstOutput.Items.Add("-----------------------------------");
        }

        // Event Handlers
        private void EventPropertyClass_Event1(object sender, EventArgs e)
        {
            lstOutput.Items.Add($"[{DateTime.Now:HH:mm:ss}] Event1 was raised and handled!");
        }

        private void EventPropertyClass_Event2(object sender, EventArgs e)
        {
            lstOutput.Items.Add($"[{DateTime.Now:HH:mm:ss}] Event2 was raised and handled!");
        }

        private void EventPropertyClass_Event3(object sender, EventArgs e)
        {
            lstOutput.Items.Add($"[{DateTime.Now:HH:mm:ss}] Event3 was raised and handled!");
        }

        // Button Click Handlers
        private void btnRaiseEvent1_Click(object sender, EventArgs e)
        {
            lstOutput.Items.Add("Button clicked: Raising Event1...");
            eventPropertyClass.RaiseEvent1();
        }

        private void btnRaiseEvent2_Click(object sender, EventArgs e)
        {
            lstOutput.Items.Add("Button clicked: Raising Event2...");
            eventPropertyClass.RaiseEvent2();
        }

        private void btnRaiseEvent3_Click(object sender, EventArgs e)
        {
            lstOutput.Items.Add("Button clicked: Raising Event3...");
            eventPropertyClass.RaiseEvent3();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstOutput.Items.Clear();
        }
    }
}