namespace ThreadIsAlive_Joining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread started.");

            Thread thread1 = new Thread(Thread1Func);
            Thread thread2 = new Thread(Thread2Func);

            thread1.Start();
            thread2.Start();

            // Will pause the main thread until the thread1 is finished.
            thread1.Join();
            // Will pause the main thread until the thread2 is finished or the specified time has passed.
            if (thread2.Join(1000))
            {
                Console.WriteLine("Thread 2 finished in specified time");
            }
            else
            {
                Console.WriteLine("Thread 2 was not finished in the specified amount of time.");
            }

            Console.WriteLine("Main thread ended.");
            Console.WriteLine(thread1.IsAlive); // True if the thread is still executing.
            Console.WriteLine(thread2.IsAlive); // False if the thread finished its execution.
        }

        static void Thread1Func()
        {
            Console.WriteLine("Thread 1 started.");
            Console.WriteLine("Thread 1 finished.");
        }

        static void Thread2Func()
        {
            Console.WriteLine("Thread 2 started.");
            Thread.Sleep(1200);
            Console.WriteLine("Thread 2 finished.");
        }


    }
}
