/* === Exercise description === */
/*
 * [..] imagine you are in a kitchen that is full of cats. Every typical hungry cat will follow you if you hold some food, right?
 * Our goal is to count not hungry cats in the kitchen.
 * You with food in the kitchen will be marked as F
 * Every cat will be represented as ~O or O~ depending on the direction.
 * 
 * Examples:
 * 
 * Input: "~O~O~O~O F"
 * Return: 0(all cats follow you)
 * 
 * Input: "O~~O~O~O F O~O~"
 * Return: 1(one is not following)
 * [..]
 */
using System.Text.RegularExpressions;

namespace HungryCats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NotHungryCats("~O~O~O~O F"     ));
            Console.WriteLine(NotHungryCats("O~~O~O~O F O~O~"));
            Console.WriteLine(NotHungryCats("F ~OO~~O~O"     ));
            Console.WriteLine(NotHungryCats("F O~O~~O O~"    ));
        }

        public static int NotHungryCats(string kitchen)
        {
            // The number of cats which are not hungry (return value)
            int numberOfNotHungryCats = 0;

            // Regex patterns to identify the cats inside the string (dependent on orientation side)
            Regex findNotHungryCat_LeftSide  = new Regex("(O~)$+");
            Regex findNotHungryCat_RightSide = new Regex("(~O)$+");

            // Strings are separated in left path and right path
            string[] sidePaths = kitchen.Split("F", 2);

            // All spaces removed so only the cats are inside the strings (O~ or ~O)
            string sidePathLeft  = sidePaths[0].Trim().Replace(" ", String.Empty);
            string sidePathRight = sidePaths[1].Trim().Replace(" ", String.Empty);

            // For each cat at the end of the string, identify if it's hungry or not
            // Nevertheless, remove it from the string and repeat
            while (sidePathLeft != String.Empty)
            {
                // Left side path of the string here
                if (findNotHungryCat_LeftSide.IsMatch(sidePathLeft))
                {
                    numberOfNotHungryCats++;
                }

                sidePathLeft = sidePathLeft.Remove(sidePathLeft.Length - 2);
            }


            while (sidePathRight != String.Empty)
            {
                // Right side path of the string here
                if (findNotHungryCat_RightSide.IsMatch(sidePathRight))
                {
                    numberOfNotHungryCats++;
                }

                sidePathRight = sidePathRight.Remove(sidePathRight.Length - 2);
            }

            return numberOfNotHungryCats;
        }
    }
}