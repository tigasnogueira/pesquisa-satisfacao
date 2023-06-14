using Pesquisa.SurveyApi.Context;
using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly SurveyDbContext _dbContext;

    public CustomerRepository(SurveyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public CustomerModel CreateCustomer(CustomerModel customer)
    {
        _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();

        return customer;
    }

    public IEnumerable<CustomerModel> GetCustomers()
    {
        return _dbContext.Customers.ToList();
    }

    public CustomerModel GetCustomerById(Guid customerId)
    {
        return _dbContext.Customers.FirstOrDefault(c => c.Id == customerId);
    }

    public CustomerModel GetCustomerByCnpj(string cnpj)
    {
        return _dbContext.Customers.FirstOrDefault(c => c.CNPJ == cnpj);
    }

    public IEnumerable<CustomerModel> SearchCustomersByName(string name)
    {
        return _dbContext.Customers.Where(c => c.CustomerName.Contains(name)).ToList();
    }

    public void UpdateCustomer(CustomerModel customer)
    {
        _dbContext.SaveChanges();
    }

    public void DeleteCustomer(CustomerModel customer)
    {
        _dbContext.Customers.Remove(customer);
        _dbContext.SaveChanges();
    }

    public bool IsCnpjUnique(string cnpj)
    {
        return !_dbContext.Customers.Any(c => c.CNPJ == cnpj);
    }
}
