namespace Pesquisa.Core.Models;

public abstract class EntityModel
{
    protected EntityModel()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}
