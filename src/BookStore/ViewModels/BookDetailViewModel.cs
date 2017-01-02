using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class BookDetailViewModel
    {
        public string BookTitle { get; set; }
        public string ISBN { get; set; }
        public string PublishYear { get; set; }
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
    }
}
