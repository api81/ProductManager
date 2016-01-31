using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductManager.DAL;
using ProductManager.Models;
using System.IO;

namespace ProductManager.Controllers
{
    public class ProductsController : Controller
    {
        private ProductManagerContext db = new ProductManagerContext();

        // GET: Products
        
        public ActionResult Index(string sortOrder, string searchString)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DescrytionSortParm = sortOrder == "Descryption" ? "descryption_desc" : "Descryption";
            var products = from p in db.Products
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.ProductName.Contains(searchString)
                                       || p.ProductsDescryption.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(p => p.ProductName);
                    break;
                case "Descryption":
                    products = products.OrderBy(p => p.ProductsDescryption);
                    break;
                case "descrytion_desc":
                    products = products.OrderByDescending(p => p.ProductsDescryption);
                    break;
                default:
                    products = products.OrderBy(p => p.ProductName);
                    break;
            }
           


            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Include(pf => pf.FilePaths).SingleOrDefault(pf => pf.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,ProductsDescryption,ProductHeight,ProductWidth,ProductPrice")] Product product, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                UploadImage(product, upload);


                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Include(pf => pf.FilePaths).SingleOrDefault(pf => pf.ProductId == id);
            //Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,ProductsDescryption,ProductHeight,ProductWidth,ProductPrice")] Product product, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
               

                db.Entry(product).State = EntityState.Modified;
                UploadImage(product, upload);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
       
        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Uploading images
        /// </summary>
        /// <param name="product"></param>
        /// <param name="upload"></param>
        private void UploadImage(Product product, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                var photo = new FilePath
                {

                    FileName = Guid.NewGuid().ToString() + Path.GetExtension(upload.FileName),
                    FileType = FileType.Photo
                };
                product.FilePaths = new List<FilePath>();
                product.FilePaths.Add(photo);
                upload.SaveAs(Path.Combine(Server.MapPath("~/images"), photo.FileName));
            }
        }
    }
}
