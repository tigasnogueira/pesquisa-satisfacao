using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Interfaces;

public interface ICustomerRepository
{
    CustomerModel CreateCustomer(CustomerModel customer);
    IEnumerable<CustomerModel> GetCustomers();
    CustomerModel GetCustomerById(Guid customerId);
    CustomerModel GetCustomerByCnpj(string cnpj);
    IEnumerable<CustomerModel> SearchCustomersByName(string name);
    void UpdateCustomer(CustomerModel customer);
    void DeleteCustomer(CustomerModel customer);
    bool IsCnpjUnique(string cnpj);
}
