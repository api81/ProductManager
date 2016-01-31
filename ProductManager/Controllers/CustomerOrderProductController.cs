using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManager.ViewModels;
using ProductManager.Models;
using System.Data.Entity;
using ProductManager.DAL;

namespace ProductManager.Controllers
{
    public class CustomerOrderProductController : Controller
    {

        private ProductManagerContext db = new ProductManagerContext();
        // GET: CustomerOrderProduct
        public ActionResult Index()
        {
            List<object> customerOrderProduct = new List<object>();
            customerOrderProduct.Add(db.Products.ToList());
            customerOrderProduct.Add(db.Customers.ToList());
            customerOrderProduct.Add(db.Orders.ToList());

            return View(customerOrderProduct);
        }
    }
}