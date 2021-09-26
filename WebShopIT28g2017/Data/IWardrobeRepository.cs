using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public interface IWardrobeRepository
    {

        List<Wardrobe> GetWardrobe();

        Wardrobe GetWardrobeById(int id);

        Wardrobe Insert(Wardrobe w);

        Wardrobe Update(Wardrobe w);

        void Delete(Wardrobe w);

    }
}
