using BancoChu.Application.Abstractions;
using System.Net.Http.Json;

namespace BancoChu.Infrastructure.Services;

public class BrazilHolidaysService(HttpClient client) : IBrazilHolidaysService
{
    private readonly HttpClient _client = client;
    private const string ENDPOINT = "https://brasilapi.com.br/api/feriados/v1/2024";

    public async Task<bool> IsBrazilHolidays(DateTime transferDate,
        CancellationToken cancellationToken = default)
    {
        var content = await _client
            .GetFromJsonAsync<IReadOnlyList<BrazylHolidays>>(ENDPOINT, cancellationToken);

        return content!.Any(x =>
            x.Date.CompareTo(transferDate.ToShortDateString()) > 0);
    }
}