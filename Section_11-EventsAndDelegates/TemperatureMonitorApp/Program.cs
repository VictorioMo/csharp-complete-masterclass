namespace TemperatureMonitorApp
{
    //public delegate void TemperatureChangeHandler(string message);

    // The Event Args we want to use (actually created them)
    public class TemperatureChangeEventArgs : EventArgs
    {
        public int Temperature { get; }

        public TemperatureChangeEventArgs(int temperature)
        {
            Temperature = temperature;
        }
    }

    public class TemperatureMonitor
    {
        /* This is the event which is of type EventHandler, a generic delegate which accepts any type,
         * but for this specific purpose (events) it should be our defined EventArgs type */

        public event EventHandler<TemperatureChangeEventArgs> OnTemperatureChange;

        //public event TemperatureChangeHandler OnTemperatureChange;

        private int _temperature;

        public int Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                if (_temperature > 30)
                {
                    // Notify all subscribers about the temperature change above the 30 limit
                    InvokeOnTemperatureChangeEvent(new TemperatureChangeEventArgs(_temperature));
                }
                if (_temperature < 18)
                {
                    // Notify all subscribers about the temperature change below the 18 limit
                    InvokeOnTemperatureChangeEvent(new TemperatureChangeEventArgs(_temperature));
                }
            }
        }

        protected virtual void InvokeOnTemperatureChangeEvent(TemperatureChangeEventArgs e)
        {
            // This actually notifies all subscribers
            OnTemperatureChange?.Invoke(this, e);
        }

    }

    // Subscriber class (listeners)
    public class TemperatureAlert
    {
        public void OnTemperatureChange(object sender, TemperatureChangeEventArgs e)
        {
            Console.WriteLine($"Alert: Temperature is {e.Temperature}, sender is: {sender}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TemperatureMonitor monitor = new TemperatureMonitor();

            TemperatureAlert alert = new TemperatureAlert();
            monitor.OnTemperatureChange += alert.OnTemperatureChange;

            monitor.Temperature = 20;

            Random random = new Random();

            Console.WriteLine("Starting Temperature Monitor: Press any key to stop...");
            while (!Console.KeyAvailable)
            {
                monitor.Temperature = random.Next(15, 36);
                Console.WriteLine("Current Temperature: " + monitor.Temperature);
                Thread.Sleep(800);
            }

            Console.WriteLine("Monitoring stopped.");
            Console.ReadKey(true); // Consume the key
        }
    }
}
