using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIT28g2017.Models
{
    public class OrderWardrobeCreationDto
    {
        public int orderId { get; set; }
        public int wardrobeId { get; set; }
        public int quantity { get; set; }
    }
}
