namespace BancoChu.Application.Abstractions;

public interface IBrazilHolidaysService
{
    Task<bool> IsHolidayAsync(DateTime transferDate, CancellationToken cancellationToken = default);
}