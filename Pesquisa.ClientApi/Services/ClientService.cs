using Pesquisa.ClientApi.Interfaces;
using Pesquisa.ClientApi.Models;

namespace Pesquisa.ClientApi.Services;

public class ClientService : IClientService
{
    private readonly ILogger<ClientService> _logger;
    private readonly IClientRepository _clientRepository;

    public ClientService(ILogger<ClientService> logger, IClientRepository clientRepository)
    {
        _logger = logger;
        _clientRepository = clientRepository;
    }

    public async Task<ClientModel> CreateClientAsync(ClientModel client)
    {
        _logger.LogInformation("Creating client");

        return await _clientRepository.CreateClientAsync(client);
    }

    public async Task<ClientModel> UpdateClientAsync(ClientModel client)
    {
        _logger.LogInformation("Updating client");

        return await _clientRepository.UpdateClientAsync(client);
    }

    public async Task<ClientModel> DeleteClientAsync(Guid id)
    {
        _logger.LogInformation("Deleting client");

        return await _clientRepository.DeleteClientAsync(id);
    }

    public async Task<ClientModel> GetClientAsync(Guid id)
    {
        _logger.LogInformation("Getting client");

        return await _clientRepository.GetClientAsync(id);
    }

    public async Task<IEnumerable<ClientModel>> GetClientsAsync()
    {
        _logger.LogInformation("Getting clients");

        return await _clientRepository.GetClientsAsync();
    }
}
