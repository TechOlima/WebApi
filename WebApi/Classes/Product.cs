using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Classes
{
    public class Product
    {
        public int ProductID { get; set; }
        public ProductType ProductType { get; set; }
        public MaterialType? MaterialType { get; set; }
        public string? Name { get; set; }
        public string? Equipment { get; set; }
        public string? VendorCode { get; set; }
        public int? Size { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? Gender { get; set; }
        public bool? Is_Deleted { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Insert> Inserts { get; set; }
    }
}
