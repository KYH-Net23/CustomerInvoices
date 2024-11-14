using InvoiceManagementLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceProvider.Controllers
{
    [Route("api/getallinvoices")]
    [ApiController]
    public class GetAllController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public GetAllController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return Ok(invoices);
        }
    }
}
