using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopIT28g2017.Entities
{
    public partial class Supplier
    {
        public Supplier()
        {
            Wardrobes = new HashSet<Wardrobe>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhoneNumber { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierAddress { get; set; }

        public virtual ICollection<Wardrobe> Wardrobes { get; set; }
    }
}
