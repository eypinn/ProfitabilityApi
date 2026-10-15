using Microsoft.AspNetCore.Mvc;
using ProfitabilityApi.Services;
namespace ProfitabilityApi.Controllers;
[ApiController,Route("api/calculation")]
public sealed class CalculationController(ICalculationService service):ControllerBase {
 [HttpPost("monthly/{month}")] public async Task<IActionResult> Calculate(DateTime month,CancellationToken ct) {
  await service.CalculateAsync(month,ct);return NoContent();
 }
 [HttpGet("monthly/{dateKey:int}")] public async Task<IActionResult> Results(int dateKey,CancellationToken ct) =>
  Ok(await service.ResultsAsync(dateKey,ct));
}
