using BancoChu.API.Extensions;
using BancoChu.Application.Authentication.Commands;
using BancoChu.Application.BankAccount.Commands;
using BancoChu.Application.MoneyTransfer.Commands;
using BancoChu.Application.MoneyTransfer.Queries;
using BancoChu.Domain.Shared;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        app.MapPost("v1/account", async (
            CreateBankAccountCommand request,
            IValidator<CreateBankAccountCommand> validator,
            IMediator mediator) =>
        {
            var command = await validator.ValidateAsync(request);
            if (!command.IsValid)
                return Results.ValidationProblem(command.ToDictionary());

            Result<Guid> result = await mediator.Send(new CreateBankAccountCommand(
                request.BranchCode,
                request.CurrentAccountNumber,
                request.AccountBalance));

            return result.IsSuccess
                ? Results.Created(string.Empty, result.Value)
                : result.ToProblemDetails();
        })
            .Produces<Guid>()
            .RequireAuthorization();

        app.MapGet("v1/account/statament", async (
            IMediator mediator,
            [AsParameters] GetBankStatementByPeriodQuery request) =>
        {
            Result<BankStatamentResponse> result = await mediator
                .Send(new GetBankStatementByPeriodQuery(
                    request.BranchCode,
                    request.AccountNumber,
                    request.From,
                    request.To));

            return result.IsSuccess
                ? Results.Ok(result.Value)
                : result.ToProblemDetails();
        })
            .Produces<BankStatamentResponse>()
            .RequireAuthorization();

        app.MapPost("v1/transfer", async (
            CreateMoneyTransferCommand request,
            IValidator<CreateMoneyTransferCommand> validator,
            IMediator mediator) =>
        {
            var command = await validator.ValidateAsync(request);
            if (!command.IsValid)
                return Results.ValidationProblem(command.ToDictionary());

            Result<Guid> result = await mediator.Send(new CreateMoneyTransferCommand(
                request.BranchCode,
                request.AccountNumber,
                request.Amount,
                request.MadeOn,
                request.Description,
                request.Destination));

            return result.IsSuccess
                ? Results.Created(string.Empty, result.Value)
                : result.ToProblemDetails();
        })
            .Produces<Guid>()
            .RequireAuthorization();
    }
}