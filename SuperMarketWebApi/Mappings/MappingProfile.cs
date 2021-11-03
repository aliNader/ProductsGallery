using AutoMapper;
using DataAccessLayer.Models;
using SuperMarketWebApi.DTO.CustomerDTO;
using SuperMarketWebApi.DTO.InvoiceDetailDTO;
using SuperMarketWebApi.DTO.InvoiceDTO;
using SuperMarketWebApi.DTO.ProductDTO;

namespace SuperMarketWebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, GetCustomerDTO>();
            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<UpdateCustomerDTO, Customer>();

            CreateMap<Invoice, GetInvoiceDTO>();
            CreateMap<CreateInvoiceDTO, Invoice>();

            CreateMap<CreateInvoiceDetailDTO, InvoiceDetail>();

            CreateMap<CreateProductDTO, Product>();
            CreateMap<Product, GetProductDTO>();
        }
    }
}
