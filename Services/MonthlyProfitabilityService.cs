using ProfitabilityApi.Data;
namespace ProfitabilityApi.Services;
public interface IMonthlyProfitabilityService : IEntityService<MonthlyProfitability> { }
public sealed class MonthlyProfitabilityService(AppDb db) : EntityService<MonthlyProfitability>(db), IMonthlyProfitabilityService { }
