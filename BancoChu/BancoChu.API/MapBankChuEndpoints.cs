using BancoChu.Application.Authentication;
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
            Result<string> token = await mediator.Send(new AuthenticationCommand(email));
            return token.IsSuccess
                ? Results.Created(string.Empty, token.Value)
                : Results.BadRequest(token.Error);
        });
    }
}