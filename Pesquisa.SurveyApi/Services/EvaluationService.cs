using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Services;

public class EvaluationService : IEvaluationService
{
    private readonly ILogger<EvaluationService> _logger;
    private readonly IEvaluationRepository _evaluationRepository;

    public EvaluationService(ILogger<EvaluationService> logger, IEvaluationRepository evaluationRepository)
    {
        _logger = logger;
        _evaluationRepository = evaluationRepository;
    }

    public EvaluationModel CreateEvaluation(EvaluationModel evaluation)
    {
        _logger.LogInformation("Creating evaluation");

        return _evaluationRepository.CreateEvaluation(evaluation);
    }

    public IEnumerable<EvaluationModel> GetEvaluations()
    {
        _logger.LogInformation("Getting evaluations");

        return _evaluationRepository.GetEvaluations();
    }

    public EvaluationModel GetEvaluationById(Guid id)
    {
        _logger.LogInformation("Getting evaluation by id");

        return _evaluationRepository.GetEvaluationById(id);
    }

    public IEnumerable<EvaluationModel> GetEvaluationsByMonthAndYear(int month, int year)
    {
        _logger.LogInformation("Getting evaluations by month and year");

        return _evaluationRepository.GetEvaluationsByMonthAndYear(month, year);
    }

    public IEnumerable<EvaluationModel> GetEvaluationsByCustomerId(Guid customerId)
    {
        _logger.LogInformation("Getting evaluations by customer id");

        return _evaluationRepository.GetEvaluationsByCustomerId(customerId);
    }

    public decimal CalculateNPS(int month, int year)
    {
        _logger.LogInformation("Calculating NPS");

        return _evaluationRepository.CalculateNPS(month, year);
    }
}
