using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Data;
using WebShopIT28g2017.Entities;
using WebShopIT28g2017.Models;

namespace WebShopIT28g2017.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private ICategoryRepository _categoryRep;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public CategorysController(ICategoryRepository categoryRep, LinkGenerator linkGenerator, IMapper mapper)
        {
            _categoryRep = categoryRep;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategorys()
        {
            var categorys = _categoryRep.GetCategory();

            if (categorys == null || categorys.Count == 0)
            {
                return NoContent();
            }
            return Ok(_mapper.Map<List<CategoryDto>>(categorys));
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryRep.GetCategoryById(id);

            if (category != null)
            {
                return Ok(category);

            }
            return NotFound($"Kategorija sa id-jem: {id} ne postoji u bazi!");

        }

        [HttpPost]
        public IActionResult InsertCategory(Category category)
        {
            Category c = _categoryRep.Insert(category);
            string location = _linkGenerator.GetPathByAction("GetCategoryById", "Categorys", new { ID = c.CategoryId });
            return Created(location, c);

        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {

            if (_categoryRep.GetCategoryById(category.CategoryId) == null)
            {
                return NotFound();
            }

            _categoryRep.Update(category);
            return Ok(category);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryRep.GetCategoryById(id);

            if (category != null)
            {
                _categoryRep.Delete(category);
                return Ok();
            }
            return NotFound($"Kategorija sa id-jem: {id} ne postoji u bazi!");
        }
    }
}
