using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIT28g2017.Models
{
    public class WardrobeDto
    {
        public int WardrobeId { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public string Material { get; set; }
        public string Supplier { get; set; }
        public string WardrobeColor { get; set; }
        public string WardrobeSize { get; set; }
        public int WardrobePrice { get; set; }
        public string WardrobeDescription { get; set; }
        public string WardrobePicture { get; set; }
        public string WardrobeBrand { get; set; }
        public bool InStock { get; set; }
        public int? StockQuatity { get; set; }
    }
}
