using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public class CategoryRepository : ICategoryRepository
    {

        OnlineWardrobeShopContext _catContext;

        public CategoryRepository(OnlineWardrobeShopContext context)
        {
            _catContext = context;
        }


        public List<Category> GetCategory()
        {
            return _catContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            var c = _catContext.Categories.Find(id);
            return c;
        }

        public Category Insert(Category category)
        {

            _catContext.Categories.Add(category);
            _catContext.SaveChanges();
            return category;

        }

        public Category Update(Category category)
        {
            var existing = GetCategoryById(category.CategoryId);
            existing.CategoryId = category.CategoryId;
            existing.CategoryName = category.CategoryName;
            existing.Wardrobes = category.Wardrobes;

            _catContext.Categories.Update(existing);
            _catContext.SaveChanges();

            return category;
        }
        public void Delete(Category category)
        {
            _catContext.Categories.Remove(category);
            _catContext.SaveChanges();
        }
    }
}
