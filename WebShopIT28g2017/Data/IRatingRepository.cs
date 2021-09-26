using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public interface IRatingRepository
    {

        List<Rating> GetRating();

        Rating GetRatingById(int id);

        Rating Insert(Rating r);

        Rating Update(Rating r);

        void Delete(Rating r);
    }
}
