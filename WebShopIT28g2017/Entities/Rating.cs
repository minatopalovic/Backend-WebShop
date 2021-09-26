using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopIT28g2017.Entities
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int Userr { get; set; }
        public int Wardrobe { get; set; }
        public int? Mark { get; set; }
        public string Comment { get; set; }

        public virtual User UserrNavigation { get; set; }
        public virtual Wardrobe WardrobeNavigation { get; set; }
    }
}
