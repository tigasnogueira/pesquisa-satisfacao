using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Services;

public class CustomerService : ICustomerService
{
    private readonly ILogger<CustomerService> _logger;
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ILogger<CustomerService> logger, ICustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }

    public CustomerModel CreateCustomer(CustomerModel customer)
    {
        _logger.LogInformation("Creating customer");

        return _customerRepository.CreateCustomer(customer);
    }

    public IEnumerable<CustomerModel> GetCustomers()
    {
        _logger.LogInformation("Getting customers");

        return _customerRepository.GetCustomers();
    }

    public CustomerModel GetCustomerById(Guid customerId)
    {
        _logger.LogInformation("Getting customer by id");

        return _customerRepository.GetCustomerById(customerId);
    }

    public CustomerModel GetCustomerByCnpj(string cnpj)
    {
        _logger.LogInformation("Getting customer by cnpj");

        return _customerRepository.GetCustomerByCnpj(cnpj);
    }

    public IEnumerable<CustomerModel> SearchCustomersByName(string name)
    {
        _logger.LogInformation("Searching customers by name");

        return _customerRepository.SearchCustomersByName(name);
    }

    public void UpdateCustomer(CustomerModel customer)
    {
        _logger.LogInformation("Updating customer");

        _customerRepository.UpdateCustomer(customer);
    }

    public void DeleteCustomer(CustomerModel customer)
    {
        _logger.LogInformation("Deleting customer");

        _customerRepository.DeleteCustomer(customer);
    }

    public bool IsCnpjUnique(string cnpj)
    {
        _logger.LogInformation("Checking if cnpj is unique");

        return _customerRepository.IsCnpjUnique(cnpj);
    }
}
