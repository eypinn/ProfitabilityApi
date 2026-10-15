using Microsoft.EntityFrameworkCore;
namespace ProfitabilityApi.Data;
public class AppDb(DbContextOptions<AppDb> options):DbContext(options) {
public DbSet<Product> Products => Set<Product>();
public DbSet<SubProduct> SubProducts => Set<SubProduct>();
public DbSet<ProductSegment> ProductSegments => Set<ProductSegment>();
public DbSet<Transaction> Transactions => Set<Transaction>();
public DbSet<TransactionException> TransactionExceptions => Set<TransactionException>();
public DbSet<MonthlyProfitability> MonthlyProfitability => Set<MonthlyProfitability>();
protected override void OnModelCreating(ModelBuilder b) {
b.Entity<Product>().ToTable("Products","dbo");
b.Entity<Product>().HasKey(x=>x.ProductCode);
b.Entity<SubProduct>().ToTable("SubProducts","dbo");
b.Entity<SubProduct>().HasKey(x=>new { x.ProductCode, x.SubProductCode });
b.Entity<ProductSegment>().ToTable("ProductSegments","dbo");
b.Entity<ProductSegment>().HasKey(x=>new { x.ProductCode, x.SegmentCode });
b.Entity<Transaction>().ToTable("Transactions","dbo");
b.Entity<Transaction>().HasKey(x=>x.TransactionId);
b.Entity<Transaction>().Property(x=>x.TransactionId).ValueGeneratedOnAdd();
b.Entity<Transaction>().Property(x=>x.YPProfit).HasPrecision(19,4);
b.Entity<Transaction>().Property(x=>x.TLProfit).HasPrecision(19,4);
b.Entity<TransactionException>().ToTable("TransactionExceptions","dbo");
b.Entity<TransactionException>().HasKey(x=>x.TransactionId);
b.Entity<TransactionException>().Property(x=>x.UpdatedAt).ValueGeneratedOnAdd();
b.Entity<TransactionException>().Property(x=>x.OverrideYPProfit).HasPrecision(19,4);
b.Entity<TransactionException>().Property(x=>x.OverrideTLProfit).HasPrecision(19,4);
b.Entity<MonthlyProfitability>().ToTable("MonthlyProfitability","dbo");
b.Entity<MonthlyProfitability>().HasKey(x=>new { x.DateKey, x.PortfolioCode, x.BranchId, x.CustomerCode, x.SegmentCode, x.ProductCode, x.SubProductCode, x.CurrencyCode });
b.Entity<MonthlyProfitability>().Property(x=>x.TotalYPProfit).HasPrecision(28,4);
b.Entity<MonthlyProfitability>().Property(x=>x.TotalTLProfit).HasPrecision(28,4);
}
}
