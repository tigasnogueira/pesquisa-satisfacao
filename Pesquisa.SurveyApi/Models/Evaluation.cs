using Pesquisa.Core.Models;

namespace Pesquisa.SurveyApi.Models;

public class EvaluationModel : EntityModel
{
    public DateTime EvaluationDate { get; set; }
    public Guid CustomerId { get; set; }
    public CustomerModel Customer { get; set; }
    public int Score { get; set; }
    public string Reason { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public EvaluationModel()
    {
        IsActive = true;
    }

    public void Update(EvaluationModel evaluation)
    {
        EvaluationDate = evaluation.EvaluationDate;
        CustomerId = evaluation.CustomerId;
        Score = evaluation.Score;
        Reason = evaluation.Reason;
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
}
