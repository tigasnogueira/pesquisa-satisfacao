using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Interfaces;

public interface IQuestionService
{
    Task<QuestionModel> GetQuestionAsync(Guid id);
    Task<IEnumerable<QuestionModel>> GetQuestionsAsync();
    Task<QuestionModel> CreateQuestionAsync(QuestionModel question);
    Task<QuestionModel> UpdateQuestionAsync(QuestionModel question);
    Task<QuestionModel> DeleteQuestionAsync(Guid id);
}
