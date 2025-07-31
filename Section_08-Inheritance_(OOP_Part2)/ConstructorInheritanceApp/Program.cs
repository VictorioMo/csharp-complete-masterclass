namespace ConstructorInheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee joe = new Employee("Joe", 36, "Sales Rep", 12342);
            //joe.DisplayEmployeeInfo();

            Manager carl = new Manager("Carl", 45, "Manager", 143427, 7);
            carl.DisplayManagerInfo();
        }
    }

    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        // Base class constructor
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("Person constructor called.");
        }

        public void DisplayPersonInfo()
        {
            Console.WriteLine($"Name: {Name}, age: {Age}");
        }
    }

    public class Employee: Person
    {
        public string JobTitle { get; private set; }
        public int EmployeeID { get; private set; }

        // Derived class constructor
        public Employee(string name, int age, string jobTitle, int employeeID) 
            : base(name, age) /* this calls the base class constructor */
        {
            JobTitle = jobTitle;
            EmployeeID = employeeID;
            Console.WriteLine("Employee constructor called.");
        }
        public void DisplayEmployeeInfo()
        {
            DisplayPersonInfo();
            Console.WriteLine($"Job Title: {JobTitle}, ID: {EmployeeID}");
        }
    }

    public sealed class Manager : Employee
    {
        public int TeamSize { get; private set; }
        public Manager(string name, int age, string jobTitle, int employeeID, int teamSize) 
            : base(name, age, jobTitle, employeeID)
        {
            TeamSize = teamSize;
        }

        /* XML documentation */
        /// <summary>Displays the information about a manager on the console.</summary>
        /// <returns>void</returns>
        public void DisplayManagerInfo()
        {
            DisplayEmployeeInfo();
            Console.WriteLine($"Team size: {TeamSize}");
        }
    }
}
