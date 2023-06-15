using Microsoft.EntityFrameworkCore;
using Pesquisa.ClientApi.Context;
using Pesquisa.ClientApi.Interfaces;
using Pesquisa.ClientApi.Models;

namespace Pesquisa.ClientApi.Repository;

public class ClientRepository : IClientRepository
{
    private readonly ILogger<ClientRepository> _logger;
    private readonly ClientDbContext _context;

    public ClientRepository(ILogger<ClientRepository> logger, ClientDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<ClientModel> CreateClientAsync(ClientModel client)
    {
        _logger.LogInformation("Creating client");

        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<ClientModel> UpdateClientAsync(ClientModel client)
    {
        _logger.LogInformation("Updating client");

        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<ClientModel> DeleteClientAsync(Guid id)
    {
        _logger.LogInformation("Deleting client");

        var client = await _context.Clients.FindAsync(id);
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<ClientModel> GetClientAsync(Guid id)
    {
        _logger.LogInformation("Getting client");

        return await _context.Clients.FindAsync(id);
    }

    public async Task<IEnumerable<ClientModel>> GetClientsAsync()
    {
        _logger.LogInformation("Getting clients");

        return await _context.Clients.ToListAsync();
    }
}
