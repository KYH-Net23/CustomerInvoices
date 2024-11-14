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

        public async Task<string> AddAsync(InvoiceEntity model)
        {
            try
            {
                model.InvoiceId = _mockInvoices.Max(i => i.InvoiceId) + 1; 
                _mockInvoices.Add(model);
                return await Task.FromResult("Invoice successfully added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid tillägg av faktura: {ex.Message}");
                throw;
            }
        }

        public async Task<InvoiceEntity?> UpdateInvoiceAsync(int invoiceId, InvoiceEntity updatedModel)
        {
            try
            {
                var invoice =  _mockInvoices.FirstOrDefault(i =>i.InvoiceId == invoiceId);
                if (invoice == null) 
                {
                    return await Task.FromResult<InvoiceEntity?>(null); 
                }

                invoice.CustomerId = updatedModel.CustomerId;
                invoice.OrderId = updatedModel.OrderId;
                invoice.Amount = updatedModel.Amount;
                invoice.Status = updatedModel.Status;
                invoice.DueDate = updatedModel.DueDate;
                invoice.Date = updatedModel.Date;

                return await Task.FromResult(invoice);
            }

            catch (Exception ex) 
            {
                Console.WriteLine($"Ett fel uppstod vid uppdatering av faktura med ID {invoiceId}: {ex.Message}");
                throw;
            }
        }


        public async Task<InvoiceEntity?> DeleteInvoiceAsync(int invoiceId)
            {
                try 
            { 
                var invoice = _mockInvoices.FirstOrDefault(i =>i.InvoiceId == invoiceId);
                if (invoice == null)
                {
                    return  await Task.FromResult<InvoiceEntity?>(null);
                }

                _mockInvoices.Remove(invoice);
                return await Task.FromResult(invoice);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid borttagning av faktura med ID {invoiceId}: {ex.Message}");
                throw;
            }
        }


    }
}
