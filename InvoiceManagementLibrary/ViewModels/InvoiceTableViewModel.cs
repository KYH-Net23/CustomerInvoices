namespace InvoiceManagementLibrary.ViewModels;

public class InvoiceTableViewModel
{
  
        public int InvoiceId { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string? Status { get; set; }
    
}


