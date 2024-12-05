using InvoiceManagementLibrary.Contexts;
using InvoiceManagementLibrary.Entities;
using InvoiceManagementLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace InvoiceManagementLibrary.Tests.Repositories
{
    public class InvoiceRepositoryTests
    {
        private InvoiceDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<InvoiceDbContext>()
                .UseSqlServer("Server=tcp:bankdbserver.database.windows.net,1433;Initial Catalog=invoice-provider;Persist Security Info=False;User ID=Bankadmin;Password=Invoice123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;") 
                .Options;

            return new InvoiceDbContext(options);
        }

        private async Task SeedDatabase(InvoiceDbContext context)
        {
            context.Invoices.RemoveRange(context.Invoices);
            await context.SaveChangesAsync();

            context.Invoices.AddRange(
                new InvoiceEntity { InvoiceId = 1, CustomerId = 1234, Amount = 1000, Status = "Paid" },
                new InvoiceEntity { InvoiceId = 2, CustomerId = 5678, Amount = 2000, Status = "Unpaid" }
            );
            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetAllInvoicesAsync_ShouldReturnAllInvoices()
        {
            using var context = CreateDbContext();
            await SeedDatabase(context); 

            var repository = new InvoiceRepository(context);
            var invoices = await repository.GetAllInvoicesAsync();

            Assert.NotNull(invoices);
            Assert.Equal(2, invoices.Count); 
            Assert.Equal(1234, invoices[0].CustomerId); 
        }

        [Fact]
        public async Task GetInvoiceByIdAsync_ShouldReturnCorrectInvoice()
        {
            using var context = CreateDbContext();
            await SeedDatabase(context);

            var repository = new InvoiceRepository(context);
            var invoice = await repository.GetInvoiceByIdAsync(1); 

            Assert.NotNull(invoice);
            Assert.Equal(1, invoice.InvoiceId);
            Assert.Equal(1234, invoice.CustomerId);
        }

        [Fact]
        public async Task GetInvoiceByIdAsync_ShouldReturnNullForInvalidId()
        {
            using var context = CreateDbContext();
            await SeedDatabase(context);

            var repository = new InvoiceRepository(context);
            var invoice = await repository.GetInvoiceByIdAsync(999); 

            Assert.Null(invoice);
        }
    }
}
