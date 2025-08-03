namespace LogHandler
{
    public delegate void LogHandler(string message);

    public class Logger
    {
        public void LogToConsole(string message)
        {
            Console.WriteLine("Console Log: " + message);
        }

        public void LogToFile(string message)
        {
            Console.WriteLine("File Log: " + message);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            LogHandler logHandler = logger.LogToConsole;

            //logHandler = logger.LogToFile;
            //logHandler("new log");

            // Delegate multicasting
            logHandler += logger.LogToFile;
            logHandler("new log");

            //logHandler -= logger.LogToFile;

            if (IsMethodInDelegate(logHandler, logger.LogToFile))
            {
                logHandler -= logger.LogToFile;
            }

            /* Warning because the delegate might be null 
             * (in our case we know it still has logger.LogToConsole in his invocation list) */
            //logHandler("new log after removing LogToFile");

            // Invoke safely with a method
            //InvokeSafely(logHandler, "new log after removing LogToFile");

            // Using InvocationList
            foreach (LogHandler handler in logHandler.GetInvocationList())
            {
                try
                {
                    handler("new log after removing LogToFile");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught: " + ex.ToString());
                }
            }

        }

        static void InvokeSafely(LogHandler logHandler, string message)
        {
            LogHandler temp = logHandler;
            if (temp != null)
            {
                temp(message);
            }
        }

        static bool IsMethodInDelegate(LogHandler logHandler, LogHandler method)
        {
            bool retVal = false;

            if (logHandler != null)
            {
                foreach (var d in logHandler.GetInvocationList())
                {
                    if (d == (Delegate)method)
                    {
                        retVal = true;
                    }
                }
            }

            return retVal;
        }
    }
}
