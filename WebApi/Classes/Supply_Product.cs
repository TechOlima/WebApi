using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Classes
{
    public class Supply_Product
    {
        public int Supply_ProductID { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public int Quantity { get; set; }
        public Supply Supply { get; set; }
        public Product Product { get; set; }
    }
}
