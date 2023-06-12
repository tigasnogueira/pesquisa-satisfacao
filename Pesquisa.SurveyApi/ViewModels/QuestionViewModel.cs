namespace Pesquisa.SurveyApi.ViewModels;

public class QuestionViewModel
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string Options { get; set; }
    public Guid SurveyId { get; set; }
}
