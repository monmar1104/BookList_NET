using System;
using System.ComponentModel.DataAnnotations;

namespace BookList.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
