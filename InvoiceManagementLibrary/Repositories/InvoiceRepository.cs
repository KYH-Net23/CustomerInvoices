using InvoiceManagementLibrary.Entities;

namespace InvoiceManagementLibrary.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly List<InvoiceEntity> _mockInvoices = new List<InvoiceEntity>
        {
            new InvoiceEntity { InvoiceId = 1, CustomerId = 1234, OrderId = 1234, Amount = 100, Status = "Paid" },
            new InvoiceEntity { InvoiceId = 2, CustomerId = 12345, OrderId = 12345, Amount = 200, Status = "Pending" }
        };

        public async Task<List<InvoiceEntity>> GetAllInvoicesAsync()
        {
            try
            {
                return await Task.FromResult(_mockInvoices);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid hämtning av alla fakturor: {ex.Message}");
                throw;
            }
        }

        public async Task<InvoiceEntity?> GetInvoiceByIdAsync(int invoiceId)
        {
            try
            {
                var invoice = _mockInvoices.FirstOrDefault(i => i.InvoiceId == invoiceId);
                return await Task.FromResult(invoice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid hämtning av faktura med ID {invoiceId}: {ex.Message}");
                throw;
            }
        }
    }
}
