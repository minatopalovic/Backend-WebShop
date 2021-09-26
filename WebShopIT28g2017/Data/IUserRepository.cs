using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public interface IUserRepository
    {
        List<User> GetUsers();

        User GetUserById(int id);

        User Insert(User user);

        User Update(User user);

        void Delete(User user);

        //public bool UserWithCredentialsExists(string username, string password);
        User GetUserCredentialsByUserName(string username);
    }
}
