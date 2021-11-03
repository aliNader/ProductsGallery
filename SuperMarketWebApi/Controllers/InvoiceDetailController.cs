using AutoMapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using SuperMarketWebApi.DTO.InvoiceDetailDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperMarketWebApi.Controllers
{
    public class InvoiceDetailController : Controller
    {
        private IInvoiceDetailRepository _repository;
        IMapper _mapper;
        public InvoiceDetailController(IInvoiceDetailRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet(nameof(GetInvoiceDetail))]
        public async Task<IEnumerable<InvoiceDetail>> GetInvoiceDetail()
        {
            return _repository.GetAll().Result;
        }

        [HttpGet(nameof(GetInvoiceDetailById))]
        public async Task<InvoiceDetail> GetInvoiceDetailById([FromQuery] string Id)
        {
            return _repository.GetById(Guid.Parse(Id)).Result;
        }

        [HttpPost(nameof(CreateInvoiceDetail))]
        public async Task<InvoiceDetail> CreateInvoiceDetail(CreateInvoiceDetailDTO invoiceDetailDTO)
        {
            try
            {
                var result = _repository.Create(_mapper.Map<InvoiceDetail>(invoiceDetailDTO));
                _repository.SaveChanges();

                return result.Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut(nameof(UpdateInvoiceDetail))]
        public async Task<InvoiceDetail> UpdateInvoiceDetail(UpdateInvoiceDetailDTO entity)
        {
            var entityTemp = _repository.GetById(entity.Id).Result;
            entityTemp.Count = entity.Count;
            var result = await _repository.Update(entityTemp);
            _repository.SaveChanges();
            return result;
        }
        [HttpDelete(nameof(DeleteInvoiceDetail))]
        public Task DeleteInvoiceDetail(Guid iD)
        {
            var result = _repository.Delete(iD);
            _repository.SaveChanges();
            return result;
        }

        [HttpGet(nameof(GetInvoiceDetailByInvoiceId))]
        public IEnumerable<InvoiceDetail> GetInvoiceDetailByInvoiceId(Guid invoiceId)
        {
            var result = _repository.GetInvoiceDetalsByInvoiceId(invoiceId);
            _repository.SaveChanges();
            return result;
        }
    }
}
