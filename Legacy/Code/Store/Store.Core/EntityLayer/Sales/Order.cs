using System;
using System.Collections.ObjectModel;
using Store.Core.EntityLayer.Dbo;
using Store.Core.EntityLayer.HumanResources;

namespace Store.Core.EntityLayer.Sales
{
    public class Order : IAuditableEntity
    {
        public Order()
        {
        }

        public Order(long? orderID)
        {
            OrderID = orderID;
        }

        public long? OrderID { get; set; }

        public short? OrderStatusID { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? CustomerID { get; set; }

        public int? EmployeeID { get; set; }

        public int? ShipperID { get; set; }

        public decimal? Total { get; set; }

        public short? CurrencyID { get; set; }

        public Guid? PaymentMethodID { get; set; }

        public string Comments { get; set; }

        public string CreationUser { get; set; }

        public DateTime? CreationDateTime { get; set; }

        public string LastUpdateUser { get; set; }

        public DateTime? LastUpdateDateTime { get; set; }

        public byte[] Timestamp { get; set; }

        public virtual OrderStatus OrderStatusFk { get; set; }

        public virtual Customer CustomerFk { get; set; }

        public virtual Employee EmployeeFk { get; set; }

        public virtual Shipper ShipperFk { get; set; }

        public virtual Currency CurrencyFk { get; set; }

        public virtual PaymentMethod PaymentMethodFk { get; set; }

        public virtual Collection<OrderDetail> OrderDetails { get; set; } = new Collection<OrderDetail>();
    }
}
