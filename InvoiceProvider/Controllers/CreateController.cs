using InvoiceManagementLibrary.Entities;
using InvoiceManagementLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceProvider.Controllers
{
    [Route("api/createinvoice")]
    [ApiController]
    public class CreateController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public CreateController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateInvoiceAsync([FromBody] InvoiceEntity model)
        {
            try
            {
                var result = await _invoiceService.CreateInvoiceAsync(model);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
