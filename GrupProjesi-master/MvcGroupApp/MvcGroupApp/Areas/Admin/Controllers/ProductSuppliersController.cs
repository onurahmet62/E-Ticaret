using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcGroupApp.Models;

namespace MvcGroupApp.Areas.Admin.Controllers
{
    public class ProductSuppliersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/ProductSuppliers
        public ActionResult Index()
        {
            var productSuppliers = db.ProductSuppliers.Include(p => p.product).Include(p => p.supplier);
            return View(productSuppliers.ToList());
        }

        // GET: Admin/ProductSuppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSupplier productSupplier = db.ProductSuppliers.Find(id);
            if (productSupplier == null)
            {
                return HttpNotFound();
            }
            return View(productSupplier);
        }

        // GET: Admin/ProductSuppliers/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "SupplierName");
            return View();
        }

        // POST: Admin/ProductSuppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,SupplierId,Date,PurchasePrice,OrderAmount,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] ProductSupplier productSupplier)
        {
            if (ModelState.IsValid)
            {
                db.ProductSuppliers.Add(productSupplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", productSupplier.ProductId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "SupplierName", productSupplier.SupplierId);
            return View(productSupplier);
        }

        // GET: Admin/ProductSuppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSupplier productSupplier = db.ProductSuppliers.Find(id);
            if (productSupplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", productSupplier.ProductId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "SupplierName", productSupplier.SupplierId);
            return View(productSupplier);
        }

        // POST: Admin/ProductSuppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,SupplierId,Date,PurchasePrice,OrderAmount,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] ProductSupplier productSupplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSupplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", productSupplier.ProductId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "SupplierName", productSupplier.SupplierId);
            return View(productSupplier);
        }

        // GET: Admin/ProductSuppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSupplier productSupplier = db.ProductSuppliers.Find(id);
            if (productSupplier == null)
            {
                return HttpNotFound();
            }
            return View(productSupplier);
        }

        // POST: Admin/ProductSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSupplier productSupplier = db.ProductSuppliers.Find(id);
            db.ProductSuppliers.Remove(productSupplier);
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
