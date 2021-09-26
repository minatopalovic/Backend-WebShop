using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopIT28g2017.Entities
{
    public partial class Wardrobe
    {
        public Wardrobe()
        {
            OrderWardrobes = new HashSet<OrderWardrobe>();
            Ratings = new HashSet<Rating>();
        }

        public int WardrobeId { get; set; }
        public int ModelId { get; set; }
        public int CategoryId { get; set; }
        public int MaterialId { get; set; }
        public int SupplierId { get; set; }
        public string WardrobeColor { get; set; }
        public string WardrobeSize { get; set; }
        public int WardrobePrice { get; set; }
        public string WardrobeDescription { get; set; }
        public string WardrobePicture { get; set; }
        public string WardrobeBrand { get; set; }
        public bool InStock { get; set; }
        public int? StockQuatity { get; set; }

        public virtual Category Category { get; set; }
        public virtual Material Material { get; set; }
        public virtual Model Model { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderWardrobe> OrderWardrobes { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
