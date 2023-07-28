using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Classes.Operations;

namespace WebApi.Classes
{
    public class Order
    {
        public int OrderID { get; set; }
        public string? ClientName { get; set; }
        public string? ClientPhone { get; set; }
        public string? ClientEmail { get; set; }
        public State State { get; set; }        
        public string DeliveryAddress { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeliveryDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? OrderDate { get; set; }
        public string? Note { get; set; }
        public ICollection<Order_Product> OrderProducts { get; set; }

        //поля для стандартизированного адреса
        public string? DeliveryAddressStd { get; set; }
        public string? StreetWithType { get; set; }
        public string? House { get; set; }
        public string? Block { get; set; }
        public string? Entrance { get; set; }
        public string? Floor { get; set; }
        public string? Flat { get; set; }
        public string? QC { get; set; }

        //поля для уведомлений
        public bool? EmailNotification { get; set; }
        public bool? SmsNotification { get; set; }

        public Order()
        {

        }

        public Order(OrderPut orderPut, DataContext _context)
        {
            this.OrderID = orderPut.OrderID;
            this.ClientName = orderPut.ClientName;
            this.ClientPhone = orderPut.ClientPhone;
            this.ClientEmail = orderPut.ClientEmail;
            this.State = _context.State.Where(i => i.Name == orderPut.State).FirstOrDefault();            
            this.DeliveryAddress = orderPut.DeliveryAddress;
            this.DeliveryDate = orderPut.DeliveryDate;
            this.OrderDate = orderPut.OrderDate;
            this.Note = orderPut.Note;
            //поля стандартизированного адреса
            this.DeliveryAddressStd = orderPut.DeliveryAddressStd;
            this.StreetWithType = orderPut.StreetWithType;
            this.House = orderPut.House;
            this.Block = orderPut.Block;
            this.Entrance = orderPut.Entrance;
            this.Floor = orderPut.Floor;
            this.Flat = orderPut.Flat;
            this.QC = orderPut.QC;
            this.SmsNotification = orderPut.SmsNotification;
            this.EmailNotification = orderPut.EmailNotification;
        }

        public Order(OrderPost orderPost, DataContext _context)
        {
            this.ClientName = orderPost.ClientName;
            this.ClientPhone = orderPost.ClientPhone;
            this.ClientEmail = orderPost.ClientEmail;
            this.State = String.IsNullOrEmpty(orderPost.State) ?
                _context.State.OrderBy(i=> i.StateID).FirstOrDefault() :
                _context.State.Where(i=> i.Name == orderPost.State).FirstOrDefault();            
            this.DeliveryAddress = orderPost.DeliveryAddress;
            this.DeliveryDate = orderPost.DeliveryDate;
            this.OrderDate = DateTime.Now;
            this.Note = orderPost.Note;
            //поля стандартизированного адреса
            this.DeliveryAddressStd = orderPost.DeliveryAddressStd;
            this.StreetWithType = orderPost.StreetWithType;
            this.House = orderPost.House;
            this.Block = orderPost.Block;
            this.Entrance = orderPost.Entrance;
            this.Floor = orderPost.Floor;
            this.Flat = orderPost.Flat;
            this.QC = orderPost.QC;
            this.SmsNotification = orderPost.SmsNotification;
            this.EmailNotification = orderPost.EmailNotification;
            this.OrderProducts = orderPost.OrderProducts.Select(i=> new Order_Product(i)).ToList();
        }
    }
}
