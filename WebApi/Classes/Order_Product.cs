using WebApi.Classes.Operations;

namespace WebApi.Classes
{
    public class Order_Product
    {
        public int Order_ProductID { get; set; }
        public int Quantity { get; set; }
        public Order? Order { get; set; }
        public int? OrderID { get; set; }
        public Product? Product { get; set; }
        public int? ProductID { get; set; }

        public Order_Product()
        {

        }

        public Order_Product(Order_ProductPut Order_ProductPut)
        {
            this.OrderID = Order_ProductPut.OrderID;
            this.ProductID = Order_ProductPut.ProductID;
            this.Quantity = Order_ProductPut.Quantity;
            this.Order_ProductID = Order_ProductPut.Order_ProductID;
        }

        public Order_Product(Order_ProductPost Order_ProductPost)
        {
            this.OrderID = Order_ProductPost.OrderID;
            this.ProductID = Order_ProductPost.ProductID;
            this.Quantity = Order_ProductPost.Quantity;
        }
    }
}
