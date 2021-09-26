using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIT28g2017.Models
{
    public class OrderCreationDto
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentMethod { get; set; }
        public int TotalPrice { get; set; }
        public bool Confirmed { get; set; }
    }
}
