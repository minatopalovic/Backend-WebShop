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
using WebShopIT28g2017.Models;

namespace WebShopIT28g2017.Controllers
{
    [Route("api/wardrobe")]
    [ApiController]
    public class WardrobesController : ControllerBase
    {

        IWardrobeRepository _wardrobeRep;
        private readonly IMapper mapper;

        public WardrobesController(IWardrobeRepository wardrobeRepository, IMapper mapper)
        {
            _wardrobeRep = wardrobeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "1, 2")]
        public IActionResult GetWprdrobes()
        {
            var wardrobes = _wardrobeRep.GetWardrobe();

            if (wardrobes == null || wardrobes.Count == 0)
            {

                return NoContent();
            }
            return Ok(mapper.Map<List<WardrobeDto>>(wardrobes));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1, 2")]
        public IActionResult GetWardrobeById(int id)
        {
            Wardrobe wardrobe = _wardrobeRep.GetWardrobeById(id);

            if (wardrobe != null)
            {
                return Ok(mapper.Map<WardrobeDto>(wardrobe));

            }
            return NotFound($"Odeca sa id-jem: {id} ne postoji u bazi!");

        }

        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult InsertWardrobe(WardrobeCreationDto wardrobeCreation)
        {
            _wardrobeRep.Insert(mapper.Map<Wardrobe>(wardrobeCreation));
            return Created("", mapper.Map<Wardrobe>(wardrobeCreation));

        }

        [HttpPut]
        [Authorize(Roles = "2")]
        public IActionResult UpdateWardrobe(WardrobeUpdateDto wardrobeDto)
        {

            if (_wardrobeRep.GetWardrobeById(wardrobeDto.WardrobeId) == null)
            {
                return NotFound();
            }

            _wardrobeRep.Update(mapper.Map<Wardrobe>(wardrobeDto));
            return Ok(mapper.Map<Wardrobe>(wardrobeDto));

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "2")]
        public IActionResult DeleteWardrobe(int id)
        {
            var wardrobe = _wardrobeRep.GetWardrobeById(id);

            if (wardrobe != null)
            {
                _wardrobeRep.Delete(wardrobe);
                return Ok();
            }
            return NotFound($"Odeca sa id-jem: {id} ne postoji u bazi!");
        }
    }
}
