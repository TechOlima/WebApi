namespace WebApi.Classes.Operations
{
    public class OrderGet : OrderPut
    {
        public int? ProductCount { get; set; }
        public decimal? TotalSum { get; set; }
        public ICollection<Order_ProductGet>? OrderProducts { get; set; }

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
            this.OrderProducts = order?.OrderProducts?.Select(i=> new Order_ProductGet(i)).ToList();
            this.TotalSum = order?.OrderProducts.Sum(i => i.Quantity * i.Product?.SalePrice);
            this.ProductCount = order.OrderProducts.Sum(i=> i.Quantity);
            //поля для стандартизированного адреса
            this.DeliveryAddressStd=order.DeliveryAddressStd;
            this.StreetWithType=order.StreetWithType;
            this.House= order.House;
            this.Block= order.Block;
            this.Entrance= order.Entrance;
            this.Floor= order.Floor;
            this.Flat= order.Flat;
            this.QC= order.QC;
            this.EmailNotification= order.EmailNotification;
            this.SmsNotification= order.SmsNotification;
        }
    }
}
