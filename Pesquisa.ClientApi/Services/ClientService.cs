using Pesquisa.ClientApi.Interfaces;
using Pesquisa.ClientApi.Models;

namespace Pesquisa.ClientApi.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<ClientModel> CreateClientAsync(ClientModel client)
    {
        return await _clientRepository.CreateClientAsync(client);
    }

    public async Task<ClientModel> UpdateClientAsync(ClientModel client)
    {
        return await _clientRepository.UpdateClientAsync(client);
    }

    public async Task<ClientModel> DeleteClientAsync(Guid id)
    {
        return await _clientRepository.DeleteClientAsync(id);
    }

    public async Task<ClientModel> GetClientAsync(Guid id)
    {
        return await _clientRepository.GetClientAsync(id);
    }

    public async Task<IEnumerable<ClientModel>> GetClientsAsync()
    {
        return await _clientRepository.GetClientsAsync();
    }
}
