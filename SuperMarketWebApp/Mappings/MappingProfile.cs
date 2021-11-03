using AutoMapper;
using DataAccessLayer.Models;
using SuperMarketWebApi.DTO.InvoiceDetailDTO;
using SuperMarketWebApi.DTO.InvoiceDTO;
using SuperMarketWebApi.DTO.ProductDTO;
using SuperMarketWebApp.DTO.CustomerDTO;

namespace SuperMarketWebApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, GetCustomerDTO>();
            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<UpdateCustomerDTO, Customer>();
            CreateMap<Customer, UpdateCustomerDTO>();

            CreateMap<Invoice, GetInvoiceDTO>();
            CreateMap<CreateInvoiceDTO, Invoice>();

            CreateMap<CreateInvoiceDetailDTO, InvoiceDetail>();

            CreateMap<CreateProductDTO, Product>();
            CreateMap<Product, GetProductDTO>();
        }
    }
}
