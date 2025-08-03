namespace TemperatureMonitorApp
{
    public delegate void TemperatureChangeHandler(string message);

    public class TemperatureMonitor
    {
        public event TemperatureChangeHandler OnTemperatureChange;

        private int _temperature;

        public int Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                if (_temperature > 30)
                {
                    RaiseOnTemperatureChangeEvent("The temperature is above 30!");
                }
                if (_temperature < 18)
                {
                    RaiseOnTemperatureChangeEvent("The temperature is below 18!");
                }
            }
        }

        protected virtual void RaiseOnTemperatureChangeEvent(string message)
        {
            OnTemperatureChange?.Invoke(message);
        }

    }

    public class TemperatureAlert
    {
        public void OnTemperatureChange(string message)
        {
            Console.WriteLine("Alert: " + message);
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
