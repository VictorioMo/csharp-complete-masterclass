namespace DependencyInjectionApp
{
    public interface IToolUser
    {
        void SetHammer(Hammer hammer);
        void SetSaw(Saw saw);
    }

    public class Hammer
    {
        public void Use()
        {
            Console.WriteLine("Hammering Nails!");
        }
    }

    public class Saw
    {
        public void Use()
        {
            Console.WriteLine("Sawing wood!");
        }
    }

    public class Builder : IToolUser /* Interface dependency injection */
    {
        private Hammer _hammer;
        private Saw _saw;

        /* Property dependency injection */
        //public Hammer Hammer { get; set; }
        //public Saw Saw { get; set; }

        // Constructor dependency injection
        //public Builder(Hammer hammer, Saw saw)
        //{
        //    _hammer = hammer;
        //    _saw = saw;
        //}

        public void BuildHouse()
        {
            _saw.Use();
            _hammer.Use();
            Console.WriteLine("House built.");
        }

        public void SetHammer(Hammer hammer)
        {
            _hammer = hammer;
        }

        public void SetSaw(Saw saw)
        {
            _saw = saw;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Hammer hammer = new Hammer();
            Saw saw = new Saw();

            Builder builder = new Builder();/*(hammer, saw);*/
            builder.SetHammer(hammer);
            builder.SetSaw(saw);

            builder.BuildHouse();
            
        }
    }
}
