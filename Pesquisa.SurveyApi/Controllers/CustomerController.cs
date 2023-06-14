using Microsoft.AspNetCore.Mvc;
using Pesquisa.SurveyApi.Models;
using Pesquisa.SurveyApi.Services;

namespace Pesquisa.SurveyApi.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public IActionResult CreateCustomer(CustomerModel customer)
    {
        if (!_customerService.IsCnpjUnique(customer.CNPJ))
        {
            return Conflict("CNPJ já cadastrado");
        }

        var createdCustomer = _customerService.CreateCustomer(customer);
        return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.Id }, createdCustomer);
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
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

        return Ok(customer);
    }

    [HttpGet("search")]
    public IActionResult SearchCustomersByName(string name)
    {
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

        return NoContent();
    }
}
