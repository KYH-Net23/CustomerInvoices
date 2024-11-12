using InvoiceManagementLibrary.Entities;
using InvoiceManagementLibrary.ViewModels;

namespace InvoiceManagementLibrary.Factories;

public static class InvoiceFactory
{
    public static InvoiceTableViewModel CreateInvoiceTableViewModel(InvoiceEntity invoice)
    {
        return new InvoiceTableViewModel
        {
            InvoiceId = invoice.InvoiceId,
            OrderId = invoice.OrderId,
            CustomerId = invoice.CustomerId,
            Amount = invoice.Amount,
            Status = invoice.Status
        };
    }
}
