using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public class WardrobeRepository : IWardrobeRepository
    {

        private OnlineWardrobeShopContext _shopContext;

        public WardrobeRepository(OnlineWardrobeShopContext context)
        {
            _shopContext = context;
        }


        public List<Wardrobe> GetWardrobe()
        {
            return _shopContext.Wardrobes.ToList();
        }

        public Wardrobe GetWardrobeById(int id)
        {
            return _shopContext.Wardrobes.Find(id);
        }

        public Wardrobe Insert(Wardrobe w)
        {
            _shopContext.Add(w);
            _shopContext.SaveChanges();
            return w;
        }

        public Wardrobe Update(Wardrobe w)
        {
            var exist = GetWardrobeById(w.WardrobeId);
            exist.WardrobeId = w.WardrobeId;
            //exist.ModelId = w.ModelId;
            //exist.CategoryId = w.CategoryId;
            //exist.MaterialId = w.MaterialId;
            //exist.SupplierId = w.SupplierId;
            exist.WardrobeColor = w.WardrobeColor;
            exist.WardrobeSize = w.WardrobeSize;
            exist.WardrobePrice = w.WardrobePrice;
            exist.WardrobeDescription = w.WardrobeDescription;
            exist.WardrobePicture = w.WardrobePicture;
            exist.WardrobeBrand = w.WardrobeBrand;
            exist.InStock = w.InStock;
            exist.StockQuatity = w.StockQuatity;

            exist.Category = w.Category;
            exist.Material = w.Material;
            exist.Model = w.Model;
            exist.Supplier = w.Supplier;
            exist.OrderWardrobes = w.OrderWardrobes;
            exist.Ratings = w.Ratings;

            _shopContext.Wardrobes.Update(exist);
            _shopContext.SaveChanges();

            return w;
        }
        public void Delete(Wardrobe w)
        {
            _shopContext.Wardrobes.Remove(w);
            _shopContext.SaveChanges();
        }
    }
}
