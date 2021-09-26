using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public class RatingRepository : IRatingRepository
    {

        private OnlineWardrobeShopContext _shopContext;

        public RatingRepository(OnlineWardrobeShopContext context)
        {
            _shopContext = context;
        }


        public List<Rating> GetRating()
        {
            return _shopContext.Ratings.ToList();
        }

        public Rating GetRatingById(int id)
        {
            return _shopContext.Ratings.Find(id);
        }

        public Rating Insert(Rating r)
        {
            _shopContext.Ratings.Add(r);
            _shopContext.SaveChanges();

            return r;
        }

        public Rating Update(Rating r)
        {
            var exist = GetRatingById(r.RatingId);
            exist.RatingId = r.RatingId;
            exist.Userr = r.Userr;
            exist.Wardrobe = r.Wardrobe;
            exist.Mark = r.Mark;
            exist.Comment = r.Comment;

            exist.UserrNavigation = r.UserrNavigation;
            exist.WardrobeNavigation = r.WardrobeNavigation;

            _shopContext.Ratings.Update(exist);
            _shopContext.SaveChanges();

            return r;
        }

        public void Delete(Rating r)
        {
            _shopContext.Ratings.Remove(r);
            _shopContext.SaveChanges();
        }
    }
}
