using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcGroupApp.Models;
using MvcGroupApp.Helper;
using Microsoft.AspNet.Identity;

namespace MvcGroupApp.Controllers
{
    public class UsersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Users
       
        public async Task<ActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            var user = new User();
            return View(user);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserName,UserSurname,UserMail,UserPhone,UserAddress,UserPassword,UserType,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] User user)
        {

            if (ModelState.IsValid)
            {
                user.CreateDate = DateTime.Now;
                user.CreatedBy = User.Identity.Name;
                user.UpdateDate = DateTime.Now;
                user.UpdatedBy = User.Identity.Name;
                user.UserMail = AccountController._email;
                user.UserId = User.Identity.GetUserId();
                user.UserType = "U";

                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit()
        {
            //string Userid = "74c26955-c7af-46a5-8faf-c2c80529fa4f";
            string Userid = User.Identity.GetUserId();

            if (Userid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var id = db.Users.Where(x => x.UserId == Userid).Select(a => a.Id).ToList().Single();
            
            User user = await db.Users.FindAsync(id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserName,UserSurname,UserMail,UserPhone,UserAddress,UserPassword,UserType,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] User user)
        {
           
            if (ModelState.IsValid)
            {
                user.UpdateDate = DateTime.Now;
                user.UpdatedBy = User.Identity.Name;
                user.UserId = User.Identity.Name;
                user.CreatedBy = User.Identity.Name;
                
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
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
