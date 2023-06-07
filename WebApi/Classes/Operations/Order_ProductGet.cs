namespace WebApi.Classes.Operations
{
    public class Order_ProductGet : Order_ProductPut
    {
        public string? productName { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? TotalSum { get; set; }

        public Order_ProductGet()
        {

        }
        public Order_ProductGet(Order_Product Order_Product)
        {
            this.OrderID = Order_Product.OrderID;
            this.Order_ProductID = Order_Product.Order_ProductID;
            this.ProductID = Order_Product.ProductID;
            this.Quantity = Order_Product.Quantity;
            this.productName = Order_Product?.Product?.Name;
            this.SalePrice = Order_Product?.Product?.SalePrice;
            this.TotalSum = this.Quantity * this.SalePrice;
        }
    }
}
