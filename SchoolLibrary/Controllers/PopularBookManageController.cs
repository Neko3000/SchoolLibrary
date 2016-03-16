using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolLibrary.Models;

namespace SchoolLibrary.Controllers
{
    public class PopularBookManageController : Controller
    {
        private SchoolLibraryContext db = new SchoolLibraryContext();

        // GET: PopularBookManage
        public ActionResult Index()
        {
            var x = db.PopularBooks.ToList();
            return View(x);
        }

        // GET: PopularBookManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopularBook popularBook = db.PopularBooks.Find(id);
            if (popularBook == null)
            {
                return HttpNotFound();
            }
            return View(popularBook);
        }

        // GET: PopularBookManage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PopularBookManage/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PopularBook popularBook)
        {
            if (ModelState.IsValid)
            {
                popularBook.BookId = db.Books.Find(popularBook.BookId.Id);
                popularBook.RecordedTime = DateTime.Now;
                db.PopularBooks.Add(popularBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(popularBook);
        }

        // GET: PopularBookManage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopularBook popularBook = db.PopularBooks.Find(id);
            if (popularBook == null)
            {
                return HttpNotFound();
            }
            return View(popularBook);
        }

        // POST: PopularBookManage/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RecordedTime,Discription")] PopularBook popularBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(popularBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(popularBook);
        }

        // GET: PopularBookManage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopularBook popularBook = db.PopularBooks.Find(id);
            if (popularBook == null)
            {
                return HttpNotFound();
            }
            return View(popularBook);
        }

        // POST: PopularBookManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopularBook popularBook = db.PopularBooks.Find(id);
            db.PopularBooks.Remove(popularBook);
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
