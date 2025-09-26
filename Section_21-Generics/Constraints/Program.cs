namespace Constraints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Box<int> boxInt = new Box<int>(); - this won't compile, due to Box class type constraint
            Box<Book> boxBook = new Box<Book>();

            /* The below line wont compile because type Book has not the IEntity interface implemented.
             * Repository<Book> repositoryOfBook = new Repository<Book>(); 
             */

            Repository<Product> repository = new Repository<Product>();
            var product = new Product();
            repository.Add(product);

            /* Comparer.AreEqual(1, 1); - wont compile due to constraint */
            var product2 = new Product();
            Comparer.AreEqual(product, product2);
        }
    }

    public class Book
    {
        
    }

    public class Product : IEntity
    {
        public int Id { get; }
    }
}
