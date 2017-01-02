using BookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        [Required, StringLength(50, ErrorMessage = "Name cannot contain more than 50 characters.")]
        public string BookTitle { get; set; }
        [Required]
        public int ISBN { get; set; }
        [Required, Range(1, 2100)]
        public int PublishYear { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Price"), Required]
        public decimal UnitPrice { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
    }
}
