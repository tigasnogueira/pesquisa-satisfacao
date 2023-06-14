namespace Pesquisa.SurveyApi.ViewModels;

public class CustomerViewModel
{
    public string CustomerName { get; set; }
    public string ContactName { get; set; }
    public string CNPJ { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Notes { get; set; }
    public DateTime BecameCustomerDate { get; set; }
    public string Category { get; set; }
    public DateTime LastEvaluationDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
