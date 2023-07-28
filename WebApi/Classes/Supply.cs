using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Classes.Operations;

namespace WebApi.Classes
{
    public class Supply
    {
        public int SupplyID { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime? ShippingDate { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime? ReceivingDate { get; set; }        
        public bool? IsReceived { get; set;}
        public string? Note { get; set; }
        public ICollection<Supply_Product>? SupplyProducts { get; set; }

        public Supply()
        {

        }

        public Supply(SupplyPut supplyPut)
        {
            this.SupplyID = supplyPut.SupplyID;
            this.ShippingDate = supplyPut.ShippingDate;
            this.ReceivingDate = supplyPut.ReceivingDate;            
            this.IsReceived = supplyPut.IsReceived;
            this.Note = supplyPut.Note;
        }

        public Supply(SupplyPost supplyPost)
        {
            this.ShippingDate = supplyPost.ShippingDate;
            this.ReceivingDate = supplyPost.ReceivingDate;            
            this.IsReceived = supplyPost.IsReceived;
            this.Note = supplyPost.Note;
            this.SupplyProducts = supplyPost.SupplyProducts.Select(i => new Supply_Product(i)).ToList();
        }
    }
}
