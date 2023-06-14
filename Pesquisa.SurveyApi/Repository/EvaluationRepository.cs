using Pesquisa.SurveyApi.Context;
using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Repository;

public class EvaluationRepository : IEvaluationRepository
{
    private readonly SurveyDbContext _dbContext;

    public EvaluationRepository(SurveyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public EvaluationModel CreateEvaluation(EvaluationModel evaluation)
    {
        _dbContext.Evaluations.Add(evaluation);
        _dbContext.SaveChanges();

        return evaluation;
    }

    public IEnumerable<EvaluationModel> GetEvaluations()
    {
        return _dbContext.Evaluations.ToList();
    }

    public EvaluationModel GetEvaluationById(Guid id)
    {
        return _dbContext.Evaluations.FirstOrDefault(e => e.Id == id);
    }

    public IEnumerable<EvaluationModel> GetEvaluationsByMonthAndYear(int month, int year)
    {
        return _dbContext.Evaluations.Where(e => e.EvaluationDate.Month == month && e.EvaluationDate.Year == year).ToList();
    }

    public IEnumerable<EvaluationModel> GetEvaluationsByCustomerId(Guid customerId)
    {
        return _dbContext.Evaluations.Where(e => e.CustomerId == customerId).ToList();
    }

    public decimal CalculateNPS(int month, int year)
    {
        var evaluations = _dbContext.Evaluations.Where(e => e.EvaluationDate.Month == month && e.EvaluationDate.Year == year).ToList();
        var totalParticipants = evaluations.Count;
        var promoters = evaluations.Count(e => e.Score >= 9 && e.Score <= 10);
        var detractors = evaluations.Count(e => e.Score >= 0 && e.Score <= 6);

        if (totalParticipants == 0)
        {
            return 0;
        }

        return ((decimal)(promoters - detractors) / totalParticipants) * 100;
    }
}
