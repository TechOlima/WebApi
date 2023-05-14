namespace WebApi.Classes.Operations
{
    public class ProductPost
    {
        public string? Name { get; set; }
        public string? ProductType { get; set; }
        public string? MaterialType { get; set; }
        public string? Equipment { get; set; }
        public string? VendorCode { get; set; }
        public int? Size { get; set; }
        public string? Description { get; set; }
        public string? GenderType { get; set; }
        public bool? Is_Deleted { get; set; }        
    }
}
