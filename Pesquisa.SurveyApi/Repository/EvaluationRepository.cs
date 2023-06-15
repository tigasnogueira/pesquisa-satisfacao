using Pesquisa.SurveyApi.Context;
using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Repository;

public class EvaluationRepository : IEvaluationRepository
{
    private readonly ILogger<EvaluationRepository> _logger;
    private readonly SurveyDbContext _dbContext;

    public EvaluationRepository(ILogger<EvaluationRepository> logger, SurveyDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public EvaluationModel CreateEvaluation(EvaluationModel evaluation)
    {
        _logger.LogInformation($"Creating evaluation for customer {evaluation.CustomerId}");

        _dbContext.Evaluations.Add(evaluation);
        _dbContext.SaveChanges();

        return evaluation;
    }

    public IEnumerable<EvaluationModel> GetEvaluations()
    {
        _logger.LogInformation("Getting all evaluations");

        return _dbContext.Evaluations.ToList();
    }

    public EvaluationModel GetEvaluationById(Guid id)
    {
        _logger.LogInformation($"Getting evaluation with id {id}");

        return _dbContext.Evaluations.FirstOrDefault(e => e.Id == id);
    }

    public IEnumerable<EvaluationModel> GetEvaluationsByMonthAndYear(int month, int year)
    {
        _logger.LogInformation($"Getting evaluations for month {month} and year {year}");

        return _dbContext.Evaluations.Where(e => e.EvaluationDate.Month == month && e.EvaluationDate.Year == year).ToList();
    }

    public IEnumerable<EvaluationModel> GetEvaluationsByCustomerId(Guid customerId)
    {
        _logger.LogInformation($"Getting evaluations for customer {customerId}");

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

        _logger.LogInformation($"Calculating NPS for month {month} and year {year}");

        return ((decimal)(promoters - detractors) / totalParticipants) * 100;
    }
}
