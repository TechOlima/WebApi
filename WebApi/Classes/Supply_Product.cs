using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Classes
{
    public class Supply_Product
    {
        public int Supply_ProductID { get; set; }
        public int Quantity { get; set; }
        public Supply Supply { get; set; }
        public Product Product { get; set; }
    }
}
