namespace RandomProduct.Models.Data
{
    public class DiscountData
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public int DiscountCondition { get; set; }
        public DiscountResult DiscountResult { get; set; }

        public DiscountData(string productId, string discountName, int discountCondition, DiscountResult discountResult)
        {
            ProductId = productId;
            Name = discountName;
            DiscountCondition = discountCondition;
            DiscountResult = discountResult;
        }
    }
}
