using InvoiceManagementLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceProvider.Controllers
{
    [Route("api/deleteinvoice")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public DeleteController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpDelete("{invoiceId}")]
        public async Task<IActionResult> DelereInvoice(int invoiceId)
        {
            var deletedInvoice = await _invoiceService.DeleteInvoiceAsync(invoiceId);
            if (deletedInvoice != null)
            {
                return NotFound($"Invoice with ID {invoiceId} not found.");
            }
            return Ok($"Invoice with ID {invoiceId} has been deleted successfully.");

        }
    }
}
