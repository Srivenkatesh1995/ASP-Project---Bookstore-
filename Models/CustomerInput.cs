using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;



namespace ANVBookstore.Models
{
    public class CustomerInput
    {
        [Required(ErrorMessage = "Please Enter a Username")]
        [MaxLength(50)]
        public string CustomerUser { get; set; }

        [Required(ErrorMessage = "Please Enter a Password")]
        [MaxLength(50)]
        [UIHint("password")]
        public string CustomerPass { get; set; }
        
        public string ReturnURL { get; set; }
    }
}
