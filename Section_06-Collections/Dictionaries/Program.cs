namespace Dictionaries
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

        public Employee(string name, int age, int salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // key - value
            // key is unique

            Dictionary<int, string> employees = new Dictionary<int, string>();

            employees.Add(101, "John Doe");
            employees.Add(102, "Bob Smith");
            employees.Add(103, "Dani Jhonson");
            employees.Add(104, "Eduard Davidson");
            employees.Add(105, "Laura Victoriano");

            string name = employees[101];
            Console.WriteLine(name);

            // update data in a dictionary
            employees[102] = "Jane Smith";

            // remove item from dictionary
            employees.Remove(101);

            // Check if a key already exists
            if (!employees.ContainsKey(104))
            {
                employees.Add(104, "Mike Jike");
            }

            bool added = employees.TryAdd(102, "Bob Knob");

            if (added)
            {
                Console.WriteLine("Bob Knob was added.");
            }
            else
            {
                Console.WriteLine("Could not add the employee at key 102");
            }

            // Iterating over a dictionary
            foreach (KeyValuePair<int, string> employee in employees)
            {
                Console.WriteLine($"ID: {employee.Key}, Name: {employee.Value}");
            }


            // Using dictionary with objects as values

            Dictionary<int, Employee> office = new Dictionary<int, Employee>();
            office.Add(1, new Employee("John Doe",         35, 100000));
            office.Add(2, new Employee("Bob Smith",        24, 40000 ));
            office.Add(3, new Employee("Dani Jhonson",     39, 80000 ));
            office.Add(4, new Employee("Eduard Davidson",  45, 150000));
            office.Add(5, new Employee("Laura Victoriano", 32, 90000 ));

            foreach (var employee in office)
            {
                Console.WriteLine($"ID: {employee.Key}, named: {employee.Value.Name}" +
                    $" earns {employee.Value.Salary}" +
                    $" and is {employee.Value.Age} years old.");
            }

            
            // Dictionary with string keys and List<int> as values
            Dictionary<string, List<int>> myDictionary = new Dictionary<string, List<int>>
            {
                {"List", new List<int>{1, 2, 3}}
            };
            
            foreach (var component in myDictionary)
            {
                foreach (int number in component.Value)
                {
                    Console.Write($"{number} ");
                }
                Console.Write("\n");
            }

            var codes = new Dictionary<string, string> 
            {
                ["NY"] = "New York",
                ["CA"] = "California",
                ["TX"] = "Texas"
            };

            string state;

            if(codes.TryGetValue("NY", out state))
            {
                Console.WriteLine(state);
            }

            foreach (var code in codes)
            {
                Console.WriteLine($"State code for {code.Value} is {code.Key}");
            }

        }
    }
}
