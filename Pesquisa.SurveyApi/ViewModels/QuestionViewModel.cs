namespace Pesquisa.SurveyApi.ViewModels;

public class QuestionViewModel
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Options { get; set; } = string.Empty;
    public Guid SurveyId { get; set; }
}
