using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Classes.Operations;

namespace WebApi.Classes
{
    public class Storage
    {
        public int StorageID { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? SalePrice { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; }
        public Order? Order { get; set; }
        public int? OrderID { get; set; }
        public Supply? Supply { get; set; }
        public int? SupplyID { get; set; }

        public Storage()
        {

        }

        public Storage(StoragePut storagePut)
        {
            this.StorageID = storagePut.StorageID;
            this.PurchasePrice = storagePut.PurchasePrice;
            this.SalePrice = storagePut.SalePrice;
            this.ProductID = storagePut.ProductID;
            this.OrderID = storagePut.OrderID;
            this.SupplyID = storagePut.SupplyID;
        }

        public Storage(StoragePost storagePost)
        {
            this.PurchasePrice = storagePost.PurchasePrice;
            this.SalePrice = storagePost.SalePrice;
            this.ProductID = storagePost.ProductID;
            this.OrderID = storagePost.OrderID;
            this.SupplyID = storagePost.SupplyID;
        }
    }
}
