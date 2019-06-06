using System;
using System.Collections.Generic;

namespace ANVBookstore.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Admin = new HashSet<Admin>();
            Customer = new HashSet<Customer>();
        }

        public int RoleId { get; set; }
        public string UserDefinition { get; set; }

        public virtual ICollection<Admin> Admin { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
    }
}
