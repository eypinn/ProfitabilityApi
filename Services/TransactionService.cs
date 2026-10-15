using ProfitabilityApi.Data;
namespace ProfitabilityApi.Services;
public interface ITransactionService : IEntityService<Transaction> { }
public sealed class TransactionService(AppDb db) : EntityService<Transaction>(db), ITransactionService { }
