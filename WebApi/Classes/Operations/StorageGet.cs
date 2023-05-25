namespace WebApi.Classes.Operations
{
    public class StorageGet : StoragePut
    {
        public string? ProductName { get; set; }

        public StorageGet()
        {

        }

        public StorageGet(Storage storage)
        {
            this.StorageID = storage.StorageID;
            this.PurchasePrice = storage.PurchasePrice;
            this.SalePrice = storage.SalePrice;
            this.SupplyID = storage.SupplyID;
            this.OrderID = storage.OrderID;
            this.ProductID = storage.ProductID;
            this.ProductName = storage?.Product?.Name;
        }
    }

}
