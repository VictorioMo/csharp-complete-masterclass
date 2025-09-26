namespace TaskManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReportTask reportTask = new ReportTask() { ReportName = "Task Report" };
            EmailTask emailTask = new EmailTask() { Message = "Hello", Recipient="me" };

            var taskProcessor = new TaskProcessor<EmailTask, string>(emailTask);
            Console.WriteLine(taskProcessor.Execute());
            var taskProcessor1 = new TaskProcessor<ReportTask, string>(reportTask);
            Console.WriteLine(taskProcessor1.Execute());
        }
    }

    internal interface ITask<T>
    {
        public T Perform();
    }

    internal class EmailTask : ITask<string>
    {
        public string Recipient { get; set; }
        public string Message { get; set; }

        public string Perform()
        {
            return $"Sent to {Recipient}: {Message}";
        }
    }

    internal class ReportTask : ITask<string>
    {
        public string ReportName { get; set; }

        public string Perform()
        {
            return $"Report generated for {ReportName}";
        }
    }

    internal class TaskProcessor<TTask, TResult> where TTask : ITask<TResult>
    {
        public TTask Task { get; set; }

        public TaskProcessor(TTask task)
        {
            Task = task;
        }

        public TResult Execute()
        {
            return Task.Perform();
        }
    }
}
