using ProfitabilityApi.Data;
namespace ProfitabilityApi.Services;
public interface IProductSegmentService : IEntityService<ProductSegment> { }
public sealed class ProductSegmentService(AppDb db) : EntityService<ProductSegment>(db), IProductSegmentService { }
