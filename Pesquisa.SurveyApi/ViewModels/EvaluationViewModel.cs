using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.ViewModels;

public class EvaluationViewModel
{
    public DateTime EvaluationDate { get; set; }
    public int CustomerId { get; set; }
    public CustomerModel Customer { get; set; }
    public int Score { get; set; }
    public string Reason { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
