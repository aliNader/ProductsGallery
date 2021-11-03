using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(SuperMarketDbContext context) : base(context)
        {

        }
        public IEnumerable<Invoice> GetInvoicesByCustomerId(Guid customerId)
        {
            return _context.Invoices.Where(inv => inv.CustomerId == customerId).ToList();
        }
    }
}
