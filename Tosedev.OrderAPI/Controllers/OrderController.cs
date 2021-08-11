using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tosedev.Core;
using Tosedev.Models;

namespace Tosedev.OrderAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public IActionResult Get()
        {

            List<Order> orderList = new List<Order>();
            orderList = _orderService.Get();
            
            return Ok(orderList);
        }
        [HttpGet("{id}")]
        public IActionResult orderGet(Guid id)
        {

            List<Order> orderList = new List<Order>();
            orderList = _orderService.orderGet(id);

            return Ok(orderList);
        }
        [HttpGet("{id}")]
        public IActionResult get(Guid id)
        {
            var order = _orderService.get(id);
            return Ok(order);
        }
        [HttpPost]
        public IActionResult Create(Order entity)
        {
            var result = _orderService.Create(entity);
            return Created(String.Empty, result);
        }
        [HttpPut]
        public IActionResult Update(Order entity)
        {
            var result = _orderService.Update(entity);
            return NoContent();
        }
        [HttpPut("{id},{status}")]
        public IActionResult ChangeStatus(Guid id, string status)
        {
            var result = _orderService.ChangeStatus(id,status);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _orderService.Delete(id);
            return NoContent();
        }
    }
}
