using InvoiceManagementLibrary.Entities;
using InvoiceManagementLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceProvider.Controllers
{
    [Route("api/updateinvoice")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public UpdateController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPut("{invoiceId}")]
        public async Task<IActionResult> UpdateInvoice(int invoiceId, [FromBody] InvoiceEntity updatedModel)
        {
            var updatedInvoice = await _invoiceService.UpdateInvoiceAsync(invoiceId, updatedModel);
            if (updatedInvoice == null)
            {
                return NotFound($"Invoice with ID {invoiceId} not found.");
            }
            return Ok(updatedInvoice);
        }
    }
}
