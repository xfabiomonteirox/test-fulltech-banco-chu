using BancoChu.API.Extensions;
using BancoChu.Application.Authentication.Commands;
using BancoChu.Domain.Shared;
using MediatR;

namespace BancoChu.API;

public static class BankChuMapEndpoints
{
    public static void MapBankChuEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("v1/login", async (
            IMediator mediator,
            string email) =>
        {
            Result<string> result = await mediator.Send(new AuthenticationCommand(email));
            return result.IsSuccess
                ? Results.Created(string.Empty, result.Value)
                : result.ToProblemDetails();
        });
    }
}