using System;

namespace SuperMarketWebApi.DTO.CustomerDTO
{
    public class GetCustomerDTO
    {
        public Guid Id { get; set; }

        public string MotherName { get; set; }

        public string NationalNo { get; set; }

        public string FullName { get; set; }
    }
}
