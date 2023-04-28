using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Classes
{
    public class Supply
    {
        public int SupplyID { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime? ShippingDate { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime? ReceivingDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalSum { get; set; }
        public bool? IsReceived { get; set;}
        public string? Note { get; set; }
        public ICollection<Supply_Product> Supply_Products { get; set; }        
    }
}
