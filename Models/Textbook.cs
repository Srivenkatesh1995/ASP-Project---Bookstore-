using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ANVBookstore.Models
{
    public partial class Textbook
    {
        public Textbook()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int TextbookId { get; set; }
        [Required(ErrorMessage = "Please Enter a Textbook Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter a Textbook Author")]
        [MaxLength(50)]
        public string Author { get; set; }
        [Required(ErrorMessage = "Please Enter a valid Price/Cost")]
        [Range(2, 1000, ErrorMessage = "Please enter a value between 2 and 1000")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please Enter a Course  ID")]
        [MaxLength(50)]
        public string CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
