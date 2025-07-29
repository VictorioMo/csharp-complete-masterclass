namespace InterfacesApp
{
    public interface IAnimal
    {
        void MakeSound();
        void Eat(string food);
    }

    public class Dog : IAnimal
    {
        public void Eat(string food)
        {
            Console.WriteLine($"Dog ate {food}");
        }

        public void MakeSound()
        {
            Console.WriteLine("Woof");
        }
    }

    public class Cat : IAnimal
    {
        public void Eat(string food)
        {
            Console.WriteLine($"Cat ate {food}");
        }

        public void MakeSound()
        {
            Console.WriteLine("Meow~");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.MakeSound();
            dog.Eat("treat");

            Cat cat = new Cat();
            cat.MakeSound();
            cat.Eat("fish");

            // Polymorphism
            IAnimal animal = new Dog();
            animal.MakeSound(); // Woof

            Console.ReadKey();
        }
    }
}
