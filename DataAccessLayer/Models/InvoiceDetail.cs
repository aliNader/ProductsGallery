using DataAccessLayer.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class InvoiceDetail : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Invoice")]
        public Guid InvoiceId { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        
        [Required]
        public int Count { get; set; }
    }
}
