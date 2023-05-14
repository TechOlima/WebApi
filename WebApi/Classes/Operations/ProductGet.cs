namespace WebApi.Classes.Operations
{
    public class ProductGet : ProductPost
    {
        public int ProductID { get; set; }
        public ICollection<Photo>? Photos { get; set; }
        public ICollection<InsertPut>? Inserts { get; set; }

        public ProductGet(Product product)
        {
            this.ProductID = product.ProductID;
            this.Name = product.Name;
            this.ProductType = product.ProductType?.Name;
            this.MaterialType = product.MaterialType?.Name;
            this.Equipment = product.Equipment;
            this.VendorCode = product.VendorCode;
            this.Size = product.Size;
            this.Description = product.Description;
            this.GenderType = product.GenderType?.Name;
            this.Is_Deleted = product.Is_Deleted;
            this.Photos = product.Photos;
            this.Inserts = product?.Inserts?.Select(i=> new InsertPut(i)).ToList();
        }
    }
}
