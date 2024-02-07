using BancoChu.Application.Abstractions;

namespace BancoChu.Application.Authentication;

public record AuthenticationCommand(string Email) : ICommand<string>;