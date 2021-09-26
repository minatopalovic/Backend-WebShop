using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopIT28g2017.Entities
{
    public partial class Model
    {
        public Model()
        {
            Wardrobes = new HashSet<Wardrobe>();
        }

        public int ModelId { get; set; }
        public string ModelName { get; set; }

        public virtual ICollection<Wardrobe> Wardrobes { get; set; }
    }
}
