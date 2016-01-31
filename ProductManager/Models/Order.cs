using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProductManager.Models;

namespace ProductManager.Models
{
    public class Order
    {


        public Order()
        {

        }
        [Key]
        public int OrderId { get; set; }
        [DisplayName("Klient")]
        public int CustomerId { get; set; }

        [DisplayName("Nazwa zamówienia")]
        public string OrderName { get; set; }

        [DisplayName("Data wpłynięcia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        [DisplayName("Data dostarczenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDeliveryDeadlineDate { get; set; }

        [DisplayName("Data zrealizowania")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDeliveryDate { get; set; }


        [DisplayName("Ilość zamówiona")]
        public int QuantityOrdered { get; set; }

        [DisplayName("Ilość dostaczona")]
        public int QuantityDeliverded { get; set; }

        [DisplayName("Wartość")]
        [DataType(DataType.Currency)]
        public decimal OrderValue { get; set; }

        [DisplayName("Status")]
        public OrderStatus OrderStatus { get; set; }


        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public virtual Customer Customers { get; set; }




    }
}