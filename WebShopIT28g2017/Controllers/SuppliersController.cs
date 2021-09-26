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
    [Route("api/supplier")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {

        ISupplierRepository _supplierRep;
        private readonly IMapper mapper;

        public SuppliersController(ISupplierRepository rep, IMapper mapper)
        {
            _supplierRep = rep;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSuppliers()
        {
            var suppliers = _supplierRep.GetSupplier();
            if (suppliers == null || suppliers.Count == 0)
            {

                return NoContent();
            }
            return Ok(mapper.Map<List<SupplierDto>>(suppliers));
        }

        [HttpGet("{id}")]
        public IActionResult GetSupplierById(int id)
        {
            var supplier = _supplierRep.GetSupplierById(id);

            if (supplier != null)
            {
                return Ok(mapper.Map<SupplierDto>(supplier));

            }
            return NotFound($"Dobavljac sa id-jem: {id} ne postoji u bazi!");

        }

        [HttpPost]
        public IActionResult InsertSupplier(Supplier supplier)
        {
            _supplierRep.Insert(supplier);
            return Created("", supplier);

        }

        [HttpPut]
        public IActionResult UpdateSupplier(Supplier supplier)
        {

            if (_supplierRep.GetSupplierById(supplier.SupplierId) == null)
            {
                return NotFound();
            }

            _supplierRep.Update(supplier);
            return Ok(supplier);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            var supplier = _supplierRep.GetSupplierById(id);

            if (supplier != null)
            {
                _supplierRep.Delete(supplier);
                return Ok();
            }
            return NotFound($"Dobavljac sa id-jem: {id} ne postoji u bazi!");
        }
    }
}
