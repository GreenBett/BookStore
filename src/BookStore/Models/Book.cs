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
        public virtual Author Author { get; set; }

        public int PublisherId { get; set;  }
        public virtual Publisher Publisher { get; set; }
    }
}
