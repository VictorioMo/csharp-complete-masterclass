namespace MethodsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result; // This is a field (or instance variable), that means it is accesible everywhere inside Program class

            // Void function with no parameters
            void MyFirstMethod()
            {
                Console.WriteLine("This is inside of the method.");
            }

            // Calling a method
            MyFirstMethod();

            Console.WriteLine("This is outside of the method.");

            void WriteSomethingSpecific(string text)
            {
                Console.WriteLine($"The passed argument is: {text}");
            }

            WriteSomethingSpecific("Bober");

            int SumOfTwo(int num1, int num2)
            {
                int result = num1 + num2;
                return result;
            }

            Console.WriteLine("2 + 7 = {0}", SumOfTwo(2, 7));
            result = SumOfTwo(12, 46);
            Console.WriteLine("12 + 46 = {0}", result);

            Console.WriteLine("5 * 6 = {0}", ProductOfTwo(5, 6));

            Console.ReadKey();

        }

        static int ProductOfTwo(in int num1, in int num2)
        {
            int result = num1 * num2;
            return result;
        }
    }
}
