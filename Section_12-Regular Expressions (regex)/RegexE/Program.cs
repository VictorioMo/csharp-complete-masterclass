using System.Text.RegularExpressions;

namespace RegexE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\d{4})-(\d{3})";
            Regex regex = new Regex(pattern);

            string text = "Hi, here is my number: 8172-638";

            MatchCollection matches = regex.Matches(text);

            Console.WriteLine("Search count: {0}", matches.Count);

            foreach (Match match in matches)
            {
                GroupCollection group = match.Groups;

                for (int i = 0; i < group.Count; i++)
                {
                    Console.WriteLine("{0} found at {1}", group[i].Value, group[i].Index);
                }
                //Console.WriteLine("{0} found at {1}", group[0].Value, group[0].Index);
                //Console.WriteLine("{0} found at {1}", group[1].Value, group[1].Index);
                //Console.WriteLine("{0} found at {1}", group[2].Value, group[2].Index);

            }
        }
    }
}
