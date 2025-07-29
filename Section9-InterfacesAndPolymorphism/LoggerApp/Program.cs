namespace FilesApp
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            string directoryPath = @"D:\Logs";
            string filePath = Path.Combine(directoryPath, "log.txt");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            try
            {
                File.AppendAllText(filePath, message + "\n");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied. - {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured. - {ex.Message}");
            }
        }
    }

    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            // Implement the logic to log a message to database.
            Console.WriteLine($"Logging to database: {message}");
        }
    }

    public class Application
    {

        private ILogger _logger;
        public Application(ILogger logger)
        {
            _logger = logger;
        }

        public void DoWork()
        {
            _logger.Log("Work started");
            // do all the work
            _logger.Log("Done.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger fileLogger = new FileLogger();
            Application app = new Application(fileLogger);
            app.DoWork();

            ILogger dbLogger = new DatabaseLogger();
            app = new Application(dbLogger);
            app.DoWork();
            
        }
    }
}
