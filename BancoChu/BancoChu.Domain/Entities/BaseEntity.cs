﻿namespace BancoChu.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity(Guid id) => Id = id;

    protected BaseEntity()
    { }

    public Guid Id { get; private init; }
}