using WebApi.Classes.Operations;

namespace WebApi.Classes
{
    public class Supply_Product
    {
        public int Supply_ProductID { get; set; }
        public int Quantity { get; set; }
        public Supply? Supply { get; set; }
        public Product? Product { get; set; }
        public int? SupplyID { get; set; }        
        public int? ProductID { get; set; }

        public Supply_Product()
        {

        }

        public Supply_Product(Supply_ProductPut Supply_ProductPut)
        {
            this.SupplyID = Supply_ProductPut.SupplyID;
            this.ProductID = Supply_ProductPut.ProductID;
            this.Quantity = Supply_ProductPut.Quantity;
            this.Supply_ProductID = Supply_ProductPut.Supply_ProductID;
        }

        public Supply_Product(Supply_ProductPost Supply_ProductPost)
        {
            this.SupplyID = Supply_ProductPost.SupplyID;
            this.ProductID = Supply_ProductPost.ProductID;
            this.Quantity = Supply_ProductPost.Quantity;
        }
    }
}
