using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.ViewModels
{
    public class CustomerOrderProductViewModel
    {
        public IEnumerable<Product> ProductViewModel { get { return ProductViewModel; } set { this.ProductViewModel = ProductViewModel; } }
        public IEnumerable <Order> OrderViewModel { get; set; }
        public IEnumerable <Customer> CustomerViewMOdel { get; set; }
    }
}
