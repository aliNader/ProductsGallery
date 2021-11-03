using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Product : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public DateTime ExpiredDate { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }

    }
}
