namespace MultipleInheritanceApp
{
    public interface IPrintable
    {
        void Print();
    }

    public interface IScannable
    {
        void Scan();
    }

    public class MultiFunctionPrinter : IPrintable, IScannable
    {
        public void Print()
        {
            Console.WriteLine("Printing document.");
        }

        public void Scan()
        {
            Console.WriteLine("Scanning document.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MultiFunctionPrinter printer = new MultiFunctionPrinter();

            printer.Scan();
            printer.Print();

        }
    }
}
