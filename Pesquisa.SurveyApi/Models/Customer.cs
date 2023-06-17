using Pesquisa.Core.Models;

namespace Pesquisa.SurveyApi.Models;

public class CustomerModel : EntityModel
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

    // Propriedade de navegação para relacionar avaliações a um cliente
    public ICollection<EvaluationModel> Evaluations { get; set; }

    public CustomerModel()
    {
        Evaluations = new List<EvaluationModel>(); // Inicializa a coleção
        IsActive = true;
    }

    public void Activate()
    {
        IsActive = true;
        UpdatedAt = DateTime.Now;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.Now;
    }

    public void Update(CustomerModel customer)
    {
        CustomerName = customer.CustomerName;
        ContactName = customer.ContactName;
        CNPJ = customer.CNPJ;
        Email = customer.Email;
        Phone = customer.Phone;
        Address = customer.Address;
        City = customer.City;
        State = customer.State;
        PostalCode = customer.PostalCode;
        Country = customer.Country;
        Notes = customer.Notes;
        BecameCustomerDate = customer.BecameCustomerDate;
        Category = customer.Category;
        LastEvaluationDate = customer.LastEvaluationDate;
        UpdatedAt = DateTime.Now;
    }

    public void Delete()
    {
        IsActive = false;
        UpdatedAt = DateTime.Now;
    }

    public void Restore()
    {
        IsActive = true;
        UpdatedAt = DateTime.Now;
    }

    public void AddEvaluation(EvaluationModel evaluation)
    {
        Evaluations.Add(evaluation);
        UpdatedAt = DateTime.Now;
    }

    public void RemoveEvaluation(EvaluationModel evaluation)
    {
        Evaluations.Remove(evaluation);
        UpdatedAt = DateTime.Now;
    }

    public void UpdateEvaluation(EvaluationModel evaluation)
    {
        var evaluationToUpdate = Evaluations.FirstOrDefault(e => e.Id == evaluation.Id);
        if (evaluationToUpdate != null)
        {
            evaluationToUpdate.Update(evaluation);
            UpdatedAt = DateTime.Now;
        }
    }

    public void AddOrUpdateEvaluation(EvaluationModel evaluation)
    {
        var evaluationToUpdate = Evaluations.FirstOrDefault(e => e.Id == evaluation.Id);
        if (evaluationToUpdate != null)
        {
            evaluationToUpdate.Update(evaluation);
            UpdatedAt = DateTime.Now;
        }
        else
        {
            Evaluations.Add(evaluation);
            UpdatedAt = DateTime.Now;
        }
    }

    public void AddOrUpdateEvaluations(IEnumerable<EvaluationModel> evaluations)
    {
        foreach (var evaluation in evaluations)
        {
            var evaluationToUpdate = Evaluations.FirstOrDefault(e => e.Id == evaluation.Id);
            if (evaluationToUpdate != null)
            {
                evaluationToUpdate.Update(evaluation);
                UpdatedAt = DateTime.Now;
            }
            else
            {
                Evaluations.Add(evaluation);
                UpdatedAt = DateTime.Now;
            }
        }
    }

    public void RemoveEvaluations(IEnumerable<EvaluationModel> evaluations)
    {
        foreach (var evaluation in evaluations)
        {
            var evaluationToRemove = Evaluations.FirstOrDefault(e => e.Id == evaluation.Id);
            if (evaluationToRemove != null)
            {
                Evaluations.Remove(evaluationToRemove);
                UpdatedAt = DateTime.Now;
            }
        }
    }

    public void RemoveAllEvaluations()
    {
        Evaluations.Clear();
        UpdatedAt = DateTime.Now;
    }
}
