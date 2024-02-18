using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Abstractions;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {        
        [HttpGet("{id:long}")]   
        public IActionResult GetCustomerAsync([FromRoute] long id)
        {
            if (!_customersDict.TryGetValue(id, out Customer value))
                return NotFound();

            return Ok(value);
        }

        [HttpGet("all")]
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customersDict.Values;
        }

        [HttpPost("create")]
        public IActionResult CreateCustomer([FromBody] CustomerCreateRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request");

            if (_customersDict.TryGetValue(request.Id, out Customer value))
                return Conflict($"User with id {request.Id} already exists");

            var newCustomer = new Customer
            {
                Id = request.Id,
                Firstname = request.Firstname,
                Lastname = request.Lastname
            };
            _customersDict[request.Id] = newCustomer;

            return Ok(newCustomer);
        }

        // словарь клиентов (id клиента -> экземпляр клиента Customer) 
        private static Dictionary<long, Customer> _customersDict = new Dictionary<long, Customer>();
    }
}