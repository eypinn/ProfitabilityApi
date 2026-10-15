using ProfitabilityApi.Data;
namespace ProfitabilityApi.Services;
public interface IProductService : IEntityService<Product> { }
public sealed class ProductService(AppDb db) : EntityService<Product>(db), IProductService { }
