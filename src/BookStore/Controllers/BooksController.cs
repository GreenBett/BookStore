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
            var slAuthor = new List<SelectListItem>();
            var slPublisher = new List<SelectListItem>();
            var vm = new Book();
            foreach (Author author in _context.Authors.ToList())
            {
                slAuthor.Add(new SelectListItem() { Value = author.AuthorId.ToString(),
                                              Text = String.Format("{0}, {1}", author.LastName, author.FirstName), });
            }
            foreach (Publisher publisher in _context.Publishers.ToList())
            {
                slPublisher.Add(new SelectListItem()
                {
                    Value = publisher.PublisherId.ToString(),
                    Text = String.Format("{0}", publisher.Name),
                });
            }
            ViewBag.AuthorSelectList = slAuthor;
            ViewBag.PublisherSelectList = slPublisher;
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
            book.Author = _context.Authors.Find(book.AuthorId);
            book.Publisher = _context.Publishers.Find(book.PublisherId);
            if (book != null)
            {
                var vm = new BookDetailViewModel() {
                    BookTitle = book.BookTitle,
                    ISBN = book.ISBN.ToString(),
                    AuthorName = book.Author.LastName + ", " + book.Author.FirstName,
                    PublisherName = book.Publisher.Name,
                    PublishYear = book.PublishYear.ToString(),
                    UnitPrice = book.UnitPrice.ToString(),
                    Quantity = book.Quantity.ToString()
                };
                return View(vm);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var book = _context.Books.Find(id);
            book.Author = _context.Authors.Find(book.AuthorId);
            book.Publisher = _context.Publishers.Find(book.PublisherId);
            var slAuthor = new List<SelectListItem>();
            var slPublisher = new List<SelectListItem>();
            foreach (Author author in _context.Authors.ToList())
            {
                slAuthor.Add(new SelectListItem()
                {
                    Value = author.AuthorId.ToString(),
                    Text = String.Format("{0}, {1}", author.LastName, author.FirstName)
                });
            }
            foreach (Publisher publisher in _context.Publishers.ToList())
            {
                slPublisher.Add(new SelectListItem()
                {
                    Value = publisher.PublisherId.ToString(),
                    Text = String.Format("{0}", publisher.Name),
                });
            }
            ViewBag.AuthorSelectList = slAuthor;
            ViewBag.PublisherSelectList = slPublisher;
            if (book != null)
            {
                var vm = new BookViewModel()
                {
                    BookId = book.BookId,
                    BookTitle = book.BookTitle,
                    ISBN = book.ISBN,
                    PublishYear = book.PublishYear,
                    UnitPrice = book.UnitPrice,
                    Quantity = book.Quantity
                };
                return View(vm);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookViewModel bookvm)
        {
            if (ModelState.IsValid)
            {
                var book = new Book()
                {
                    BookId = bookvm.BookId,
                    BookTitle = bookvm.BookTitle,
                    AuthorId = bookvm.AuthorId,
                    PublisherId = bookvm.PublisherId,
                    ISBN = bookvm.ISBN,
                    PublishYear = bookvm.PublishYear,
                    UnitPrice = bookvm.UnitPrice,
                    Quantity = bookvm.Quantity
                };
                _context.Books.Update(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookvm);
        }

        public IActionResult Delete(int? id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                return View(book);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
