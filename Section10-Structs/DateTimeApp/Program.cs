namespace DateTimeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = new DateTime(2025, 09, 29);

            Console.WriteLine($"My date is: {dateTime}");

            // Write today time on screen
            Console.WriteLine(DateTime.Today);

            // Write current time on screen
            Console.WriteLine(DateTime.Now);

            Console.WriteLine("Tomorrow will be: {0}", GetTomorrow());
            Console.WriteLine("Today is {0}", DateTime.Today.DayOfWeek);

            int days = DateTime.DaysInMonth(2000, 2);
            Console.WriteLine($"Days in Feb 2000: {days}");

            days = DateTime.DaysInMonth(2001, 2);
            Console.WriteLine($"Days in Feb 2001: {days}");

            DateTime now = DateTime.Now;
            Console.WriteLine($"Minute: {now.Minute}");

            Console.WriteLine("Time is: {0} o'clock, {1} minutes and {2} seconds", now.Hour, now.Minute, now.Second);

            Console.WriteLine("Write date in this format: yyyy-mm-dd");
            string input = Console.ReadLine();
            if( DateTime.TryParse(input, out dateTime) )
            {
                Console.WriteLine(dateTime);
                TimeSpan daysPassed = now.Subtract(dateTime);
                Console.WriteLine("Days passed since: {0}", daysPassed.Days);
            }
            else
            {
                Console.WriteLine("Wrong input.");
            }


        }

        static DateTime GetTomorrow()
        {
            return DateTime.Today.AddDays(1);
        }
    }
}
