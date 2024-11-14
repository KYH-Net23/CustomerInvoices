using InvoiceManagementLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementLibrary.Contexts
{
    public class InvoiceDbContext : DbContext  
    {
     protected InvoiceDbContext()
        {

        }

        public InvoiceDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<InvoiceEntity> Invoices { get; set; }

    }
}
