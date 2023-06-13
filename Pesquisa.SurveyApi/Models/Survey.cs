using Pesquisa.Core.Models;

namespace Pesquisa.SurveyApi.Models;

public class SurveyModel : EntityModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsActive { get; set; }
    public bool Deleted { get; set; }
    public ICollection<QuestionModel> Questions { get; set; }

    public SurveyModel()
    {
        Questions = new List<QuestionModel>();
    }

    public void AddQuestion(QuestionModel question)
    {
        Questions.Add(question);
    }

    public void RemoveQuestion(QuestionModel question)
    {
        Questions.Remove(question);
    }

    public void UpdateQuestion(QuestionModel question)
    {
        var questionToUpdate = Questions.FirstOrDefault(q => q.Id == question.Id);
        if (questionToUpdate != null)
        {
            questionToUpdate.Title = question.Title;
            questionToUpdate.Description = question.Description;
            questionToUpdate.UpdatedAt = DateTime.Now;
        }
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

    public void Update(string title, string description)
    {
        Title = title;
        Description = description;
        UpdatedAt = DateTime.Now;
    }

    public void UpdateTitle(string title)
    {
        Title = title;
        UpdatedAt = DateTime.Now;
    }

    public void UpdateDescription(string description)
    {
        Description = description;
        UpdatedAt = DateTime.Now;
    }

    public void UpdateQuestions(ICollection<QuestionModel> questions)
    {
        Questions = questions;
        UpdatedAt = DateTime.Now;
    }
}
