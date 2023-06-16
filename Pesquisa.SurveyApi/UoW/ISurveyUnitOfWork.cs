using Pesquisa.SurveyApi.Interfaces;

namespace Pesquisa.SurveyApi.UoW;

public interface ISurveyUnitOfWork
{
    ICustomerRepository Customers { get; }
    IEvaluationRepository Evaluations { get; }

    int SaveChanges();
}
