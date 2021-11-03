using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        public IEnumerable<Invoice> GetInvoicesByCustomerId(Guid customerId);
    }
}
