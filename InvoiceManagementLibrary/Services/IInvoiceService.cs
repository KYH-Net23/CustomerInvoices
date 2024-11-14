using InvoiceManagementLibrary.Entities;


namespace InvoiceManagementLibrary.Services;

public interface IInvoiceService
{
        Task<List<InvoiceEntity>> GetAllInvoicesAsync();
        Task<InvoiceEntity?> GetInvoiceByIdAsync(int invoiceId);
        Task<string> CreateInvoiceAsync(InvoiceEntity model);
        Task<InvoiceEntity?> UpdateInvoiceAsync(int invoiceId, InvoiceEntity updatedModel);
        Task<InvoiceEntity?> DeleteInvoiceAsync(int invoiceId);

}
