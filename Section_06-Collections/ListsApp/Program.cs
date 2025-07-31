using System.Drawing;

namespace ListsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring and initalizing a list
            List<string> colors = ["red", "blue", "green", "red"];

            colors.Add("yellow");

            PrintList(colors);
            bool isDeleted = true;
            while (isDeleted)
            {
                isDeleted = colors.Remove("red");
            }
            PrintList(colors);

            List<int> numbers = new List<int> { 10, 5, 15, 3, 9, 25, 18 };

            PrintList(numbers);
            numbers.Sort();
            PrintList(numbers);

            // Define a predicate if the number is greater than 10
            Predicate<int> isGreaterThanTen = x => x > 10;

            //List<int> higherEqualTen = numbers.FindAll(x => x >= 10);
            List<int> higherTen = numbers.FindAll(isGreaterThanTen);
            PrintList(higherTen);

            Console.WriteLine($"{numbers.Any(x => x > 10)}");

        }

        static void PrintList<T>(List<T> list)
        {
            Console.WriteLine("Current elements in the list:");
            foreach (T element in list)
            {
                Console.Write($"{element} ");
            }
            Console.Write("\n");
        }

    }
}
