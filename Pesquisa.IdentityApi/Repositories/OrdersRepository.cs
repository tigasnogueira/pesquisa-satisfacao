using Microsoft.EntityFrameworkCore;
using Pesquisa.Core.Repository;
using Pesquisa.IdentityApi.Context;
using Pesquisa.IdentityApi.Interfaces;
using Pesquisa.IdentityApi.Models;

namespace Pesquisa.IdentityApi.Repositories;

public class OrdersRepository : Repository<Order>, IOrdersRepository
{
    public OrdersRepository(DbContext context) : base(context)
    { }

    private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
}
