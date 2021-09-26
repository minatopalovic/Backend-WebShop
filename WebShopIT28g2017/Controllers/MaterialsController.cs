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
    [Route("api/material")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private IMaterialRepository _materialRep;
        private readonly IMapper mapper;

        public MaterialsController(IMaterialRepository materialRep, IMapper mapper)
        {
            _materialRep = materialRep;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMaterials()
        {
            var materials = _materialRep.GetMaterial();

            if (materials == null || materials.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<MaterialDto>>(materials));
        }

        [HttpGet("{id}")]
        public IActionResult GetMaterialById(int id)
        {
            var material = _materialRep.GetMaterialById(id);

            if (material != null)
            {
                return Ok(mapper.Map<MaterialDto>(material));

            }
            return NotFound($"Materijal sa id-jem: {id} ne postoji u bazi!");

        }

        [HttpPost]
        public IActionResult InsertMaterial(Material material)
        {
            _materialRep.Insert(material);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "://" + material.MaterialId, material);

        }

        [HttpPut]
        public IActionResult UpdateMaterial(Material material)
        {

            if (_materialRep.GetMaterialById(material.MaterialId) == null)
            {
                return NotFound();
            }

            _materialRep.Update(material);
            return Ok(material);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMaterial(int id)
        {
            var material = _materialRep.GetMaterialById(id);

            if (material != null)
            {
                _materialRep.Delete(material);
                return Ok();
            }
            return NotFound($"Materijal sa id-jem: {id} ne postoji u bazi!");
        }
    }
}
