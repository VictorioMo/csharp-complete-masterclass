/* === Exercise description === */
/*
 * [..] write a method that will take two arguments: 
 * a list of integers nums and an integer SumToFind. 
 * And it returns the number of possible UNIQUE pares made from this list where the sum equals to SumToFind
 * 
 * Example:
 * 
 * SumOfTwo([1, 1, 1, 2, 3, 4, 5, 2], 2)
 * 
 * It should return: 1
 * 
 * Explanation: there is only one pair sum of witch is equal to 2 (1,1)
 * ATTENTION: The main trick of this exercise is that its time complexity should be linear. 
 * That means you should NOT have any double/triple loops inside or deep recursion.
 */
namespace SumOfTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPairs = SumOfTwo([1, 1, 1, 2, 3, 4, 5, 2], 2);

            Console.WriteLine(numberOfPairs);
        }

        public static int SumOfTwo(int[] nums, int SumToFind)
        {
            int numberOfPairs = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] + nums[i + 1] == SumToFind)
                {
                    numberOfPairs++;
                    i++;
                }
            }

            return numberOfPairs;
        }
    }
}
