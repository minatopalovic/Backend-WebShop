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
    [Route("api/orderwardrobe")]
    [ApiController]
    public class OrderWardrobesController : ControllerBase
    {

        IOrderWardrobeRepository _owRep;
        private readonly IMapper mapper;

        public OrderWardrobesController(IOrderWardrobeRepository orderWardrobeRepository, IMapper mapper)
        {
            _owRep = orderWardrobeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOWs()
        {
            var ows = _owRep.GetOW();

            if (ows == null || ows.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<OWDto>>(ows));
            //return Ok(ows);
        }

        [HttpGet("{id}")]
        public IActionResult GetOWById(int id)
        {
            var ow = _owRep.GetOWById(id);

            if (ow != null)
            {
                return Ok(mapper.Map<OWDto>(ow));

            }
            return NotFound($"Porucena garderba sa id-jem: {id} ne postoji u bazi!");

        }

        [HttpPost]
        public IActionResult InsertOW(OrderWardrobeCreationDto owDto)
        {
            _owRep.Insert(mapper.Map<OrderWardrobe>(owDto));
            return Created("", mapper.Map<OrderWardrobe>(owDto));

        }

        [HttpPut]
        public IActionResult UpdateOW(OrderWardrobe ow)
        {

            if (_owRep.GetOWById(ow.OwId) == null)
            {
                return NotFound();
            }

            _owRep.Update(ow);
            return Ok(ow);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOW(int id)
        {
            var ow = _owRep.GetOWById(id);

            if (ow != null)
            {
                _owRep.Delete(ow);
                return Ok();
            }
            return NotFound($"Porucena garderoba sa id-jem: {id} ne postoji u bazi!");
        }
    }
}
