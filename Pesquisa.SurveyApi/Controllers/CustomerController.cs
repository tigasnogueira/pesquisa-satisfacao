using Microsoft.AspNetCore.Mvc;
using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerService _customerService;


    public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }

    [HttpPost]
    public IActionResult CreateCustomer(CustomerModel customer)
    {
        if (!_customerService.IsCnpjUnique(customer.CNPJ))
        {
            return Conflict("CNPJ já cadastrado");
        }

        _logger.LogInformation("Creating customer {0}", customer.CustomerName);

        var createdCustomer = _customerService.CreateCustomer(customer);
        return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.Id }, createdCustomer);
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
        _logger.LogInformation("Getting all customers");

        var customers = _customerService.GetCustomers();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomerById(Guid id)
    {
        var customer = _customerService.GetCustomerById(id);

        if (customer == null)
        {
            return NotFound();
        }

        _logger.LogInformation("Getting customer {0}", customer.Id);

        return Ok(customer);
    }

    [HttpGet("search")]
    public IActionResult SearchCustomersByName(string name)
    {
        _logger.LogInformation("Searching customers by name {0}", name);

        var customers = _customerService.SearchCustomersByName(name);
        return Ok(customers);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(Guid id, CustomerModel customer)
    {
        var existingCustomer = _customerService.GetCustomerById(id);

        if (existingCustomer == null)
        {
            return NotFound();
        }

        existingCustomer.CustomerName = customer.CustomerName;
        existingCustomer.ContactName = customer.ContactName;

        _customerService.UpdateCustomer(existingCustomer);

        _logger.LogInformation("Updating customer {0}", existingCustomer.Id);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(Guid id)
    {
        var customer = _customerService.GetCustomerById(id);

        if (customer == null)
        {
            return NotFound();
        }

        _customerService.DeleteCustomer(customer);

        _logger.LogInformation("Deleting customer {0}", customer.Id);

        return NoContent();
    }
}
