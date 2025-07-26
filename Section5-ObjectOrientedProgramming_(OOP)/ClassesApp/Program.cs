namespace ClassesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Creating an object/instance of class Car
            //Car audi = new Car("A3", "Audi", false);
            //Car bmw = new Car("i7", "BMW", true);

            //Console.WriteLine("Please enter brand name.");
            //// Setting the brand
            //audi.Brand = Console.ReadLine();

            //// Getting the brand
            //Console.WriteLine($"You entered {audi.Brand}");

            //Console.WriteLine($"{bmw.Brand}");

            //Car audi2 = new Car("A3", "Audi", false);
            //audi2.Drive();

            //Car bmw2 = new Car("i7", "BMW", true);
            //bmw2.Drive();

            //Console.WriteLine("Number of cars = {0}", Car.NumberOfCars);

            //Customer earl = new Customer("Earl");
            //Customer frankTheTank = new Customer("FrankTheTank", "Main Street 1", "0113477");

            //Console.WriteLine($"Name of customer is: {earl.Name}");

            //Customer myCustomer = new Customer();

            //Console.WriteLine("Please write the customer's name:");
            //myCustomer.SetDetails("Frank", "Main Street 1", "0113477");

            //Console.WriteLine($"Details about customer: {myCustomer.Name}, {myCustomer.Adress}, {myCustomer.ContactNumber}");

            //myCustomer.SetDetails("Frank", "Main Street 1");

            //Console.WriteLine($"Details about customer: {myCustomer.Name}, {myCustomer.Adress}, {myCustomer.ContactNumber}");

            //Customer anotherCustomer = new Customer("Denis");
            //Console.WriteLine($"Details about customer: {anotherCustomer.Name}, {anotherCustomer.Adress}, {anotherCustomer.ContactNumber}");

            //// Both fields are part of the same class!
            //PartialClass partialClass = new PartialClass();
            //partialClass.Field1_1 = 1;
            //partialClass.Field1_2 = 2;
            //partialClass.DoSomething();


            //// Named parameters
            //Console.WriteLine(SubNum(10, 7));
            //Console.WriteLine(SubNum(num1: 10, num2: 7));
            //Console.WriteLine(SubNum(num2: 7, num1: 10));

            //Rectangle rectangle1 = new Rectangle();
            //rectangle1.Width = 7;
            //rectangle1.Height = 5;

            ////rectangle1.Area = 6; // This line won't compile, because it's only a getter property

            //Console.WriteLine($"Area of rectangle1 is {rectangle1.Area}");

            Customer customer1 = new Customer();
            Customer customer2 = new Customer("Danny");

            customer1.GetDetails();
            customer2.GetDetails();

            Console.ReadKey();
        }


        static int SubNum(int num1, int num2)
        {
            return (num1 - num2);
        }

    }
}
