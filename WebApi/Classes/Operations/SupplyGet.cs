namespace WebApi.Classes.Operations
{
    public class SupplyGet : SupplyPut
    {
        public int? ProductCount { get; set; }
        public decimal? TotalSum { get; set; }
        public ICollection<Supply_ProductGet> SupplyProducts { get; set; }

        public SupplyGet()
        {

        }
        public SupplyGet(Supply supply)
        {            
            this.SupplyID = supply.SupplyID;
            this.ShippingDate = supply.ShippingDate;
            this.ReceivingDate = supply.ReceivingDate;
            this.TotalSum = supply.SupplyProducts.Sum(i => i.Quantity * i.Product?.PurchasePrice); ;
            this.ProductCount = supply.SupplyProducts.Sum(i=> i.Quantity);
            this.IsReceived = supply.IsReceived;
            this.Note = supply.Note;
            this.SupplyProducts = supply.SupplyProducts.Select(i=> new Supply_ProductGet(i)).ToList();
        }

    }
}
