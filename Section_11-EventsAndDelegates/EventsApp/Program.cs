namespace EventsApp
{
    public delegate void Notify(string message);

    public class EventPublisher
    {
        /* The On prefix makes it clear that the method 
         * is associated with an event.
         * It signifies that the method is not just a regular method but
         * one that is called when a specific event occurs.
         */
        public event Notify OnNotify;

        public void RaiseEvent(string message)
        {
            OnNotify?.Invoke(message); // Invoke the event if there are any subscribers/listeners
        }
    }

    public class EventSubscriber
    {
        public void OnEventRaised(string message)
        {
            Console.WriteLine("Event recieved: " + message);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            EventPublisher publisher = new EventPublisher();
            EventSubscriber subscriber = new EventSubscriber(); // More subscribers can exist.

            publisher.OnNotify += subscriber.OnEventRaised;

            publisher.RaiseEvent("test");

            EventSubscriber subscriber2 = new EventSubscriber();

            publisher.OnNotify += subscriber2.OnEventRaised;

            publisher.RaiseEvent("test 2");
        }
    }
}
