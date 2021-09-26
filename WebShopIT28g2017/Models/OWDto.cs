using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIT28g2017.Models
{
    public class OWDto
    {
        public int OwId { get; set; }

        #region Order
        public string User { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentMethod { get; set; }
        public int TotalPrice { get; set; }
        public bool Confirmed { get; set; }
        #endregion


        #region Wardrobe
        public string Model { get; set; }
        public string Category { get; set; }
        public string Material { get; set; }
        public string WardrobeColor { get; set; }
        public string WardrobeSize { get; set; }
        public int WardrobePrice { get; set; }
        public string WardrobeDescription { get; set; }
        public string WardrobePicture { get; set; }
        public string WardrobeBrand { get; set; }
        #endregion

        public int Quantity { get; set; }
    }
}
