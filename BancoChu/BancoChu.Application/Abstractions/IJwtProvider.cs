using BancoChu.Domain.Entities.ApplicationUsers;

namespace BancoChu.Application.Abstractions;

public interface IJwtProvider
{
    string Generate(ApplicationUser user);
}