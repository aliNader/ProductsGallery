using System;

namespace SuperMarketWebApi.DTO.InvoiceDetailDTO
{
    public class CreateInvoiceDetailDTO
    {
        public Guid InvoiceId { get; set; }

        public Guid ProductId { get; set; }

        public int Count { get; set; }
    }
}
