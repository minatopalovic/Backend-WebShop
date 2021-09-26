using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopIT28g2017.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderWardrobes = new HashSet<OrderWardrobe>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentMethod { get; set; }
        public int TotalPrice { get; set; }
        public bool Confirmed { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderWardrobe> OrderWardrobes { get; set; }
    }
}
