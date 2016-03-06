using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolLibrary.Models;

namespace SchoolLibrary.Controllers
{
    public class HomeController : Controller
    {
        private SchoolLibraryContext db = new SchoolLibraryContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BookList(string keyword=null)
        {
            if(keyword==null)
            {
                return View(db.Books.ToList());
            }
            else
            {
                var books = db.Books.Where(a => a.Title.Contains(keyword)).Take(10).ToList();
                return View(books);
            }        
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