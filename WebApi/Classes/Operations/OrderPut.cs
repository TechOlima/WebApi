using System.ComponentModel.DataAnnotations;

namespace WebApi.Classes.Operations
{
    public class OrderPut
    {
        public int OrderID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? OrderDate { get; set; }

        public string? ClientName { get; set; }
        public string? ClientPhone { get; set; }
        public string? ClientEmail { get; set; }
        public string? State { get; set; }
        public string DeliveryAddress { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeliveryDate { get; set; }
        public string? Note { get; set; }

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

    }
}
