using AutoMapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using SuperMarketWebApi.DTO.InvoiceDetailDTO;
using SuperMarketWebApi.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperMarketWebApi.Controllers
{
    public class ProductController : Controller
    {
        private IRepository<Product> _repository;
        private IMapper _mapper;
        public ProductController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet(nameof(GetProducts))]
        public async Task<IEnumerable<GetProductDTO>> GetProducts()
        {
            var result = _mapper.Map<List<GetProductDTO>>(_repository.GetAll().Result);
            return result;
        }

        [HttpGet(nameof(GetProductById))]
        public async Task<GetProductDTO> GetProductById([FromQuery] string Id)
        {
            var result = _mapper.Map<GetProductDTO>(_repository.GetById(Guid.Parse(Id)).Result);
            return result;
        }

        [HttpPost(nameof(CreateProduct))]
        public async Task<Product> CreateProduct(CreateProductDTO productDTO)
        {
            try
            {
                var result = _repository.Create(_mapper.Map<Product>(productDTO));
                _repository.SaveChanges();
                return result.Result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut(nameof(UpdateProduct))]
        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await _repository.Update(product);
            _repository.SaveChanges();
            return result;
        }
        [HttpDelete(nameof(DeleteProduct))]
        public Task DeleteProduct(Guid iD)
        {
            var result = _repository.Delete(iD);
            _repository.SaveChanges();
            return result;
        }
    }
}
