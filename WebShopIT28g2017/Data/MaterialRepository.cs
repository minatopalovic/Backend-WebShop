using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public class MaterialRepository : IMaterialRepository
    {

        private OnlineWardrobeShopContext _shopContext;

        public MaterialRepository(OnlineWardrobeShopContext context)
        {
            _shopContext = context;
        }

        public List<Material> GetMaterial()
        {
            return _shopContext.Materials.ToList();
        }

        public Material GetMaterialById(int id)
        {
            var m = _shopContext.Materials.Find(id);
            return m;
        }

        public Material Insert(Material material)
        {
            _shopContext.Materials.Add(material);
            _shopContext.SaveChanges();
            return material;
        }

        public Material Update(Material material)
        {
            var exist = GetMaterialById(material.MaterialId);
            exist.MaterialId = material.MaterialId;
            exist.MaterialName = material.MaterialName;
            exist.Wardrobes = material.Wardrobes;

            _shopContext.Materials.Update(exist);
            _shopContext.SaveChanges();

            return material;
        }
        public void Delete(Material material)
        {
            _shopContext.Materials.Remove(material);
            _shopContext.SaveChanges();
        }
    }
}
