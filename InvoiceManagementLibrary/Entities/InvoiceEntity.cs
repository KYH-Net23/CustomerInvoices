
using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementLibrary.Entities;

public class InvoiceEntity
{
    [Key]
    public int InvoiceId { get; set; } 
    public DateTime Date { get; set; }
    public int CustomerId { get; set; }
    public int OrderId { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? PaidDate { get; set; }
    public decimal Amount { get; set; }
    public string? Status { get; set; }

}
