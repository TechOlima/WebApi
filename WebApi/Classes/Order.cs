using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Classes
{
    public class Order
    {
        public int OrderID { get; set; }
        public string? ClientName { get; set; }
        public string? ClientPhone { get; set; }
        public string? ClientEmail { get; set; }
        public State State { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalSum { get; set; }
        public string DeliveryAddress { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeliveryDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? OrderDate { get; set; }
        public string? Note { get; set; }
        public ICollection<Storage> Storages { get; set; }        
    }
}
