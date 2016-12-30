using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private StoreContext _context;
        public BooksController(StoreContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Books.ToList());
        }

        public IActionResult Create()
        {
            var sl = new List<SelectListItem>();
            var vm = new BookViewModel();
            foreach (Author author in _context.Authors.ToList())
            {
                sl.Add(new SelectListItem() { Value = author.AuthorId.ToString(),
                                              Text = String.Format("{0}, {1}", author.LastName, author.FirstName), });
            }
            ViewBag.SelectList = sl;
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Details(int? id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                return View(book);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                return View(book);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Delete(int? id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            return View();
        }
    }
}
