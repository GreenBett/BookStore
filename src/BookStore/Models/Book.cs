using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookStore.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot contain more than 50 characters.")]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public int PublishYear { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Price")]
        [Required]
        public decimal UnitPrice { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int PublisherId { get; set;  }
        public Publisher Publisher { get; set; }
    }
}
