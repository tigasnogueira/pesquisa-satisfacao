using Microsoft.AspNetCore.Mvc;
using Pesquisa.ClientApi.Interfaces;
using Pesquisa.ClientApi.Models;

namespace Pesquisa.ClientApi.Controllers;

[ApiController]
[Route("api/[controller]/client")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientModel>>> GetClients()
    {
        var clients = await _clientService.GetClientsAsync();
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
        return Ok(client);
    }

    [HttpPost]
    public async Task<ActionResult<ClientModel>> CreateClient(ClientModel client)
    {
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

        await _clientService.DeleteClientAsync(id);
        return NoContent();
    }
}
