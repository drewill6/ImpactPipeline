namespace DataImpact.Models
{
    public class ProductsServicesModels
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Custom method to apply discount to the product price
        public decimal ApplyDiscount(decimal discountPercentage)
        {
            decimal discountAmount = Price * (discountPercentage / 100);
            return Price - discountAmount;
        }


    }
}
