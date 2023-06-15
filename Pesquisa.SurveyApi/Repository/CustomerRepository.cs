using Pesquisa.SurveyApi.Context;
using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly ILogger<CustomerRepository> _logger;
    private readonly SurveyDbContext _dbContext;

    public CustomerRepository(ILogger<CustomerRepository> logger, SurveyDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public CustomerModel CreateCustomer(CustomerModel customer)
    {
        _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();

        _logger.LogInformation($"Customer {customer.CustomerName} created with id {customer.Id}");

        return customer;
    }

    public IEnumerable<CustomerModel> GetCustomers()
    {
        _logger.LogInformation("Getting all customers");

        return _dbContext.Customers.ToList();
    }

    public CustomerModel GetCustomerById(Guid customerId)
    {
        _logger.LogInformation($"Getting customer with id {customerId}");

        return _dbContext.Customers.FirstOrDefault(c => c.Id == customerId);
    }

    public CustomerModel GetCustomerByCnpj(string cnpj)
    {
        _logger.LogInformation($"Getting customer with cnpj {cnpj}");

        return _dbContext.Customers.FirstOrDefault(c => c.CNPJ == cnpj);
    }

    public IEnumerable<CustomerModel> SearchCustomersByName(string name)
    {
        _logger.LogInformation($"Searching customers with name {name}");

        return _dbContext.Customers.Where(c => c.CustomerName.Contains(name)).ToList();
    }

    public void UpdateCustomer(CustomerModel customer)
    {
        _logger.LogInformation($"Updating customer with id {customer.Id}");

        _dbContext.SaveChanges();
    }

    public void DeleteCustomer(CustomerModel customer)
    {
        _logger.LogInformation($"Deleting customer with id {customer.Id}");

        _dbContext.Customers.Remove(customer);
        _dbContext.SaveChanges();
    }

    public bool IsCnpjUnique(string cnpj)
    {
        _logger.LogInformation($"Checking if cnpj {cnpj} is unique");

        return !_dbContext.Customers.Any(c => c.CNPJ == cnpj);
    }
}
