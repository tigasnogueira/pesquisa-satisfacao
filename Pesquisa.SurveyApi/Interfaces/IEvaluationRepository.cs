using Pesquisa.Core.Repository.Interface;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Interfaces;

public interface IEvaluationRepository : IRepository<EvaluationModel>
{
    EvaluationModel CreateEvaluation(EvaluationModel evaluation);
    IEnumerable<EvaluationModel> GetEvaluations();
    EvaluationModel GetEvaluationById(Guid id);
    IEnumerable<EvaluationModel> GetEvaluationsByMonthAndYear(int month, int year);
    IEnumerable<EvaluationModel> GetEvaluationsByCustomerId(Guid customerId);
    decimal CalculateNPS(int month, int year);
}
