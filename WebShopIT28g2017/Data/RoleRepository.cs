using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public class RoleRepository : IRoleRepository
    {

        private OnlineWardrobeShopContext _shopContext;

        public RoleRepository(OnlineWardrobeShopContext context)
        {
            _shopContext = context;

        }


        public List<Role> GetRole()
        {
            return _shopContext.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return _shopContext.Roles.Find(id);
        }

        public Role Insert(Role role)
        {
            _shopContext.Roles.Add(role);
            _shopContext.SaveChanges();
            return role;
        }

        public Role Update(Role role)
        {
            var exist = GetRoleById(role.RoleId);
            exist.RoleId = role.RoleId;
            exist.RoleName = role.RoleName;
            exist.Users = role.Users;

            _shopContext.Roles.Update(exist);
            _shopContext.SaveChanges();

            return role;
        }
        public void Delete(Role role)
        {
            _shopContext.Roles.Remove(role);
            _shopContext.SaveChanges();
        }
    }
}
