using System.Diagnostics;
using System.Threading.Channels;

namespace TryCatchExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;

            try
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = 2;

                result = num2 / num1;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Division by 0, really? - " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Enter only numbers, big boy - " + ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Number's too big to handle, please be more gentle - " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // This line is executed only during debugging!
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("This will be always executed!");
            }

            Console.WriteLine("Result = " + result);

            Console.WriteLine("Enter your age");
            GetUserAge(Console.ReadLine());

            Console.ReadKey();
        }

        static int GetUserAge(string input)
        {
            int age;
            if (!int.TryParse(input, out age))
            {
                throw new Exception("You did not enter a valid age.");
            }
            else if (age < 0 || age > 120)
            {
                throw new Exception("Your age cannot be below 0 or above 120.");
            }
            return age;
        }
    }
}
