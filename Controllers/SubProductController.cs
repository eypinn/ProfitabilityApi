using Microsoft.AspNetCore.Mvc;
using ProfitabilityApi.Data;
using ProfitabilityApi.Services;
namespace ProfitabilityApi.Controllers;
[ApiController, Route("api/subproducts")]
public sealed class SubProductController(ISubProductService service) : ControllerBase {
 [HttpGet] public async Task<IActionResult> List(CancellationToken ct) => Ok(await service.ListAsync(ct));
 [HttpPost] public async Task<IActionResult> Save([FromBody] SubProduct item,CancellationToken ct) {
  var keys=new object[] { item.ProductCode, item.SubProductCode };
  if(await service.GetAsync(keys,ct) is null) await service.CreateAsync(item,ct);
  else await service.UpdateAsync(keys,item,ct);
  return Ok(item);
 }
 [HttpDelete] public async Task<IActionResult> Delete(string productCode, string subProductCode,CancellationToken ct) =>
  await service.DeleteAsync(new object[] {productCode, subProductCode},ct) ? NoContent() : NotFound();
}
