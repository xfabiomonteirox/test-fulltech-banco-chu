using BancoChu.Domain.Shared;
using MediatR;

namespace BancoChu.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;