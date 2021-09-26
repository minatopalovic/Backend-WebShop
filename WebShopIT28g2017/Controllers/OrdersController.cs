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
    [Route("api/order")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        IOrderRepository _orderRep;
        private readonly IMapper mapper;

        public OrdersController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRep = orderRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderRep.GetOrder();

            if (orders == null || orders.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<OrderDto>>(orders));
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderRep.GetOrderById(id);

            if (order != null)
            {
                return Ok(mapper.Map<OrderDto>(order));

            }
            return NotFound($"Narudzbina sa id-jem: {id} ne postoji u bazi!");

        }

        [HttpPost]
        public IActionResult InsertOrder(OrderCreationDto orderDto)
        {
            Order order =_orderRep.Insert(mapper.Map<Order>(orderDto));
            return Created("", order);

        }

        [HttpPut]
        public IActionResult UpdateOrder(Order order)
        {

            if (_orderRep.GetOrderById(order.OrderId) == null)
            {
                return NotFound();
            }

            _orderRep.Update(order);
            return Ok(order);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _orderRep.GetOrderById(id);

            if (order != null)
            {
                _orderRep.Delete(order);
                return Ok();
            }
            return NotFound($"Narudzbina sa id-jem: {id} ne postoji u bazi!");
        }
    }
}
