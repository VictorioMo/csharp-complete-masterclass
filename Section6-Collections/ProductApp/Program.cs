using System.Drawing;

namespace ListsApp
{
    internal class Program
    {
        public class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }

        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Apple", Price = 0.80 },
                new Product { Name = "Banana", Price = 0.30 },
                new Product { Name = "Cherry", Price = 3.80 }
            };

            products.Add(new Product { Name = "Berries", Price = 2.99 });

            Console.WriteLine("Available products:");
            foreach (Product product in products)
            {
                Console.WriteLine($"{product.Name} at {product.Price} each.");
            }

            List<Product> cheapProducts = products.Where(p => p.Price < 1.0).ToList();
            Console.WriteLine("Cheap products:");
            foreach (Product product in cheapProducts)
            {
                Console.WriteLine($"{product.Name} at {product.Price} each.");
            }
        }

        static void PrintList<T>(List<T> list)
        {
            Console.WriteLine("Current elements in the list:");
            foreach (T element in list)
            {
                Console.Write($"{element} ");
            }
            Console.Write("\n");
        }

    }
}
