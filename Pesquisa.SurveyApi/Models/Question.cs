using Pesquisa.Core.Models;

namespace Pesquisa.SurveyApi.Models;

public class QuestionModel : EntityModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string Options { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool Active { get; set; }
    public bool Deleted { get; set; }
    public Guid SurveyId { get; set; }
    public SurveyModel Survey { get; set; }

    public QuestionModel()
    {
        Active = true;
    }

    public void Activate()
    {
        Active = true;
        UpdatedAt = DateTime.Now;
    }

    public void Deactivate()
    {
        Active = false;
        UpdatedAt = DateTime.Now;
    }

    public void Delete()
    {
        Deleted = true;
        DeletedAt = DateTime.Now;
    }

    public void Restore()
    {
        Deleted = false;
        DeletedAt = null;
    }

    public void Update(QuestionModel question)
    {
        Title = question.Title;
        Description = question.Description;
        UpdatedAt = DateTime.Now;
    }

    public void SetSurvey(SurveyModel survey)
    {
        Survey = survey;
    }
}
