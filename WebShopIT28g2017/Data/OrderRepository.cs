using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public class OrderRepository : IOrderRepository
    {

        private OnlineWardrobeShopContext _shopContext;

        public OrderRepository(OnlineWardrobeShopContext context)
        {
            _shopContext = context;
        }

        public List<Order> GetOrder()
        {
            return _shopContext.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _shopContext.Orders.Find(id);
        }

        public Order Insert(Order o)
        {
            _shopContext.Orders.Add(o);
            _shopContext.SaveChanges();
            return o;
        }

        public Order Update(Order o)
        {
            var exist = GetOrderById(o.OrderId);
            exist.OrderId = o.OrderId;
            exist.UserId = o.UserId;
            exist.OrderDate = o.OrderDate;
            exist.PaymentMethod = o.PaymentMethod;
            exist.TotalPrice = o.TotalPrice;
            exist.Confirmed = o.Confirmed;

            exist.User = o.User;
            exist.OrderWardrobes = o.OrderWardrobes;

            _shopContext.Orders.Update(exist);
            _shopContext.SaveChanges();

            return o;
        }
        public void Delete(Order o)
        {

            _shopContext.Orders.Remove(o);
            _shopContext.SaveChanges();
        }
    }
}
