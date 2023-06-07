namespace WebApi.Classes.Operations
{
    public class ProductPut : ProductPost
    {
        public int ProductID { get; set; }
        public bool? Is_Deleted { get; set; }
        public int? VK_ID { get; set; }
    }
}
