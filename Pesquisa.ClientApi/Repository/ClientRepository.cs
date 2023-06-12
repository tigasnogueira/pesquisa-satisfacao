using Microsoft.EntityFrameworkCore;
using Pesquisa.ClientApi.Context;
using Pesquisa.ClientApi.Interfaces;
using Pesquisa.ClientApi.Models;

namespace Pesquisa.ClientApi.Repository;

public class ClientRepository : IClientRepository
{
    private readonly ClientContext _context;

    public ClientRepository(ClientContext context)
    {
        _context = context;
    }

    public async Task<ClientModel> CreateClientAsync(ClientModel client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<ClientModel> UpdateClientAsync(ClientModel client)
    {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<ClientModel> DeleteClientAsync(Guid id)
    {
        var client = await _context.Clients.FindAsync(id);
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<ClientModel> GetClientAsync(Guid id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<IEnumerable<ClientModel>> GetClientsAsync()
    {
        return await _context.Clients.ToListAsync();
    }
}
