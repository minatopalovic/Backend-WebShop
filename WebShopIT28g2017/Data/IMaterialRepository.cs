using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public interface IMaterialRepository
    {

        List<Material> GetMaterial();

        Material GetMaterialById(int id);

        Material Insert(Material material);

        Material Update(Material material);

        void Delete(Material material);
    }
}
