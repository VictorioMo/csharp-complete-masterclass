namespace ThreadingE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // You can see the current thread by accessing the Threads window in Debug Mode
            // Here the main thread is put to sleep for 1s after each message
            Console.WriteLine("Hello, World! 1");
            Thread.Sleep(1000);
            Console.WriteLine("Hello, World! 2");
            Thread.Sleep(1000);
            Console.WriteLine("Hello, World! 3");
            Thread.Sleep(1000);
            Console.WriteLine("Hello, World! 4");


            /* This will generate 4 threads running in parallel,
             * but which is finished first depends on the OS scheduling
             * each run of the program will generate a different outcome
             */
            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 1");
            }).Start();

            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 2");
            }).Start();

            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 3");
            }).Start();

            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 4");
            }).Start();
        }
    }
}
