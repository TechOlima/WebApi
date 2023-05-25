using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Classes.Operations
{
    public class StoragePost
    { 
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? SalePrice { get; set; }        
        public int ProductID { get; set; }        
        public int? OrderID { get; set; }        
        public int? SupplyID { get; set; }
    }
}
