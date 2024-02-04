using BancoChu.Domain.Shared;
using MediatR;

namespace BancoChu.Application.Abstractions;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;