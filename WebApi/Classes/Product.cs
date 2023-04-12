namespace WebApi.Classes
{
    public class Product
    {
        public int ProductID { get; set; }
        public ProductType ProductType { get; set; }
        public MaterialType? MaterialType { get; set; }
        public string? Name { get; set; }
        public string? Equipment { get; set; }
    }
}
