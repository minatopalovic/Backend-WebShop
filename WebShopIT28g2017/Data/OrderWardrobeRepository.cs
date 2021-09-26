using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public class OrderWardrobeRepository : IOrderWardrobeRepository
    {

        private OnlineWardrobeShopContext _shopContext;

        public OrderWardrobeRepository(OnlineWardrobeShopContext context)
        {
            _shopContext = context;
        }

        public List<OrderWardrobe> GetOW()
        {
            return _shopContext.OrderWardrobes.ToList();
        }

        public OrderWardrobe GetOWById(int id)
        {
            return _shopContext.OrderWardrobes.Find(id);
        }

        public OrderWardrobe Insert(OrderWardrobe ow)
        {
            _shopContext.OrderWardrobes.Add(ow);
            _shopContext.SaveChanges();
            return ow;
        }

        public OrderWardrobe Update(OrderWardrobe ow)
        {
            var exist = GetOWById(ow.OwId);
            exist.OwId = ow.OwId;
            exist.Orderr = ow.Orderr;
            exist.Wardrobe = ow.Wardrobe;
            exist.Quantity = ow.Quantity;

            exist.OrderrNavigation = ow.OrderrNavigation;
            exist.WardrobeNavigation = ow.WardrobeNavigation;

            _shopContext.Update(exist);
            _shopContext.SaveChanges();

            return ow;

        }

        public void Delete(OrderWardrobe ow)
        {
            _shopContext.OrderWardrobes.Remove(ow);
            _shopContext.SaveChanges();
        }
    }
}
