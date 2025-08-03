using System; // Importing the System namespace

namespace StockPriceAlertSystemApp
{
    // Define the delegate that will be used for the event
    public delegate void StockPriceChangedHandler(string message);

    // Define the Stock class which includes the event system
    public class Stock
    {
        public event StockPriceChangedHandler OnStockPriceChanged;

        private decimal _price;     // Private field to store the stock price
        private decimal _threshold; // Private field to store the threshold

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                if (_price < _threshold)
                {
                    RaiseStockPriceChangedEvent("Stock Alert: Stock price is below threshold!");
                }
            }
        }

        public decimal Threshold
        {
            get => _threshold;
            set => _threshold = value;
        }

        // Method to raise the stock price changed event
        protected virtual void RaiseStockPriceChangedEvent(string message)
        {
            OnStockPriceChanged?.Invoke(message);
        }
    }

    // Define the subscriber class which reacts to the event
    public class StockAlert
    {
        public void OnStockPriceChanged(string message)
        {
            Console.WriteLine(message);
        }
    }

    // Program class to simulate the stock price changes and test the event system
    internal class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            StockAlert alert = new StockAlert();

            stock.OnStockPriceChanged += alert.OnStockPriceChanged;

            stock.Threshold = 120m; // Set alert threshold

            // Simulate stock prices
            stock.Price = 150m;
            Thread.Sleep(500);
            stock.Price = 130m;
            Thread.Sleep(500);
            stock.Price = 110m;

            Console.ReadKey();
        }
    }
    

}
