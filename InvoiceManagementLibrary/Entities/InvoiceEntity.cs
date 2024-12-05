
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
   
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    public string? Status { get; set; }

}
