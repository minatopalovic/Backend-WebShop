using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public class ModelRepository : IModelRepository
    {

        private OnlineWardrobeShopContext _shopContext;

        public ModelRepository(OnlineWardrobeShopContext context)
        {
            _shopContext = context;
        }


        public List<Model> GetModel()
        {
            return _shopContext.Models.ToList();
        }

        public Model GetModelById(int id)
        {
            return _shopContext.Models.Find(id);
        }

        public Model Insert(Model model)
        {
            _shopContext.Models.Add(model);
            _shopContext.SaveChanges();
            return model;
        }

        public Model Update(Model model)
        {
            var exist = GetModelById(model.ModelId);
            exist.ModelId = model.ModelId;
            exist.ModelName = model.ModelName;
            exist.Wardrobes = model.Wardrobes;

            _shopContext.Models.Update(exist);
            _shopContext.SaveChanges();

            return model;
        }
        public void Delete(Model model)
        {
            _shopContext.Models.Remove(model);
            _shopContext.SaveChanges();
        }
    }
}
