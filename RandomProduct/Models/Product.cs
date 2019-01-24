namespace RandomProduct.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Cost { get; set; }

        public Product(string id, string name, int count, double cost)
        {
            Id = id;
            Name = name;
            Count = count;
            Cost = cost;
        }
    }
}
