using ProductManager.DAL;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManager.Models;
using System.Net;

namespace ProductManager.Controllers
{
    public class HomeController : Controller
    {
        private ProductManagerContext db = new ProductManagerContext();

        public ActionResult Index()
        {
            //var orders = db.Orders.Include(o => o.Products);
            //return View(orders.ToList());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}