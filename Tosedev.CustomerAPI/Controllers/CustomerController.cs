using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tosedev.Core;
using Tosedev.Models;

namespace Tosedev.CustomerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public IActionResult Get()
        {

            List<Customer> customerList = new List<Customer>();
            customerList = _customerService.Get();

            return Ok(customerList);
        }
        [HttpGet("{id}")]
        public IActionResult Validate(Guid id)
        {

            return Ok(Validate(id));
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
