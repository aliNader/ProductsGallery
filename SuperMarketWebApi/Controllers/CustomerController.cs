using AutoMapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using SuperMarketWebApi.DTO.CustomerDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperMarketWebApi.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _repository;
        private IMapper _mapper;
        public CustomerController(ICustomerRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet(nameof(GetCustomers))]
        public async Task<IEnumerable<GetCustomerDTO>> GetCustomers()
        {
            var result = _mapper.Map<List<GetCustomerDTO>>(_repository.GetAll().Result);
            return result;
        }

        [HttpGet(nameof(GetCustomerById))]
        public async Task<GetCustomerDTO> GetCustomerById([FromQuery] string Id)
        {
            var result = _mapper.Map<GetCustomerDTO>(_repository.GetById(Guid.Parse(Id)).Result);
            return result;
        }

        [HttpPost(nameof(CreateCustomer))]
        public async Task<Customer> CreateCustomer(CreateCustomerDTO customerDTO)
        {
            try
            {
                var customer = _mapper.Map<Customer>(customerDTO);
                var result = _repository.Create(customer);
                _repository.SaveChanges();
                return result.Result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut(nameof(UpdateCustomer))]
        public async Task<Customer> UpdateCustomer(UpdateCustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            var result = await _repository.Update(customer);
            _repository.SaveChanges();
            return result;
        }
        [HttpDelete(nameof(DeleteCustomer))]
        public Task DeleteCustomer(Guid iD)
        {
            var result = _repository.Delete(iD);
            _repository.SaveChanges();
            return result;
        }
    }
}
