using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionService(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<QuestionModel> GetQuestionAsync(Guid id)
    {
        return await _questionRepository.GetQuestionAsync(id);
    }

    public async Task<IEnumerable<QuestionModel>> GetQuestionsAsync()
    {
        return await _questionRepository.GetQuestionsAsync();
    }

    public async Task<QuestionModel> CreateQuestionAsync(QuestionModel question)
    {
        return await _questionRepository.CreateQuestionAsync(question);
    }

    public async Task<QuestionModel> UpdateQuestionAsync(QuestionModel question)
    {
        return await _questionRepository.UpdateQuestionAsync(question);
    }

    public async Task<QuestionModel> DeleteQuestionAsync(Guid id)
    {
        return await _questionRepository.DeleteQuestionAsync(id);
    }
}
