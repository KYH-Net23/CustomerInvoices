using InvoiceManagementLibrary.Entities;

namespace InvoiceManagementLibrary.Repositories
{
    public interface IInvoiceRepository
    {
        Task<List<InvoiceEntity>> GetAllInvoicesAsync();
        Task<InvoiceEntity?> GetInvoiceByIdAsync(int invoiceId);
    }
}
