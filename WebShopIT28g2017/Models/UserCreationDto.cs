using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIT28g2017.Models
{
    public class UserCreationDto
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int Rolee { get; set; }
        public string UserUserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public string UserPhoneNumber { get; set; }
    }
}
