using BancoChu.Domain.Shared;
using MediatR;

namespace BancoChu.Application.Abstractions
{
    public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
}