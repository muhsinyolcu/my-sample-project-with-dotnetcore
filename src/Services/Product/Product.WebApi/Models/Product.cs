namespace Product.WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Unit { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
