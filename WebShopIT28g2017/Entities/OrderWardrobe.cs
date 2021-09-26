using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopIT28g2017.Entities
{
    public partial class OrderWardrobe
    {
        public int OwId { get; set; }
        public int Orderr { get; set; }
        public int Wardrobe { get; set; }
        public int Quantity { get; set; }

        public virtual Order OrderrNavigation { get; set; }
        public virtual Wardrobe WardrobeNavigation { get; set; }
    }
}
