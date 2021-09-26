using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopIT28g2017.Entities
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Ratings = new HashSet<Rating>();
        }

        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int Rolee { get; set; }
        public string UserUserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public string UserPhoneNumber { get; set; }
        public string Salt { get; set; }

        public virtual Role RoleeNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
