using AutoMapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using SuperMarketWebApi.DTO.InvoiceDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperMarketWebApi.Controllers
{
    public class InvoiceController : Controller
    {
        private IInvoiceRepository _repository;
        private IMapper _mapper;
        public InvoiceController(IInvoiceRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet(nameof(GetInvoices))]
        public async Task<IEnumerable<GetInvoiceDTO>> GetInvoices()
        {
            var result = _mapper.Map<List<GetInvoiceDTO>>(_repository.GetAll().Result);
            return result;
        }

        [HttpGet(nameof(GetInvoiceById))]
        public async Task<GetInvoiceDTO> GetInvoiceById([FromQuery] string Id)
        {
            var result = _mapper.Map<GetInvoiceDTO>(_repository.GetById(Guid.Parse(Id)).Result);
            return result;
        }

        [HttpPost(nameof(IssueInvoice))]
        public async Task<Invoice> IssueInvoice(CreateInvoiceDTO invoiceDTO)
        {
            try
            {
                var invoice = _mapper.Map<Invoice>(invoiceDTO);
                var result = _repository.Create(invoice);
                _repository.SaveChanges();
                return result.Result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //[HttpPut(nameof(UpdateInvoice))]
        //public async Task<Invoice> UpdateInvoice(Invoice invoice)
        //{
        //    var result = await _repository.Update(invoice);
        //    _repository.SaveChanges();
        //    return result;
        //}
        [HttpDelete(nameof(DeleteInvoice))]
        public Task DeleteInvoice(Guid iD)
        {
            var result = _repository.Delete(iD);
            _repository.SaveChanges();
            return result;
        }

        [HttpGet(nameof(GetInvoicesByCustomerId))]
        public IEnumerable<GetInvoiceDTO> GetInvoicesByCustomerId(Guid customerId)
        {
            var result = _mapper.Map<List<GetInvoiceDTO>>(_repository.GetInvoicesByCustomerId(customerId));
            return result;
        }
    }
}
