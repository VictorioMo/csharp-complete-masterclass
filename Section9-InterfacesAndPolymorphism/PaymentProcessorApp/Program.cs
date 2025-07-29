namespace PaymentProcessorApp
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount}");
            // Credit card payment logic here
        }
    }

    public class PayPalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount}");
            // PayPal payment logic here
        }
    }

    public class PaymentService
    {
        private readonly IPaymentProcessor _processor;

        public PaymentService(IPaymentProcessor processor)
        {
            _processor = processor;
        }

        public void ProcessOrderPayment(decimal amount)
        {
            _processor.ProcessPayment(amount);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IPaymentProcessor creditCardProcessor = new CreditCardProcessor();
            PaymentService paymentService = new PaymentService(creditCardProcessor);
            paymentService.ProcessOrderPayment(100.00m);

            IPaymentProcessor payPalProcessor = new PayPalProcessor();
            paymentService = new PaymentService(payPalProcessor);
            paymentService.ProcessOrderPayment(200.00m);
        }
    }
}
