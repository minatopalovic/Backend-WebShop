using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public interface ICategoryRepository
    {
        List<Category> GetCategory();

        Category GetCategoryById(int id);

        Category Insert(Category category);

        Category Update(Category category);

        void Delete(Category category);
    }
}
