using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tosedev.Core;

namespace Tosedev.Order.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Get()
        {
            List<Customer> liste = new List<Customer>();
            liste = _customerService.Get();
            return Ok(liste);
        }
        [HttpGet("{id}")]
        public IActionResult get(Guid id)
        {
            var customer = _customerService.get(id);
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult Create(Customer entity)
        {
            var result = _customerService.Create(entity);
            return Created(String.Empty, result);
        }
        [HttpPut]
        public IActionResult Update(Customer entity)
        {
            var result = _customerService.Update(entity);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _customerService.Delete(id);
            return NoContent();
        }
    }
}
