namespace WebApi.Classes.Operations
{
    public class Supply_ProductGet : Supply_ProductPut
    {
        public string? productName { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? TotalSum { get; set; }

        public Supply_ProductGet()
        {

        }
        public Supply_ProductGet(Supply_Product Supply_Product)
        {
            this.SupplyID = Supply_Product.SupplyID;
            this.Supply_ProductID = Supply_Product.Supply_ProductID;
            this.ProductID = Supply_Product.ProductID;
            this.Quantity = Supply_Product.Quantity;
            this.productName = Supply_Product?.Product?.Name;
            this.PurchasePrice = Supply_Product?.Product?.PurchasePrice;
            this.TotalSum = this.Quantity * this.PurchasePrice;
        }
    }
}
