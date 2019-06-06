using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ANVBookstore.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please Enter a Username")]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Upper and Lower Case")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter a password")]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Upper and Lower Case")]
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public decimal Cell { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
