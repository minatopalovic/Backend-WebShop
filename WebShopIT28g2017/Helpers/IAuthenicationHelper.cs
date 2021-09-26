using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Models;

namespace WebShopIT28g2017.Helpers
{
    public interface IAuthenicationHelper
    {
        public bool AuthenticatePrincipal(Credentials credentials);

        Tuple<string, string> HashPassword(string password);

        string HashPassword(string password, string salt);

        bool SlowEquals(string hashedPassword1, string hashedPassword2);

        public string GenerateJwt(Principal principal);

    }
}
