using InvoiceManagementLibrary.Entities;
using InvoiceManagementLibrary.Factories;
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

        public async Task<string> CreateInvoiceAsync(InvoiceEntity model)
        {
            if (model.Amount <= 0)
            {
                throw new ArgumentException("Beloppet måste vara större än noll.");
            }

            if (model.DueDate < model.Date)
            {
                throw new ArgumentException("Förfallodatum måste vara senare än fakturadatum.");
            }

            model.Status = "Unpaid";
            string result = await _invoiceRepository.AddAsync(model);
            await _invoiceRepository.SaveChangesAsync(); // Bekräfta ändringar
            return result;
        }


        public async Task<InvoiceEntity?> UpdateInvoiceAsync(int invoiceId, InvoiceEntity updatedModel)
        {
            try
            {
                var updatedInvoice = await _invoiceRepository.UpdateInvoiceAsync(invoiceId, updatedModel);
                if (updatedInvoice == null)
                {
                    Console.WriteLine($"Invoice with ID {invoiceId} not found.");
                    return null;
                }
                await _invoiceRepository.SaveChangesAsync(); // Bekräfta ändringarna i databasen
                return updatedInvoice;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating invoice with ID {invoiceId}: {ex.Message}");
                throw;
            }
        }

        public async Task<InvoiceEntity?> DeleteInvoiceAsync(int invoiceId)
        {
            try
            {
                var deletedInvoice = await _invoiceRepository.DeleteInvoiceAsync(invoiceId);
                if (deletedInvoice == null)
                {
                    Console.WriteLine($"Invoice with ID {invoiceId} not found.");
                    return null;
                }
                await _invoiceRepository.SaveChangesAsync(); // Bekräfta borttagning i databasen
                return deletedInvoice;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting invoice with ID {invoiceId}: {ex.Message}");
                throw;
            }
        }
    }
}
