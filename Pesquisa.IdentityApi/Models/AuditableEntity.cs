using Pesquisa.IdentityApi.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Pesquisa.IdentityApi.Models;

public class AuditableEntity : IAuditableEntity
{
    [MaxLength(256)]
    public string CreatedBy { get; set; }
    [MaxLength(256)]
    public string UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
