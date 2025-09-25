namespace IntroGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<int> boxOfInt = new Box<int>(1);
            Console.WriteLine(boxOfInt.Log());

            Box<string> boxOfString = new Box<string>("Hello");
            Console.WriteLine(boxOfString.Log());

            boxOfString.UpdateContent("Generics are cool!");
            Console.WriteLine(boxOfString.GetContent());

            SmartBox<int, string> smartbox = new SmartBox<int, string>(100, "One Hundred");
            smartbox.Display();

            Logger logger = new Logger(); // Class is not generic, hence it does not require a type.
            logger.Log<int>(10);
            logger.Log(4);
            logger.Log<string>("Hello");
            logger.Log("Hello there");

            logger.Log(new { Name = "John", Age = 30 });
        }
    }
}
