namespace RandomProduct.Models.Data
{
    public class DiscountResult
    {
        public double Percents { get; set; }
        public string ProductId { get; set; }

        public DiscountResult(double percents, string productId)
        {
            Percents = percents;
            ProductId = productId;
        }
    }
}
