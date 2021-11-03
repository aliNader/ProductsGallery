using System;

namespace SuperMarketWebApi.DTO.CustomerDTO
{
    public class UpdateCustomerDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string NationalNo { get; set; }
    }
}
