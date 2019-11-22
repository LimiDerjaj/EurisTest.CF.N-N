using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EURISTest.Models;

namespace EURISTest.Controllers
{
    public class CatalogController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        //
        // GET: /ProductCatalog/Create

        public ActionResult AddProduct(int id = 0)
        {
            List<Catalog> cat = new List<Catalog>();
            cat.Add(db.Catalogs.Find(id));
            
            if(cat==null)
            {
                return HttpNotFound();
            }
            ViewBag.FKCatalogID = new SelectList(cat, "CatalogID", "Code");
            ViewBag.FKProductID = new SelectList(db.Products, "ProductID", "Code");
            return View();
        }

        //
        // POST: /ProductCatalog/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(ProductCatalog productcatalog)
        {
            if (ModelState.IsValid)
            {
                db.ProductsCatalogs.Add(productcatalog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FKCatalogID = new SelectList(db.Catalogs, "CatalogID", "Code", productcatalog.FKCatalogID);
            ViewBag.FKProductID = new SelectList(db.Products, "ProductID", "Code", productcatalog.FKProductID);
            return View(productcatalog);
        }


        //
        // GET: /Catalog/

        public ActionResult Index()
        {
            return View(db.Catalogs.ToList());
        }

        //
        // GET: /Catalog/Details/5

        public ActionResult Details(int id = 0)
        {
            Catalog catalog = db.Catalogs.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }

            var productCatalog = db.ProductsCatalogs.Include(c => c.Catalog).Include(c => c.Product);
            List<ProductCatalog> controllo = new List<ProductCatalog>();
            foreach (var item in productCatalog.ToList())
            {
                if (item.Catalog.CatalogID == catalog.CatalogID)
                    controllo.Add(item);
            }
            return View(controllo);
        }

        //  
        // GET: /Catalog/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Catalog/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                db.Catalogs.Add(catalog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catalog);
        }

        //
        // GET: /Catalog/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Catalog catalog = db.Catalogs.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

        //
        // POST: /Catalog/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catalog);
        }

        //
        // GET: /Catalog/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Catalog catalog = db.Catalogs.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

        //
        // POST: /Catalog/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catalog catalog = db.Catalogs.Find(id);
            db.Catalogs.Remove(catalog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}