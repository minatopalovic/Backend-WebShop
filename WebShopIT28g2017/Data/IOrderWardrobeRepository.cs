using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public interface IOrderWardrobeRepository
    {

        List<OrderWardrobe> GetOW();

        OrderWardrobe GetOWById(int id);

        OrderWardrobe Insert(OrderWardrobe ow);

        OrderWardrobe Update(OrderWardrobe ow);

        void Delete(OrderWardrobe ow);
    }
}
