namespace EventsAndDelegates
{
    // Can also be declared outside of an class,
    // recommended if the delegate isn't close related to the functionality

    //public delegate void Notify(string message);

    internal class Program
    {
        // 1. Declaration
        public delegate void Notify(string message);

        static void Main(string[] args)
        {
            // Delegates define a method signature,
            // and any method assigned to a delegate must match this signature.

            // 2. Instantination
            Notify notifyDelegate = ShowMessage;
            //Notify notifyDelegate = new Notify(notifyDelegate); this also works - old school

            // 3. Invocation
            notifyDelegate("Hello, a delegate was used!");
        }

        static void ShowMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
