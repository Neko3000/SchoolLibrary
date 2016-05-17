using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolLibrary.Models;

namespace SchoolLibrary.Controllers
{
    public class BorrowingBooksController : Controller
    {
        private SchoolLibraryContext db = new SchoolLibraryContext();
        // GET: BorrowingBooks
        public ActionResult ShowAccountRecord(string id)
        {
            var books = (from singleRecord in db.BorrowingRecords
                        where (singleRecord.UserId.ToString() == id&&singleRecord.CurrentStatus=="借出")
                        select singleRecord.Book).ToList();
            return View(books);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRecord(int BookId,string UserId)
        {
            if (ModelState.IsValid)
            {
                var exsitRecord = db.BorrowingRecords.Where(a => a.Book.Id == BookId && a.UserId.ToString() == UserId).ToList();
                if(exsitRecord.Count>=1)
                {
                    return RedirectToAction("ShowAccountRecord","BorrowingBooks",new { id = UserId });
                }
                var updatedBook = db.Books.Find(BookId);
                updatedBook.CurrentCount = updatedBook.CurrentCount - 1;
                db.Entry(updatedBook).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var record = new BorrowingRecord
                {
                    UserId = new Guid(UserId),
                    Book = db.Books.Find(BookId),
                    BorrowingTime=DateTime.Now,
                    CurrentStatus="借出"
                };
                db.BorrowingRecords.Add(record);
                db.SaveChanges();            
            }
            return RedirectToAction("BookList", "Home");
        }
    }
}