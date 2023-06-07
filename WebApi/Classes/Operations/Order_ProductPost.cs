namespace WebApi.Classes.Operations
{
    public class Order_ProductPost
    {
        public int Quantity { get; set; }        
        public int? OrderID { get; set; }        
        public int? ProductID { get; set; }
    }
}
