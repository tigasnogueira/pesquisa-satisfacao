using Microsoft.AspNetCore.Mvc;
using Pesquisa.ClientApi.Interfaces;
using Pesquisa.ClientApi.Models;

namespace Pesquisa.ClientApi.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _clientService;

    public ClientController(ILogger<ClientController> logger, IClientService clientService)
    {
        _logger = logger;
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientModel>>> GetClients()
    {
        var clients = await _clientService.GetClientsAsync();

        _logger.LogInformation($"Found {clients.Count()} clients");

        return Ok(clients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClientModel>> GetClient(Guid id)
    {
        var client = await _clientService.GetClientAsync(id);
        if (client == null)
        {
            return NotFound();
        }

        _logger.LogInformation($"Found client {client.Id}");

        return Ok(client);
    }

    [HttpPost]
    public async Task<ActionResult<ClientModel>> CreateClient(ClientModel client)
    {
        _logger.LogInformation($"Creating client {client.Name}");

        var createdClient = await _clientService.CreateClientAsync(client);
        return CreatedAtAction(nameof(GetClient), new { id = createdClient.Id }, createdClient);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ClientModel>> UpdateClient(Guid id, ClientModel client)
    {
        if (id != client.Id)
        {
            return BadRequest();
        }

        var existingClient = await _clientService.GetClientAsync(id);
        if (existingClient == null)
        {
            return NotFound();
        }

        _logger.LogInformation($"Updating client {client.Id}");

        await _clientService.UpdateClientAsync(client);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ClientModel>> DeleteClient(Guid id)
    {
        var existingClient = await _clientService.GetClientAsync(id);
        if (existingClient == null)
        {
            return NotFound();
        }

        _logger.LogInformation($"Deleting client {existingClient.Id}");

        await _clientService.DeleteClientAsync(id);
        return NoContent();
    }
}
