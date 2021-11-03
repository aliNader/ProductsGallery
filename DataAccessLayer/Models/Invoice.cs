using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Invoice : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }

        [Required]
        [StringLength(16)]
        public string No { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        public double TotalPrice { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
