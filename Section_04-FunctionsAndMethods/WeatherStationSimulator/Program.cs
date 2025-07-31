namespace WeatherStationSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of days to simulate:");
            int days = int.Parse(Console.ReadLine());

            int[] temperatures = new int[days];
            string[] availableConditions = { "Sunny", "Rainy", "Cloudy", "Snowy" };
            string[] weatherConditions = new string[days];

            Random random = new Random();

            for (int i = 0; i < days; i++)
            {
                temperatures[i] = random.Next(-10, 40);
                weatherConditions[i] = availableConditions[random.Next(availableConditions.Length)];
            }

            //double avgTemperature = AverageTemperature(temperatures);

            Console.WriteLine($"Average temperature: {AverageTemperature(temperatures)}");
            Console.WriteLine($"Maximum temperature: {temperatures.Max()}");
            Console.WriteLine($"Minimum temperature: {temperatures.Min()}");
            Console.WriteLine($"Most common condition: {MostCommonCondition(weatherConditions)}");

            Console.ReadKey();
        }

        static string MostCommonCondition(in string[] weatherConditions)
        {
            int count = 1;
            string mostCommonCondition = weatherConditions[0];

            for (int i = 0; i < weatherConditions.Length; i++)
            {
                int tempCount = 0;
                for (int j = 0; j < weatherConditions.Length; j++)
                {
                    if (weatherConditions[i] == weatherConditions[j])
                    {
                        tempCount++;
                    }
                }

                if (tempCount > count)
                {
                    count = tempCount;
                    mostCommonCondition = weatherConditions[i];
                }
            }

            return mostCommonCondition;
        }

        static double AverageTemperature(in int[] temperatures)
        {
            double result = 0;

            for (int i = 0; i < temperatures.Length; i++)
            {
                result += temperatures[i];
            }
            result /= temperatures.Length;

            return result;
        }
    }
}
