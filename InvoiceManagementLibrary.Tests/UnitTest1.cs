using InvoiceManagementLibrary.Repositories;


namespace InvoiceManagementLibrary.Tests.Repositories
{
    public class InvoiceRepositoryTests
    {
        [Fact]
        public async Task GetAllInvoicesAsync_ShouldReturnMockData()
        {
            var repository = new InvoiceRepository();

            var invoices = await repository.GetAllInvoicesAsync();

            Assert.NotNull(invoices);
            Assert.Equal(2, invoices.Count);
            Assert.Equal(1234, invoices[0].CustomerId); 
        }

        [Fact]
        public async Task GetInvoiceByIdAsync_ShouldReturnCorrectInvoice()
        {
            var repository = new InvoiceRepository();

            var invoice = await repository.GetInvoiceByIdAsync(1);

            Assert.NotNull(invoice);
            Assert.Equal(1, invoice.InvoiceId);
            Assert.Equal(1234, invoice.CustomerId); 
        }


        [Fact]
        public async Task GetInvoiceByIdAsync_ShouldReturnNullForInvalidId()
        {
            
            var repository = new InvoiceRepository();

            var invoice = await repository.GetInvoiceByIdAsync(999); 
            
            Assert.Null(invoice);
        }
    }
}
