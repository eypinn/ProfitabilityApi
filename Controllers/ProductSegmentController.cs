using Microsoft.AspNetCore.Mvc;
using ProfitabilityApi.Data;
using ProfitabilityApi.Services;
namespace ProfitabilityApi.Controllers;
[ApiController, Route("api/productsegments")]
public sealed class ProductSegmentController(IProductSegmentService service, ICrmDirectoryService crm) : ControllerBase {
 [HttpGet] public async Task<IActionResult> List(CancellationToken ct) => Ok(await service.ListAsync(ct));
 [HttpPost] public async Task<IActionResult> Save([FromBody] ProductSegment item,CancellationToken ct) {
  try { if (!await crm.SegmentExistsAsync(item.SegmentCode, ct)) return BadRequest("CRM segment kodu bulunamadı."); }
  catch (HttpRequestException) { return StatusCode(503, "CRM API erişilemiyor; ilişki kaydedilmedi."); }
  var keys=new object[] { item.ProductCode, item.SegmentCode };
  if(await service.GetAsync(keys,ct) is null) await service.CreateAsync(item,ct);
  else await service.UpdateAsync(keys,item,ct);
  return Ok(item);
 }
 [HttpDelete] public async Task<IActionResult> Delete(string productCode, string segmentCode,CancellationToken ct) =>
  await service.DeleteAsync(new object[] {productCode, segmentCode},ct) ? NoContent() : NotFound();
}
