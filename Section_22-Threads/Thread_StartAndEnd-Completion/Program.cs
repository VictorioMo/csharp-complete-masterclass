namespace Thread_StartAndEnd_Completion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            var thread = new Thread(() =>
            {
                Thread.Sleep(1000);
                taskCompletionSource.TrySetResult(true);
            });
            Console.WriteLine(thread.ManagedThreadId);
            thread.Start();

            /* Stops the current thread until the taskCompletionSource.Task is finished
             * very dangerous for real life applications as it can lead to dead-lock
             */
            var test = taskCompletionSource.Task.Result;

            // Generating 20 threads manually
            Enumerable.Range(0, 20).ToList().ForEach(x =>
            {
                var thread = new Thread(() =>
                {
                    Console.WriteLine($"Thread {x} finished.");
                });
                thread.Start();
            });

            Thread.Sleep(1000);
            Console.WriteLine(" === ");

            // Generating 20 threads via thread pools
            Enumerable.Range(0, 20).ToList().ForEach(x =>
            {
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    Console.WriteLine($"Thread {x} finished.");
                });
            });

            // This is required because the thread pool uses background threads
            // and the program may exit even if one or more of them were not executed yet
            Console.ReadKey();
        }
    }
}
