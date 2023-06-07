using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Classes.Operations;

namespace WebApi.Classes
{
    public class Product
    {
        public int ProductID { get; set; }
        public ProductType? ProductType { get; set; }
        public MaterialType? MaterialType { get; set; }
        public string? Name { get; set; }
        public string? Equipment { get; set; }
        public string? VendorCode { get; set; }        
        public int? Amounth { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? SalePrice { get; set; }
        public int? Size { get; set; }        
        public string? Description { get; set; }
        public GenderType? GenderType { get; set; }
        public bool? Is_Deleted { get; set; }
        public int? VK_ID { get; set; }
        public ICollection<Photo>? Photos { get; set; }
        public ICollection<Insert>? Inserts { get; set; } 
        public Product()
        {

        }

        public Product(ProductPut productPut, DataContext _context)
        {            
            this.ProductID = productPut.ProductID;
            this.ProductType = _context.ProductType.FirstOrDefault(i => i.Name == productPut.ProductType);
            this.MaterialType = _context.MaterialType.FirstOrDefault(i => i.Name == productPut.MaterialType);
            this.Name = productPut.Name;
            this.Equipment = productPut.Equipment;
            this.VendorCode = productPut.VendorCode;
            this.Size = productPut.Size;
            this.Description = productPut.Description;
            this.GenderType = _context.GenderType.FirstOrDefault(i => i.Name == productPut.GenderType);
            this.Is_Deleted = productPut.Is_Deleted;
            this.VK_ID = productPut.VK_ID;
        }
        public Product(ProductPost productPost, DataContext _context)
        {            
            this.ProductType = _context.ProductType.FirstOrDefault(i => i.Name == productPost.ProductType);
            this.MaterialType = _context.MaterialType.FirstOrDefault(i => i.Name == productPost.MaterialType);
            this.Name = productPost.Name;
            this.Equipment = productPost.Equipment;
            this.VendorCode = productPost.VendorCode;
            this.Size = productPost.Size;
            this.Description = productPost.Description;
            this.GenderType = _context.GenderType.FirstOrDefault(i => i.Name == productPost.GenderType);            
        }
    }
}
