using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Classes.Operations
{
    public class Supply_ProductPut : Supply_ProductPost
    {
        public int Supply_ProductID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ShippingDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ReceivingDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public bool? IsReceived { get; set; }
        public string? Note { get; set; }
    }
}
