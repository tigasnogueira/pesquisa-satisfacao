using Microsoft.EntityFrameworkCore;
using Pesquisa.SurveyApi.Context;
using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Repository;

public class SurveyRepository : ISurveyRepository
{
    private readonly SurveyDbContext _surveyDbContext;

    public SurveyRepository(SurveyDbContext surveyDbContext)
    {
        _surveyDbContext = surveyDbContext;
    }

    public async Task<SurveyModel> CreateSurveyAsync(SurveyModel survey)
    {
        _surveyDbContext.Surveys.Add(survey);
        await _surveyDbContext.SaveChangesAsync();
        return survey;
    }

    public async Task<SurveyModel> UpdateSurveyAsync(SurveyModel survey)
    {
        _surveyDbContext.Surveys.Update(survey);
        await _surveyDbContext.SaveChangesAsync();
        return survey;
    }

    public async Task<SurveyModel> DeleteSurveyAsync(Guid id)
    {
        var survey = await _surveyDbContext.Surveys.FindAsync(id);
        _surveyDbContext.Surveys.Remove(survey);
        await _surveyDbContext.SaveChangesAsync();
        return survey;
    }

    public async Task<SurveyModel> GetSurveyAsync(Guid id)
    {
        return await _surveyDbContext.Surveys.FindAsync(id);
    }

    public async Task<IEnumerable<SurveyModel>> GetSurveysAsync()
    {
        return await _surveyDbContext.Surveys.ToListAsync();
    }
}
