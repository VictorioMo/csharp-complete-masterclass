namespace Linq1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            OddNumbers(numbers);
        }

        static void OddNumbers(int[] numbers)
        {
            Console.WriteLine("Odd numbers: ");

            IEnumerable<int> oddNumbers = from number in numbers where number % 2 != 0 select number;
            Console.WriteLine(oddNumbers);

            foreach (int odd in oddNumbers)
            {
                Console.Write($"{odd} ");
            }
        }
    }
}
