using BancoChu.Application.Abstractions;
using System.Globalization;
using System.Net.Http.Json;

namespace BancoChu.Infrastructure.Services;

public class BrazilHolidaysService : IBrazilHolidaysService
{
    public async Task<bool> IsHolidayAsync(DateTime transferDate, CancellationToken cancellationToken = default)
    {
        var brasilHolidaysResponse = await GetBrazilHolidaysAsync(cancellationToken);
        return brasilHolidaysResponse?.Any(x =>
            x.Date == transferDate.ToString("yyyy-MM-dd")) == true;
    }

    private static async Task<IReadOnlyList<BrazilHolidaysResponse>?> GetBrazilHolidaysAsync(
        CancellationToken cancellationToken = default)
    {
        HttpClient client = new()
        {
            BaseAddress = new Uri("https://brasilapi.com.br/"),
        };

        using HttpResponseMessage response = await client
            .GetAsync("api/feriados/v1/2024", cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content
            .ReadFromJsonAsync<IReadOnlyList<BrazilHolidaysResponse>>(cancellationToken);
    }
}