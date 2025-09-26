namespace GenericDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Action generic delegate -> actions do not return values, hence the name of them.
            Action action = () => { Console.WriteLine("Heeey"); };

            action();

            Action<int> numPrint = (x) => Console.WriteLine(x);

            numPrint(21);

            Action<double, double, double> sumOfThree = (x, y, z) => Console.WriteLine(x + y + z);

            sumOfThree(3, 4, 5);
            Console.WriteLine();

            // Func generic delegate -> returns a generic value
            Func<string> getName = () => "Victorio";
            Console.WriteLine(getName());

            Func<int, int, int> sumOfTwo = (x, y) => x + y;
            Console.WriteLine(sumOfTwo(5,9));
            Console.WriteLine();

            // Predicate generic delegate -> returns a bool
            Predicate<int> IsEven = (x) => x % 2 == 0;
            Console.WriteLine(IsEven(7));

            List<int> listOfInt = new List<int>() {1,2,3,4,5,6,7,8,9 };

            var evenInts = listOfInt.FindAll(IsEven);
            foreach (int i in evenInts)
            {
                Console.Write(i + " ");
            }
        }
    }
}
