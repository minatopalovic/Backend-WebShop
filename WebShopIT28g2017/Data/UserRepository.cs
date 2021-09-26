using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Data
{
    public class UserRepository : IUserRepository
    {

        private OnlineWardrobeShopContext _shopContext;
        //private readonly static int iterations = 1000;

        public UserRepository(OnlineWardrobeShopContext shopContext)
        {
            _shopContext = shopContext;
        }


        public List<User> GetUsers()
        {
            return _shopContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            var user = _shopContext.Users.Find(id);
            return user;
        }

        public User Insert(User user)
        {
            _shopContext.Users.Add(user);
            _shopContext.SaveChanges();
            return user;
        }

        public User Update(User user)
        {
            var existingUser = GetUserById(user.UserId);
            existingUser.UserId = user.UserId;
            existingUser.UserFirstName = user.UserFirstName;
            existingUser.UserLastName = user.UserLastName;
            existingUser.Rolee = user.Rolee;
            existingUser.UserUserName = user.UserUserName;
            existingUser.UserPassword = user.UserPassword;
            existingUser.UserEmail = user.UserEmail;
            existingUser.UserAddress = user.UserAddress;
            existingUser.UserPhoneNumber = user.UserPhoneNumber;
            existingUser.RoleeNavigation = user.RoleeNavigation;
            existingUser.Ratings = user.Ratings;

            _shopContext.Users.Update(existingUser);
            _shopContext.SaveChanges();

            return user;
        }

        public void Delete(User user)
        {
            _shopContext.Users.Remove(user);
            _shopContext.SaveChanges();
        }

       

        public User GetUserCredentialsByUserName(string username)
        {
            return _shopContext.Users.Where(u => u.UserUserName == username).FirstOrDefault();
        }
    }
}
