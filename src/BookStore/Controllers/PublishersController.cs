using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    public class PublishersController : Controller
    {
       private  StoreContext _context;
        public PublishersController(StoreContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Publishers.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Publishers.Add(publisher);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            Publisher publisher = _context.Publishers.Find(id);
            if (publisher != null)
            {
                return View(publisher);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Publisher publisher = _context.Publishers.Find(id);
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details (int? id)
        {
            Publisher publisher = _context.Publishers.Find(id);
            if (publisher != null)
            {
                return View(publisher);
            }
            return RedirectToAction("Index");
        }
        [ActionName("Edit")]
        public IActionResult Edit (int? id)
        {
            Publisher publisher = _context.Publishers.Find(id);
            if (publisher != null)
            {
                return View(publisher);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                Publisher p = _context.Publishers.Find(publisher.PublisherId);
                p.Name = publisher.Name;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }
    }
}
