using Microsoft.EntityFrameworkCore;
using ProfitabilityApi.Data;
namespace ProfitabilityApi.Services;
public interface ICalculationService {
 Task CalculateAsync(DateTime month,CancellationToken ct);
 Task<IReadOnlyList<MonthlyProfitability>> ResultsAsync(int dateKey,CancellationToken ct);
}
public sealed class CalculationService(AppDb db):ICalculationService {
 public async Task CalculateAsync(DateTime month,CancellationToken ct) =>
  await db.Database.ExecuteSqlInterpolatedAsync($"EXEC dbo.CalculateMonthlyProfitability @MonthDate={month}",ct);
 public async Task<IReadOnlyList<MonthlyProfitability>> ResultsAsync(int dateKey,CancellationToken ct) =>
  await db.MonthlyProfitability.AsNoTracking().Where(x=>x.DateKey==dateKey).Take(2000).ToListAsync(ct);
}
