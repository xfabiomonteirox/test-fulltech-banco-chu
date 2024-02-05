namespace BancoChu.Application.Abstractions;

public interface IBrazilHolidaysService
{
    Task<bool> IsBrazilHolidays(DateTime transferDate, CancellationToken cancellationToken = default);
}