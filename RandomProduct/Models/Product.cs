namespace RandomProduct.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }

        public Product(int id, string productId, string name, double cost)
        {
            Id = id;
            ProductId = productId;
            Name = name;
            Cost = cost;
        }
    }
}
