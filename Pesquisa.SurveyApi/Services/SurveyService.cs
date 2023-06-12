using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Services;

public class SurveyService : ISurveyService
{
    private readonly ISurveyRepository _surveyRepository;

    public SurveyService(ISurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }

    public async Task<SurveyModel> CreateSurveyAsync(SurveyModel survey)
    {
        return await _surveyRepository.CreateSurveyAsync(survey);
    }

    public async Task<SurveyModel> DeleteSurveyAsync(Guid id)
    {
        return await _surveyRepository.DeleteSurveyAsync(id);
    }

    public async Task<SurveyModel> GetSurveyAsync(Guid id)
    {
        return await _surveyRepository.GetSurveyAsync(id);
    }

    public async Task<IEnumerable<SurveyModel>> GetSurveysAsync()
    {
        return await _surveyRepository.GetSurveysAsync();
    }

    public async Task<SurveyModel> UpdateSurveyAsync(SurveyModel survey)
    {
        return await _surveyRepository.UpdateSurveyAsync(survey);
    }
}
