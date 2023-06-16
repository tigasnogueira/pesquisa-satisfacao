using Pesquisa.IdentityApi.Context;
using Pesquisa.IdentityApi.Core;

namespace Pesquisa.IdentityApi.UoW;

public class HttpUnitOfWork : UnitOfWork
{
    public HttpUnitOfWork(ApplicationDbContext context, IHttpContextAccessor httpAccessor) : base(context)
    {
        context.CurrentUserId = httpAccessor.HttpContext?.User.FindFirst(ClaimConstants.Subject)?.Value?.Trim();
    }
}