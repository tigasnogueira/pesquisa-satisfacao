using Pesquisa.IdentityApi.Interfaces;
using Pesquisa.SurveyApi.Interfaces;

namespace Pesquisa.IdentityApi.UoW;

public interface IUnitOfWork
{
    
    int SaveChanges();
}
