using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public interface IOrderRepository
    {

        List<Order> GetOrder();

        Order GetOrderById(int id);

        Order Insert(Order o);

        Order Update(Order o);

        void Delete(Order o);
    }
}
