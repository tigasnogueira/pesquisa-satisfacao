using Pesquisa.SurveyApi.Context;
using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Repository;

namespace Pesquisa.SurveyApi.UoW;

public class SurveyUnitOfWork : ISurveyUnitOfWork
{
    private readonly SurveyDbContext _context;
    private readonly ILogger<CustomerRepository> _customerLogger;
    private readonly ILogger<EvaluationRepository> _evaluationLogger;
    ICustomerRepository _customers;
    IEvaluationRepository _evaluations;

    public SurveyUnitOfWork(SurveyDbContext context)
    {
        _context = context;
    }

    public ICustomerRepository Customers
    {
        get
        {
            if (_customers == null)
                _customers = new CustomerRepository(_customerLogger, _context);

            return _customers;
        }
    }

    public IEvaluationRepository Evaluations
    {
        get
        {
            if (_evaluations == null)
                _evaluations = new EvaluationRepository(_evaluationLogger, _context);

            return _evaluations;
        }
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
