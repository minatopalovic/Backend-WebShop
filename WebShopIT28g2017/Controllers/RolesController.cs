using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Data;
using WebShopIT28g2017.Entities;
using WebShopIT28g2017.Models;

namespace WebShopIT28g2017.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        IRoleRepository _roleRep;
        private readonly IMapper mapper;

        public RolesController(IRoleRepository roleRep, IMapper mapper)
        {
            _roleRep = roleRep;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleRep.GetRole();

            if (roles == null || roles.Count == 0)
            {

                return NoContent();
            }

            return Ok(mapper.Map<List<RoleDto>>(roles));
        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            var role = _roleRep.GetRoleById(id);

            if (role != null)
            {
                return Ok(mapper.Map<RoleDto>(role));

            }
            return NotFound($"Uloga sa id-jem: {id} ne postoji u bazi!");

        }

        [HttpPost]
        public IActionResult InsertRole(Role role)
        {
            _roleRep.Insert(role);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "://" + role.RoleId, role);

        }

        [HttpPut]
        public IActionResult UpdateRole(Role role)
        {

            if (_roleRep.GetRoleById(role.RoleId) == null)
            {
                return NotFound();
            }

            _roleRep.Update(role);
            return Ok(role);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _roleRep.GetRoleById(id);

            if (role != null)
            {
                _roleRep.Delete(role);
                return Ok();
            }
            return NotFound($"Uloga sa id-jem: {id} ne postoji u bazi!");
        }
    }
}
