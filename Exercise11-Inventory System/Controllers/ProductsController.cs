using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exercise11_Inventory_System.DataAccessLayer;
using Exercise11_Inventory_System.Models;
using PagedList;

namespace Exercise11_Inventory_System.Controllers
{
    public class ProductsController : Controller
    {
        private StorageContext db = new StorageContext();

        private void CountOutOfStock()
        {
            ViewBag.Count = db.Products.Where(i => i.Count == 0).Count();
        }

        public ActionResult Index(int page = 1)
        {
            CountOutOfStock();
            return View(db.Products.ToArray()
                .Select(item => new ProductIndex(item.Id, item.Name, item.Price, item.Category, item.Shelf, item.Count))
                .ToPagedList(Math.Max(page,1), 10));

            //var items = new List<ProductIndex>();
            //foreach (var item in db.Products.ToList())
            //{
            //    items.Add(new ProductIndex(item.Id, item.Name, item.Price, item.Category, item.Shelf, item.Count));
            //}
            //return View(items.ToPagedList(Math.Max(page,1), 10));
        }

        public ActionResult Details(int? id)
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
            CountOutOfStock();
            return View(product);
        }

        public ActionResult Create()
        {
            CountOutOfStock();
            return View();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Category,Shelf,Count,Description,RestockLimit")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CountOutOfStock();
            return View(product);
        }

        public ActionResult Edit(int? id)
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
            CountOutOfStock();
            return View(product);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Category,Shelf,Count,Description,RestockLimit")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CountOutOfStock();
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
            CountOutOfStock();
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
            CountOutOfStock();
            return RedirectToAction("Index");
        }

        public ActionResult Electronics()
        {
            CountOutOfStock();
            return View(db.Products.ToArray()
                .Where(i => i.Category.Equals("Electronics", StringComparison.InvariantCultureIgnoreCase))
                .Select(item => new ProductElectronics(item.Id, item.Name, item.Price, item.Shelf, item.Count))
                .ToList());

            //var electronics = new List<ProductElectronics>();
            //foreach (var item in db.Products
            //    .Where(i => i.Category.Equals("Electronics", StringComparison.InvariantCultureIgnoreCase))
            //    .ToList())
            //{
            //    electronics.Add(new ProductElectronics(item.Id, item.Name, item.Price, item.Shelf, item.Count));
            //}
            //return View(electronics);
        }

        public ActionResult Category(string category, int page = 1)
        {
            if (category == null || category.Length < 2)
                return RedirectToAction("CategorySearch", "Products", new { category });

            ViewBag.Title = category;
            CountOutOfStock();

            return View(db.Products.ToArray()
                .Where(i => i.Category.Equals(category, StringComparison.InvariantCultureIgnoreCase))
                .Select(item => new ProductCategory(item.Id, item.Name, item.Price, item.Shelf, item.Count))
                .ToPagedList(Math.Max(page, 1), 10));

            //var items = new List<ProductCategory>();
            //foreach (var item in db.Products
            //    .Where(i => i.Category.Equals(category, StringComparison.InvariantCultureIgnoreCase))
            //    .ToList())
            //{
            //    items.Add(new ProductCategory(item.Id, item.Name, item.Price, item.Shelf, item.Count));
            //}
            //return View(items.ToPagedList(Math.Max(page, 1), 10));
        }

        public ActionResult CategorySearch(string category)
        {
            if (category != null && category.Length >= 2)
                return RedirectToAction("Category", "Products", new { category });

            CountOutOfStock();
            return View(new ProductCategorySearch(db.Products.ToArray()
                .Select(i => i.Category )
                .Distinct()
                .ToList()));

            //var items = new List<string>();
            //foreach (var item in db.Products
            //    .Select(i => new { i.Category })
            //    .Distinct()
            //    .ToList())
            //{
            //    items.Add(item.Category);
            //}
            //return View(new ProductCategorySearch(items));
        }

        public ActionResult OutOfStock()
        {
            var items = new List<ProductOutOfStock>();
            foreach (var item in db.Products.Where(i => i.Count == 0).ToList())
            {
                items.Add(new ProductOutOfStock(item.Id, item.Name, item.Price));
            }
            CountOutOfStock();
            return View(items);
        }

        public ActionResult Restock()
        {
            var items = new List<ProductRestock>();
            foreach (var item in db.Products.Where(i => i.Count < i.RestockLimit).ToList())
            {
                items.Add(new ProductRestock(item.Id, item.Name, item.Category, item.Shelf, item.Count, item.RestockLimit));
            }
            CountOutOfStock();
            return View(items);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RestockUpdate(int id = -1, int count = 0)
        {
            Product product = db.Products.FirstOrDefault(item => item.Id == id);
            if (ModelState.IsValid && product != null && count >= 0 && count < 256)
            {
                product.Count = count;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { returnvalue = 200, returnstring = "Saved" });
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Id unavailable"); ;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
