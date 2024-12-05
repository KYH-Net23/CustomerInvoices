using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementLibrary.Models
{
    public class InvoiceModel
    {
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaidDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string? Status { get; set; }
    }
}
