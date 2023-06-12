namespace Pesquisa.SurveyApi.ViewModels;

public class SurveyViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public IEnumerable<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();
}
