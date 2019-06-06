using System;
using System.Collections.Generic;

namespace ANVBookstore.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public byte[] CreatedOn { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
