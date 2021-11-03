using System;

namespace SuperMarketWebApi.DTO.InvoiceDTO
{
    public class GetInvoiceDTO
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public string No { get; set; }

        public DateTime InvoiceDate { get; set; }

        public double TotalPrice { get; set; }
    }
}
