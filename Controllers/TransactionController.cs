using Microsoft.AspNetCore.Mvc;
using ProfitabilityApi.Data;
using ProfitabilityApi.Services;
namespace ProfitabilityApi.Controllers;
[ApiController, Route("api/transactions")]
public sealed class TransactionController(ITransactionService service, ICrmDirectoryService crm) : ControllerBase {
 [HttpGet] public async Task<IActionResult> List(CancellationToken ct) => Ok(await service.ListAsync(ct));
 [HttpGet("{id}")] public async Task<IActionResult> Get(long id,CancellationToken ct) {
  var item=await service.GetAsync(new object[]{id},ct);
  return item is null ? NotFound() : Ok(item);
 }
 [HttpPost] public async Task<IActionResult> Create([FromBody] Transaction item,CancellationToken ct) {
  var error = await ValidateCrmAsync(item, ct);
  if (error is not null) return error;
  return Ok(await service.CreateAsync(item,ct));
 }
 [HttpPut("{id}")] public async Task<IActionResult> Update(long id,[FromBody] Transaction item,CancellationToken ct) {
  if(id != item.TransactionId)return BadRequest("Route id and body key differ.");
  var error = await ValidateCrmAsync(item, ct);
  if (error is not null) return error;
  return await service.UpdateAsync(new object[]{id},item,ct) ? NoContent() : NotFound();
 }
 [HttpDelete("{id}")] public async Task<IActionResult> Delete(long id,CancellationToken ct) =>
  await service.DeleteAsync(new object[]{id},ct) ? NoContent() : NotFound();
}
