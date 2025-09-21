using Newtonsoft.Json;
using System.Threading.Tasks;

namespace JSON_SerializationAndDeserialization
{
    public class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string[] Toys { get; set; }
    }

    public class Post
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            //string json = @"{ name : "Sif", age : 12 }";

            Dog dog = new Dog { Name = "Fluffy", Age = 2, Toys = [ "Plush", "Ball" ] };

            string doggoJSON = JsonConvert.SerializeObject(dog);

            Console.WriteLine(doggoJSON);

            string url = "https://my-json-server.typicode.com/typicode/demo/posts";

            HttpClient client = new HttpClient();

            try
            {
                var httpResponseMessage = await client.GetAsync(url);

                // Read content
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                Console.WriteLine(jsonResponse);

                // Deserealization
                var myPosts = JsonConvert.DeserializeObject<Post[]>(jsonResponse);

                foreach (var post in myPosts)
                {
                    Console.WriteLine($"{post.Id} {post.Title}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
