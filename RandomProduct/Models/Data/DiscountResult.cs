namespace RandomProduct.Models.Data
{
    public class DiscountResult
    {
        public int Percents { get; set; }
        public string ProductId { get; set; }

        public DiscountResult(int percents, string productId)
        {
            Percents = percents;
            ProductId = productId;
        }
    }
}
