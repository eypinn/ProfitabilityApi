namespace ProfitabilityApi.Services;
public interface ICrmDirectoryService
{
    Task<bool> SegmentExistsAsync(string code, CancellationToken ct);
    Task<bool> PortfolioExistsAsync(string code, CancellationToken ct);
    Task<bool> CustomerExistsAsync(long code, CancellationToken ct);
}
