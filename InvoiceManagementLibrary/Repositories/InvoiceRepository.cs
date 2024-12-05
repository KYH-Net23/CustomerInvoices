using InvoiceManagementLibrary.Contexts;
using InvoiceManagementLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementLibrary.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceDbContext _context;

        public InvoiceRepository(InvoiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<InvoiceEntity>> GetAllInvoicesAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<InvoiceEntity?> GetInvoiceByIdAsync(int invoiceId)
        {
            return await _context.Invoices.FindAsync(invoiceId);
        }

        public async Task<string> AddAsync(InvoiceEntity model)
        {
            await _context.Invoices.AddAsync(model);
            return "Invoice successfully added.";
        }

        public async Task<InvoiceEntity?> UpdateInvoiceAsync(int invoiceId, InvoiceEntity updatedModel)
        {
            var existingInvoice = await _context.Invoices.FindAsync(invoiceId);
            if (existingInvoice == null) return null;

            existingInvoice.CustomerId = updatedModel.CustomerId;
            existingInvoice.OrderId = updatedModel.OrderId;
            existingInvoice.Amount = updatedModel.Amount;
            existingInvoice.Status = updatedModel.Status;
            existingInvoice.DueDate = updatedModel.DueDate;
            existingInvoice.Date = updatedModel.Date;

            return existingInvoice;
        }

        public async Task<InvoiceEntity?> DeleteInvoiceAsync(int invoiceId)
        {
            var invoice = await _context.Invoices.FindAsync(invoiceId);
            if (invoice == null) return null;

            _context.Invoices.Remove(invoice);
            return invoice;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
