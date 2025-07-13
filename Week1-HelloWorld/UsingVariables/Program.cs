namespace UsingVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // declare a string type variable
            string myFriendsName;

            // assign value to the myFriendsName variable
            myFriendsName = "Jonathan";

            // use/access the variable
            Console.WriteLine(myFriendsName);

            // assign new value to the myFriendsName variable
            myFriendsName = "Joseph";

            // use/access the variable
            Console.WriteLine(myFriendsName);

            // declare a string type variable with initializer
            string myFriendsName2 = "Jotaro";

            Console.WriteLine($"My friend is {myFriendsName2}");

            int myNumber = 10;
            Console.WriteLine(myNumber);

            float anotherNumber_f = 14.2f;
            Console.WriteLine(anotherNumber_f);
        }
    }
}
