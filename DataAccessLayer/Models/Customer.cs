using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Customer : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(32)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32)]
        public string LastName { get; set; }

        [Required]
        [StringLength(32)]
        public string FatherName { get; set; }

        [Required]
        [StringLength(32)]
        public string MotherName { get; set; }

        [Required]
        [StringLength(16)]
        public string NationalNo { get; set; }

        [StringLength(96)]
        public string FullName => $"{FirstName} {FatherName} {LastName}";

        public ICollection<Invoice> Invoices { get; set; }
    }
}
