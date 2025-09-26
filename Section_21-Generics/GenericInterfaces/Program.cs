namespace GenericInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // You can check the type and type1 data by running this in debug mode and putting a BP on those lines.
            Type type = typeof(Program);
            Type type1 = typeof(Repository<>);
        }
    }

    internal interface IEntity
    {
        int Id { get; }
    }

    internal interface IRepository<T> where T : IEntity
    {
        void Add(T entity);

        void Remove(T entity);
    }

    internal class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    internal class ProductRepository : IRepository<Product>
    {
        public void Add(Product entity)
        {
            
        }

        public void Remove(Product entity)
        {
            
        }
    }

    internal class Repository<T> : IRepository<T> where T: IEntity
    {
        public void Add(T entity)
        {
            if (entity.GetType() == typeof(Product))
            {
                // stuff
            }

            // other checks
        }

        public void Remove(T entity)
        {

        }
    }
}
