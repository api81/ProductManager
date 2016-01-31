using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManager.Models
{
    public class ProductOrder
    {
        [Key]
        public int ProductOrderId { get; set; }
        [DisplayName("Nazwa produktu")]
        public int ProductId { get; set; }
        [DisplayName("Nazwa zamówienia")]
        public int OrderId { get; set; }

       

        public virtual Product Products { get; set; }
        public virtual Order Orders { get; set; }
    }
}