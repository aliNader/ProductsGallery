using System;

namespace SuperMarketWebApi.DTO.InvoiceDTO
{
    public class CreateInvoiceDTO
    {
        public Guid CustomerId { get; set; }

        public string No { get; set; }

        public DateTime InvoiceDate { get; set; }
    }
}
