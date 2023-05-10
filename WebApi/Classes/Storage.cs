using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Classes
{
    public class Storage
    {
        public int StorageID { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? SalePrice { get; set; }        
        public Product Product { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? PurchaseDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? SaleDate { get; set; }
        public Order? Order { get; set; }
        public Supply? Supply { get; set; }
    }
}
