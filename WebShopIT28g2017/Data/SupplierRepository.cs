using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public class SupplierRepository : ISupplierRepository
    {

        private OnlineWardrobeShopContext _shopContext;

        public SupplierRepository(OnlineWardrobeShopContext context)
        {
            _shopContext = context;
        }


        public List<Supplier> GetSupplier()
        {
            return _shopContext.Suppliers.ToList();
        }

        public Supplier GetSupplierById(int id)
        {
            return _shopContext.Suppliers.Find(id);
        }

        public Supplier Insert(Supplier s)
        {
            _shopContext.Suppliers.Add(s);
            _shopContext.SaveChanges();
            return s;
        }

        public Supplier Update(Supplier s)
        {
            var exist = GetSupplierById(s.SupplierId);
            exist.SupplierId = s.SupplierId;
            exist.SupplierName = s.SupplierName;
            exist.SupplierEmail = s.SupplierEmail;
            exist.SupplierAddress = s.SupplierAddress;
            exist.SupplierPhoneNumber = s.SupplierPhoneNumber;

            exist.Wardrobes = s.Wardrobes;

            _shopContext.Suppliers.Update(exist);
            _shopContext.SaveChanges();

            return s;
        }
        public void Delete(Supplier s)
        {
            _shopContext.Suppliers.Remove(s);
            _shopContext.SaveChanges();
        }
    }
}
