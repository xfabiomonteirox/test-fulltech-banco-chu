using BancoChu.Application.Abstractions;

namespace BancoChu.Application.Authentication.Commands;

public record AuthenticationCommand(string Email) : ICommand<string>;