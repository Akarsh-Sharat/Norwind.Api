using Microsoft.AspNetCore.Mvc;
using Norwind.Api.Domain.Entities.Interfaces;

namespace Norwind.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomersController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }


        [HttpGet("GetCustomers")]
        public IActionResult GetCustomers()
        {
            var customers = _customerRepo.GetCustomer();
            return Ok(customers);
        }



        [HttpGet("GetCustomerById/{customerId}")]
        public IActionResult GetCustomerById(string customerId)
        {
            var customer = _customerRepo.GetCustomerById(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }



        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer cannot be null.");
            }

            var result = _customerRepo.AddCustomer(customer);
            if (result)
            {
                return CreatedAtAction(nameof(GetCustomerById), new { customerId = customer.CustomerId }, customer);
            }

            return BadRequest("Failed to add customer.");
        }



        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer cannot be null.");
            }

            var result = _customerRepo.UpdateCustomer(customer);
            if (result)
            {
                return Ok("Customer updated successfully.");
            }

            return NotFound("Customer not found.");
        }



        [HttpDelete("DeleteCustomer/{customerId}")]
        public IActionResult DeleteCustomer(string customerId)
        {
            var result = _customerRepo.DeleteCustomer(customerId);
            if (result)
            {
                return Ok("Customer deleted successfully.");
            }

            return NotFound("Customer not found.");
        }
    }
}
