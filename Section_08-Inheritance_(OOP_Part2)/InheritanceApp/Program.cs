namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();

            myDog.MakeSound();
            myDog.Eat();

            Console.ReadKey();
        }
    }

    class Animal
    {
        public void Eat() => Console.WriteLine("Eating..");

        public virtual void MakeSound() => Console.WriteLine("Animal makes generic sound.");
    }

    // Derived class (child class / subclass)
    // The class that inherits the members of the base class.
    class Dog: Animal
    {
        public override void MakeSound()
        {
            base.MakeSound();
            Console.WriteLine("Barking!");
        }
    }

    // Hierachical inheritance (multiple classes inherit from a base class) [Dog & Cat are Animal]
    class Cat: Animal
    {
        public override void MakeSound() => Console.WriteLine("Meowing!");
    }

    // Multi-level inheritance
    // (Collie is a breed of Dog)
    class Collie: Dog
    {
        public void GoNuts() => Console.WriteLine("Collie going Nuts!");
    }

    // Multiple inheritance: when a class inherits form multiple class
    // Directly unsupported in C# - used via interfaces, directly possible in C++.
}
