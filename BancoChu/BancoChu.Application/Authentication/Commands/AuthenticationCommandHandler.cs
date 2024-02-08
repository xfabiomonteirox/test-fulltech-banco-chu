using BancoChu.Application.Abstractions;
using BancoChu.Domain.Entities.ApplicationUsers;
using BancoChu.Domain.Repositories;
using BancoChu.Domain.Shared;

namespace BancoChu.Application.Authentication.Commands;

internal sealed class AuthenticationCommandHandler(
    IJwtProvider jwtProvider,
    IApplicationUserRepository applicationUserRepository)
    : ICommandHandler<AuthenticationCommand, string>
{
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly IApplicationUserRepository _applicationUserRepository = applicationUserRepository;

    public async Task<Result<string>> Handle(AuthenticationCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _applicationUserRepository
            .GetByEmailAsync(request.Email, cancellationToken);

        if (user is null)
            return Result.Failure<string>(ApplicationUserErrors.NotFoundByEmail(request.Email));

        return _jwtProvider.Generate(user!);
    }
}