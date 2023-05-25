namespace WebApi.Classes.Operations
{
    public class OrderGet : OrderPut
    {
        public int? ProductCount { get; set; }
        public decimal? TotalSum { get; set; }
        public ICollection<StorageGet> Storages { get; set; }

        public OrderGet()
        {

        }
        public OrderGet(Order order)
        {
            this.OrderID = order.OrderID;            
            this.OrderDate = order.OrderDate;            
            this.Note = order.Note;
            this.ClientName = order.ClientName;
            this.ClientPhone = order.ClientPhone;
            this.ClientEmail = order.ClientEmail;
            this.DeliveryAddress = order.DeliveryAddress;
            this.DeliveryDate = order.DeliveryDate;
            this.State = order?.State?.Name;
            this.Storages = order.Storages.Select(i => new StorageGet(i)).ToList();
            this.TotalSum = order.Storages.Sum(i => i.PurchasePrice);
            this.ProductCount = order.Storages.Count();
        }
    }
}
