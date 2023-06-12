using Pesquisa.ClientApi.Models;

namespace Pesquisa.ClientApi.Interfaces;

public interface IClientService
{
    Task<ClientModel> GetClientAsync(Guid id);
    Task<IEnumerable<ClientModel>> GetClientsAsync();
    Task<ClientModel> CreateClientAsync(ClientModel client);
    Task<ClientModel> UpdateClientAsync(ClientModel client);
    Task<ClientModel> DeleteClientAsync(Guid id);
}
