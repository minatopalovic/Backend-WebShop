using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIT28g2017.Models
{
    public class Principal
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int Rolee { get; set; }

        public string Salt { get; set; }
    }
}
