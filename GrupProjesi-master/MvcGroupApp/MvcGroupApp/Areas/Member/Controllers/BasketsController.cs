using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcGroupApp.Models;

namespace MvcGroupApp.Areas.Member.Controllers
{
    public class BasketsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Member/Baskets
        public ActionResult Index()
        {
            var baskets = db.Baskets.Include(b => b.product).Include(b => b.user);
            return View(baskets.ToList());
        }

        // GET: Member/Baskets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basket basket = db.Baskets.Find(id);
            if (basket == null)
            {
                return HttpNotFound();
            }
            return View(basket);
        }

        // GET: Member/Baskets/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId");
            return View();
        }

        // POST: Member/Baskets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BasketPrice,Amount,ProductId,UserId,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                db.Baskets.Add(basket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", basket.ProductId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId", basket.UserId);
            return View(basket);
        }

        // GET: Member/Baskets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basket basket = db.Baskets.Find(id);
            if (basket == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", basket.ProductId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId", basket.UserId);
            return View(basket);
        }

        // POST: Member/Baskets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BasketPrice,Amount,ProductId,UserId,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", basket.ProductId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId", basket.UserId);
            return View(basket);
        }

        // GET: Member/Baskets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basket basket = db.Baskets.Find(id);
            if (basket == null)
            {
                return HttpNotFound();
            }
            return View(basket);
        }

        // POST: Member/Baskets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Basket basket = db.Baskets.Find(id);
            db.Baskets.Remove(basket);
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
