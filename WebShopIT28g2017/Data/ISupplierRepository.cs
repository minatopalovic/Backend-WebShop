using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public interface ISupplierRepository
    {

        List<Supplier> GetSupplier();

        Supplier GetSupplierById(int id);

        Supplier Insert(Supplier s);

        Supplier Update(Supplier s);

        void Delete(Supplier s);
    }
}
