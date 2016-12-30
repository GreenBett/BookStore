using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    public class AuthorsController : Controller
    {
        public StoreContext _context;

        public AuthorsController(StoreContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<AuthorViewModel> avm = new List<AuthorViewModel>();
            foreach(Author author in _context.Authors.ToList())
            {
                avm.Add(new AuthorViewModel()
                {
                    AuthorId = author.AuthorId,
                    Name = String.Format("{0}, {1}", author.LastName, author.FirstName),
                    DateOfBirth = author.DateOfBirth.ToString()
                });
            }
            return View(avm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                author.Books = new List<Book>();
                _context.Authors.Add(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        public IActionResult Details(int? id)
        {
            Author author = _context.Authors.Find(id);
            if (author != null)
            {
                AuthorViewModel avm = new AuthorViewModel();
                avm.AuthorId = author.AuthorId;
                avm.Name = String.Format("{0}, {1}", author.LastName, author.FirstName);
                avm.DateOfBirth = author.DateOfBirth.ToString();
                avm.Books = _context.Books.Where(o=> o.AuthorId == id);
                return View(avm);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            Author author = _context.Authors.Find(id);
            if (author != null)
            {
                return View(author);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Author author = _context.Authors.Find(id);
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ActionName("Edit")]
        public IActionResult Edit(int? id)
        {
            Author author = _context.Authors.Find(id);
            if (author != null)
            {
                return View(author);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Update(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }
    }
}
