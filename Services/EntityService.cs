using Microsoft.EntityFrameworkCore;
using ProfitabilityApi.Data;
namespace ProfitabilityApi.Services;
public interface IEntityService<T> where T : class {
 Task<IReadOnlyList<T>> ListAsync(CancellationToken ct);
 Task<T?> GetAsync(object[] keys,CancellationToken ct);
 Task<T> CreateAsync(T item,CancellationToken ct);
 Task<bool> UpdateAsync(object[] keys,T item,CancellationToken ct);
 Task<bool> DeleteAsync(object[] keys,CancellationToken ct);
}
public abstract class EntityService<T>(AppDb db) : IEntityService<T> where T:class {
 protected AppDb Db => db;
 protected DbSet<T> Set => db.Set<T>();
 public async Task<IReadOnlyList<T>> ListAsync(CancellationToken ct) => await Set.AsNoTracking().Take(500).ToListAsync(ct);
 public async Task<T?> GetAsync(object[] keys,CancellationToken ct) => await Set.FindAsync(keys,ct);
 public async Task<T> CreateAsync(T item,CancellationToken ct) {Set.Add(item);await db.SaveChangesAsync(ct);return item;}
 public async Task<bool> UpdateAsync(object[] keys,T item,CancellationToken ct) {
  var current=await Set.FindAsync(keys,ct);if(current is null)return false;
  db.Entry(current).CurrentValues.SetValues(item);await db.SaveChangesAsync(ct);return true;
 }
 public async Task<bool> DeleteAsync(object[] keys,CancellationToken ct) {
  var current=await Set.FindAsync(keys,ct);if(current is null)return false;
  Set.Remove(current);await db.SaveChangesAsync(ct);return true;
 }
}
