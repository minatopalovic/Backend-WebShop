using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public interface IRoleRepository
    {

        List<Role> GetRole();

        Role GetRoleById(int id);

        Role Insert(Role role);

        Role Update(Role role);

        void Delete(Role role);
    }
}
