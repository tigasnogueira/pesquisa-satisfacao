using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Interfaces;

public interface ISurveyService
{
    Task<SurveyModel> GetSurveyAsync(Guid id);
    Task<IEnumerable<SurveyModel>> GetSurveysAsync();
    Task<SurveyModel> CreateSurveyAsync(SurveyModel survey);
    Task<SurveyModel> UpdateSurveyAsync(SurveyModel survey);
    Task<SurveyModel> DeleteSurveyAsync(Guid id);
}
