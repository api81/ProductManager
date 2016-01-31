using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManager.Models
{
    public class Customer
    {
        public Customer()
        {
            
        }
        [Key]
        public int CustomerId { get; set; }
        [DisplayName("Klient")]
        public string CustomerName { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
    }
}