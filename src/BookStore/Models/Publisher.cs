using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BookStore.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        [Required, StringLength(50, ErrorMessage = "Name cannot contain more than 50 characters.")]
        public string Name { get; set; }
    }
}
