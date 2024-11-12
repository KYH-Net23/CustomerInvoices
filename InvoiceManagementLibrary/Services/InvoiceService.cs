using InvoiceManagementLibrary.Entities;
using InvoiceManagementLibrary.Repositories;


namespace InvoiceManagementLibrary.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<List<InvoiceEntity>> GetAllInvoicesAsync()
        {
            try
            {
                var invoices = await _invoiceRepository.GetAllInvoicesAsync();
                return invoices ?? new List<InvoiceEntity>(); 
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred while fetching all invoices: {ex.Message}");
                return new List<InvoiceEntity>();
            }
        }

        public async Task<InvoiceEntity?> GetInvoiceByIdAsync(int invoiceId)
        {
            try
            {
                var invoice = await _invoiceRepository.GetInvoiceByIdAsync(invoiceId);
                if (invoice == null)
                {
                    Console.WriteLine($"Invoice with ID {invoiceId} not found.");
                    return null; 
                }
                return invoice;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred while fetching invoice with ID {invoiceId}: {ex.Message}");
                return null;
            }
        }
    }
}
