using InvoiceManagementLibrary.Entities;


namespace InvoiceManagementLibrary.Services;

public interface IInvoiceService
{
   
        Task<List<InvoiceEntity>> GetAllInvoicesAsync();
        Task<InvoiceEntity?> GetInvoiceByIdAsync(int invoiceId);
    


}
