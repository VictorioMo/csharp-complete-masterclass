namespace QuickIntroGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = { 1, 2, 3, 4, 5 };
            string[] stringArray = { "One", "Two", "Three" };

            PrintIntArray(intArray);
            PrintStringArray(stringArray);

            PrintArray(intArray);
            PrintArray(stringArray);
        }

        public static void PrintIntArray(int[] array)
        {
            Console.Write("PrintIntArray:\n");
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n");
        }

        public static void PrintStringArray(string[] array)
        {
            Console.Write("PrintStringArray:\n");
            foreach (string item in array)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n");
        }

        // A generic method which accepts a generic type
        public static void PrintArray<T>(T[] array)
        {
            Console.Write("PrintArray:\n");
            foreach (T item in array)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n");
        }
    }
}
