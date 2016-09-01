using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoAlfredo.Context;
using ProyectoAlfredo.Models;
using ProyectoAlfredo.ViewModels;
using ProyectoAlfredo.Repositories;

namespace ProyectoAlfredo.Controllers
{
    public class PurchasesController : Controller
    {
        private AlfredoContext db = new AlfredoContext();
        private PurchaseRepository _repository = new PurchaseRepository();

        // GET: Purchases
        public ActionResult Index()
        {
            var purchases = db.Purchases.Include(p => p.Provider);
            return View(purchases.ToList());
        }

        // GET: Purchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // GET: Purchases/Create
        public ActionResult AddPurchase()
        {
            var purchaseView = new PurchaseView();
            purchaseView.Provider = new Provider();
            purchaseView.Products = new List<Product>();
                        
            ViewBag.ProviderID = new SelectList(_repository.ProviderList(), "ProviderID", "ProviderName");

            return View(purchaseView);
        }

       
        // POST: Purchases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPurchase([Bind(Include = "PurchaseID,DatePurchase,UploadDate,ProviderID,Quantity")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "ProviderName", purchase.ProviderID);
            return View(purchase);
        }

        //GET
        public ActionResult AddProduct()
        {
            
            ViewBag.ProductID = new SelectList(_repository.ProductList(), "ProductID", "Description");

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            var productID = int.Parse(Request["ProductID"]);

            if (productID == 0)
            {
                ViewBag.ProductID = new SelectList(_repository.ProductList(), "ProductID", "Description");
                ViewBag.Error = "Debe seleccionar un producto";
                return View(product);
            }
            
            return View();
        }

        // GET: Purchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "ProviderName", purchase.ProviderID);
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseID,DatePurchase,UploadDate,ProviderID,Quantity")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "ProviderName", purchase.ProviderID);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase purchase = db.Purchases.Find(id);
            db.Purchases.Remove(purchase);
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
    }
}
