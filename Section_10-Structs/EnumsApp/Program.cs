namespace EnumsApp
{
    enum Day { Mo, Tu, We, Th, Fr, Sa, Su};
    enum Month { Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec};

    internal class Program
    {
        static void Main(string[] args)
        {
            Day fr = Day.Fr;
            Day su = Day.Su;

            Day a = Day.Fr;

            Console.WriteLine(a == fr);

            Console.WriteLine(Day.Mo);
            Console.WriteLine((int)Day.Mo);

            Console.WriteLine(Month.Nov);
            Console.WriteLine((int)Month.Nov);
        }
    }
}
