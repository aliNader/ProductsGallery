using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IInvoiceDetailRepository : IRepository<InvoiceDetail>
    {
        public IEnumerable<InvoiceDetail> GetInvoiceDetalsByInvoiceId(Guid invoiceId);
    }
}
