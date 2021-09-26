using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopIT28g2017.Entities
{
    public partial class Material
    {
        public Material()
        {
            Wardrobes = new HashSet<Wardrobe>();
        }

        public int MaterialId { get; set; }
        public string MaterialName { get; set; }

        public virtual ICollection<Wardrobe> Wardrobes { get; set; }
    }
}
