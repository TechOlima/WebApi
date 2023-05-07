using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Classes
{
    public class Order_Product
    {
        public int Order_ProductID { get; set; } 
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
