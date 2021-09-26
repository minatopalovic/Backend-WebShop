using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebShopIT28g2017.Data;
using WebShopIT28g2017.Models;

namespace WebShopIT28g2017.Helpers
{
    public class AuthenicationHelper : IAuthenicationHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthenicationHelper(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }


        public bool AuthenticatePrincipal(Credentials credentials)
        {
            var p = _userRepository.GetUserCredentialsByUserName(credentials.Username);
            if (p == null)
                return false;
            //return credentials.Password == p.UserPassword;
            return SlowEquals(p.UserPassword, HashPassword(credentials.Password, p.Salt));
        }


        public string GenerateJwt(Principal principal)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim("role", principal.Rolee.ToString())
            };


            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                             _configuration["Jwt:Issuer"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(120),
                                             signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        

        public Tuple<string, string> HashPassword(string password)
        {
            var sBytes = new byte[256];
            new RNGCryptoServiceProvider().GetNonZeroBytes(sBytes);
            var salt = Convert.ToBase64String(sBytes);
            var derivedBytes = new Rfc2898DeriveBytes(password, sBytes);
            return new Tuple<string, string>
            (
                Convert.ToBase64String(derivedBytes.GetBytes(256)),
                salt
            );
        }

        public string HashPassword(string password, string salt)
        {
            var sBytes = Convert.FromBase64String(salt);
            var derivedBytes = new Rfc2898DeriveBytes(password, sBytes);
            return Convert.ToBase64String(derivedBytes.GetBytes(256));
        }

        public bool SlowEquals(string hashedPassword1, string hashedPassword2)
        {
            byte[] a = Convert.FromBase64String(hashedPassword1);
            byte[] b = Convert.FromBase64String(hashedPassword2);
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
    }
}
