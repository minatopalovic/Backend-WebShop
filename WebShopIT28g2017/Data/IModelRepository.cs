using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public interface IModelRepository
    {

        List<Model> GetModel();

        Model GetModelById(int id);

        Model Insert(Model model);

        Model Update(Model model);

        void Delete(Model model);
    }
}
