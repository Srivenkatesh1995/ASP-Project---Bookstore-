using System;
using System.Collections.Generic;

namespace ANVBookstore.Models
{
    public partial class OrderItems
    {
        public int OrderQty { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderItemPk { get; set; }

        public virtual Order Order { get; set; }
        public virtual Textbook Product { get; set; }
    }
}
