namespace Nullables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? age = null; // int? is a nullable int

            if (age.HasValue)
            {
                Console.WriteLine($"Age is {age.Value}");
            }
            else
            {
                //int sum = age.Value + 5; // will throw an error
                Console.WriteLine("Age is not specified.");
            }
        }
    }
}
