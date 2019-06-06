using System;
using System.Collections.Generic;

namespace ANVBookstore.Models
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
    }
}
