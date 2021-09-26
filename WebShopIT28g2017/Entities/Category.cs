using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopIT28g2017.Entities
{
    public partial class Category
    {
        public Category()
        {
            Wardrobes = new HashSet<Wardrobe>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Wardrobe> Wardrobes { get; set; }
    }
}
