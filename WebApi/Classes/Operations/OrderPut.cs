using System.ComponentModel.DataAnnotations;

namespace WebApi.Classes.Operations
{
    public class OrderPut : OrderPost
    {
        public int OrderID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? OrderDate { get; set; }

        
    }
}
