namespace BancoChu.Domain.Entities.Base;

public abstract class BaseEntity
{
    protected BaseEntity(Guid id) => Id = id;

    protected BaseEntity()
    { }

    public Guid Id { get; private init; }
}