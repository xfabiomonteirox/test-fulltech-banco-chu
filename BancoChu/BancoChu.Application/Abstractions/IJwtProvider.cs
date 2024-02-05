using BancoChu.Domain.Entities;

namespace BancoChu.Application.Abstractions;

public interface IJwtProvider
{
    string Generate(ApplicationUser user);
}