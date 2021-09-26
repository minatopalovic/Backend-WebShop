using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Data;
using WebShopIT28g2017.Helpers;
using WebShopIT28g2017.Models;

namespace WebShopIT28g2017.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenicationHelper helper;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public AuthController(IAuthenicationHelper helper, IMapper mapper, IUserRepository userRepository)
        {
            this.helper = helper;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [Route("auth")]
        public IActionResult Auth(Credentials credentials) 
        {
            if (helper.AuthenticatePrincipal(credentials)) {

                var tokenString = helper.GenerateJwt(mapper.Map<Principal>(userRepository.GetUserCredentialsByUserName(credentials.Username)));
                return Ok(new { token = tokenString });
            }
            return Unauthorized();
        }
    }
}
