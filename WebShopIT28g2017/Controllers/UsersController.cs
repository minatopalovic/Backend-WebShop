using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Data;
using WebShopIT28g2017.Entities;
using WebShopIT28g2017.Helpers;
using WebShopIT28g2017.Models;

namespace WebShopIT28g2017.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUserRepository _userRep;
        private readonly IMapper mapper;
        private readonly IAuthenicationHelper authenicationHelper;

        public UsersController(IUserRepository userRep, IMapper mapper, IAuthenicationHelper authenicationHelper)
        {
            _userRep = userRep;
            this.mapper = mapper;
            this.authenicationHelper = authenicationHelper;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userRep.GetUsers();
            if (users == null || users.Count == 0)
            {

                return NoContent();
            }
            return Ok(mapper.Map<List<UserDto>>(users));
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRep.GetUserById(id);

            if (user != null)
            {
                return Ok(mapper.Map<UserDto>(user));

            }
            return NotFound($"Korisnik sa id-jem: {id} ne postoji u bazi!");

        }

        [HttpGet("username")]
        public IActionResult GetUserByUserName(string username) {
            var user = _userRep.GetUserCredentialsByUserName(username);
            if (user != null)
                return Ok(mapper.Map<UserDto>(user));
            return NotFound();
        }

        [HttpPost]
        public IActionResult InsertUser(UserCreationDto userCreationDto)
        {
            //_userRep.Insert(user);

            //return Created("", user);

            var newUser = mapper.Map<User>(userCreationDto);
            var hashedPassword = authenicationHelper.HashPassword(newUser.UserPassword);
            newUser.UserPassword = hashedPassword.Item1;
            newUser.Salt = hashedPassword.Item2;
            _userRep.Insert(newUser);
            return Created("", newUser);

        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            //var existingKorisnik = _korisnikRep.GetKorisnikById(korisnik.KorisnikId);

            if (_userRep.GetUserById(user.UserId) == null)
            {
                return NotFound();
            }

            _userRep.Update(user);
            return Ok(user);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRep.GetUserById(id);

            if (user != null)
            {
                _userRep.Delete(user);
                return Ok();
            }
            return NotFound($"Korisnik sa id-jem: {id} ne postoji u bazi!");
        }
    }
}
