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
    [Route("api/model")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        IModelRepository _modelRep;
        private readonly IMapper mapper;

        public ModelsController(IModelRepository modelRep, IMapper mapper)
        {
            _modelRep = modelRep;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetModels()
        {
            var models = _modelRep.GetModel();

            if (models == null || models.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<ModelDto>>(models));
        }

        [HttpGet("{id}")]
        public IActionResult GetModelById(int id)
        {
            var model = _modelRep.GetModelById(id);

            if (model != null)
            {
                return Ok(mapper.Map<ModelDto>(model));

            }
            return NotFound($"Model sa id-jem: {id} ne postoji u bazi!");

        }

        [HttpPost]
        public IActionResult InsertModel(Model model)
        {
            _modelRep.Insert(model);
            return Created("", model);

        }

        [HttpPut]
        public IActionResult UpdateModel(Model model)
        {

            if (_modelRep.GetModelById(model.ModelId) == null)
            {
                return NotFound();
            }

            _modelRep.Update(model);
            return Ok(model);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteModel(int id)
        {
            var model = _modelRep.GetModelById(id);

            if (model != null)
            {
                _modelRep.Delete(model);
                return Ok();
            }
            return NotFound($"Model sa id-jem: {id} ne postoji u bazi!");
        }
    }
}
