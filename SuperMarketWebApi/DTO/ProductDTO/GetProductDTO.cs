using System;

namespace SuperMarketWebApi.DTO.ProductDTO
{
    public class GetProductDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public DateTime ProductionDate { get; set; }

        public DateTime ExpiredDate { get; set; }
    }
}
