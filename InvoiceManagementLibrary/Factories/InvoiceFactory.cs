using InvoiceManagementLibrary.Entities;
using InvoiceManagementLibrary.Models;
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

    public static InvoiceEntity CreateInvoiceEntity(InvoiceModel invoice)
    {
        return new InvoiceEntity
        {
            OrderId = invoice.OrderId,
            CustomerId = invoice.CustomerId,
            DueDate = invoice.DueDate,
            PaidDate = invoice.PaidDate,
            Amount = invoice.Amount,
            Status = invoice.Status
        };
    }

   
}
