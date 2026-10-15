using System.Net;
namespace ProfitabilityApi.Services;
public sealed class CrmDirectoryService(IHttpClientFactory factory) : ICrmDirectoryService
{
    private async Task<bool> ExistsAsync(string path, CancellationToken ct)
    {
        var client = factory.CreateClient("crm");
        using var response = await client.GetAsync(path, ct);
        if (response.StatusCode == HttpStatusCode.NotFound) return false;
        response.EnsureSuccessStatusCode();
        return true;
    }
    public Task<bool> SegmentExistsAsync(string code, CancellationToken ct) => ExistsAsync("api/segments/" + Uri.EscapeDataString(code), ct);
    public Task<bool> PortfolioExistsAsync(string code, CancellationToken ct) => ExistsAsync("api/portfolios/" + Uri.EscapeDataString(code), ct);
    public Task<bool> CustomerExistsAsync(long code, CancellationToken ct) => ExistsAsync("api/customers/" + code, ct);
}
