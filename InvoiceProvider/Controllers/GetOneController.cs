using InvoiceManagementLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceProvider.Controllers
{
    [Route("api/getoneinvoice")]
    [ApiController]
    public class GetOneController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public GetOneController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> GetInvoice(int invoiceId)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(invoiceId);
            if (invoice == null)
            {
                return NotFound($"Invoice with ID {invoiceId} not found.");
            }
            return Ok(invoice);
        }
    }
}
