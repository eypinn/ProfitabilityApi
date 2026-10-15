using ProfitabilityApi.Data;
namespace ProfitabilityApi.Services;
public interface ISubProductService : IEntityService<SubProduct> { }
public sealed class SubProductService(AppDb db) : EntityService<SubProduct>(db), ISubProductService { }
