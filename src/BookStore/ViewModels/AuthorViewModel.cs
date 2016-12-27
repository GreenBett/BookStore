using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;


namespace BookStore.ViewModels
{
    public class AuthorViewModel
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
