using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Services;

public class EvaluationService : IEvaluationService
{
    private readonly IEvaluationRepository _evaluationRepository;

    public EvaluationService(IEvaluationRepository evaluationRepository)
    {
        _evaluationRepository = evaluationRepository;
    }

    public EvaluationModel CreateEvaluation(EvaluationModel evaluation)
    {
        // Coloque qualquer lógica adicional aqui, se necessário

        return _evaluationRepository.CreateEvaluation(evaluation);
    }

    public IEnumerable<EvaluationModel> GetEvaluations()
    {
        return _evaluationRepository.GetEvaluations();
    }

    public EvaluationModel GetEvaluationById(Guid id)
    {
        return _evaluationRepository.GetEvaluationById(id);
    }

    public IEnumerable<EvaluationModel> GetEvaluationsByMonthAndYear(int month, int year)
    {
        return _evaluationRepository.GetEvaluationsByMonthAndYear(month, year);
    }

    public IEnumerable<EvaluationModel> GetEvaluationsByCustomerId(Guid customerId)
    {
        return _evaluationRepository.GetEvaluationsByCustomerId(customerId);
    }

    public decimal CalculateNPS(int month, int year)
    {
        return _evaluationRepository.CalculateNPS(month, year);
    }
}
