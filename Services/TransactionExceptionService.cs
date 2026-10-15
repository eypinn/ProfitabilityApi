using ProfitabilityApi.Data;
namespace ProfitabilityApi.Services;
public interface ITransactionExceptionService : IEntityService<TransactionException> { }
public sealed class TransactionExceptionService(AppDb db) : EntityService<TransactionException>(db), ITransactionExceptionService { }
