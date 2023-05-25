namespace WebApi.Classes.Operations
{
    public class SupplyGet : SupplyPut
    {
        public int? ProductCount { get; set; }
        public decimal? TotalSum { get; set; }
        public ICollection<StorageGet> Storages { get; set; }

        public SupplyGet()
        {

        }
        public SupplyGet(Supply supply)
        {            
            this.SupplyID = supply.SupplyID;
            this.ShippingDate = supply.ShippingDate;
            this.ReceivingDate = supply.ReceivingDate;
            this.TotalSum = supply.Storages.Sum(i=> i.PurchasePrice);
            this.ProductCount = supply.Storages.Count();
            this.IsReceived = supply.IsReceived;
            this.Note = supply.Note;
            this.Storages = supply.Storages.Select(i=> new StorageGet(i)).ToList();
        }

    }
}
