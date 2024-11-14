using InvoiceManagementLibrary.Entities;

namespace InvoiceManagementLibrary.Repositories
{
    public interface IInvoiceRepository
    {
        Task<List<InvoiceEntity>> GetAllInvoicesAsync();
        Task<InvoiceEntity?> GetInvoiceByIdAsync(int invoiceId);
        Task<string> AddAsync(InvoiceEntity model);
        Task<InvoiceEntity?> UpdateInvoiceAsync(int invoiceId, InvoiceEntity updatedModel);
        Task<InvoiceEntity?> DeleteInvoiceAsync(int invoiceId);


    }
}
