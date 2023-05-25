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
        public ICollection<Storage> Storages { get; set; }

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
        }
    }
}
