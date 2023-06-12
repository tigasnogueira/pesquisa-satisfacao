using Pesquisa.Core.Models;

namespace Pesquisa.ClientApi.Models;

public class ClientModel : EntityModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Notes { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ClientModel()
    {
        IsActive = true;
    }

    public void Activate()
    {
        IsActive = true;
        UpdatedAt = DateTime.Now;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.Now;
    }

    public void Update(ClientModel client)
    {
        Name = client.Name;
        Email = client.Email;
        Phone = client.Phone;
        Address = client.Address;
        City = client.City;
        State = client.State;
        PostalCode = client.PostalCode;
        Country = client.Country;
        Notes = client.Notes;
        UpdatedAt = DateTime.Now;
    }

    public void Delete()
    {
        IsActive = false;
        UpdatedAt = DateTime.Now;
    }

    public void Restore()
    {
        IsActive = true;
        UpdatedAt = DateTime.Now;
    }
}
