using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public CustomerModel CreateCustomer(CustomerModel customer)
    {
        // Coloque qualquer lógica adicional aqui, se necessário

        return _customerRepository.CreateCustomer(customer);
    }

    public IEnumerable<CustomerModel> GetCustomers()
    {
        return _customerRepository.GetCustomers();
    }

    public CustomerModel GetCustomerById(Guid customerId)
    {
        return _customerRepository.GetCustomerById(customerId);
    }

    public CustomerModel GetCustomerByCnpj(string cnpj)
    {
        return _customerRepository.GetCustomerByCnpj(cnpj);
    }

    public IEnumerable<CustomerModel> SearchCustomersByName(string name)
    {
        return _customerRepository.SearchCustomersByName(name);
    }

    public void UpdateCustomer(CustomerModel customer)
    {
        _customerRepository.UpdateCustomer(customer);
    }

    public void DeleteCustomer(CustomerModel customer)
    {
        _customerRepository.DeleteCustomer(customer);
    }

    public bool IsCnpjUnique(string cnpj)
    {
        return _customerRepository.IsCnpjUnique(cnpj);
    }
}
