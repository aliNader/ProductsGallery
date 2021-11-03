using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class InvoiceDetailRepository : BaseRepository<InvoiceDetail>,IInvoiceDetailRepository
    {
        private InvoiceRepository _invoiceRepository;
        public InvoiceDetailRepository(SuperMarketDbContext context) : base(context)
        {
            
            _invoiceRepository = new InvoiceRepository(context);
        }

        public async Task<InvoiceDetail> Create(InvoiceDetail entity)
        {
            using (var transation = _context.Database.BeginTransaction())
            {
                var temp = _context.InvoiceDetails.FirstOrDefault(inv => inv.InvoiceId == entity.InvoiceId &&
                                                                         inv.ProductId == entity.ProductId);
                if (temp != null)
                    throw new Exception("This product is already included in the invoice");
                else
                {
                    try
                    {
                        //Add Invoice Detail
                        var result = _context.InvoiceDetails.Add(entity).Entity;
                        var invoice = _context.Invoices.FirstOrDefault(inv => inv.Id == entity.InvoiceId);
                        var product = _context.Products.FirstOrDefault(pro => pro.Id == entity.ProductId);
                        //Update Invoice Total Price
                        invoice.TotalPrice = invoice.TotalPrice + (entity.Count * product.Price);
                        _context.Entry(invoice).State = EntityState.Modified;
                        transation.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        transation.Rollback();
                        throw ex;
                    }
                }
            }
        }
        public async Task<InvoiceDetail> Update(InvoiceDetail entity)
        {
            using (var transation = _context.Database.BeginTransaction())
            {
                try
                {
                    var invoice = _context.Invoices.FirstOrDefault(inv => inv.Id == entity.InvoiceId);
                    var product = _context.Products.FirstOrDefault(pro => pro.Id == entity.ProductId);
                    //Update Invoice Total Price
                    invoice.TotalPrice = entity.Count * product.Price;
                    var result = _context.Entry(entity).State = EntityState.Modified;
                    _context.Entry(invoice).State = EntityState.Modified;
                    transation.Commit();
                    return entity;
                }
                catch (Exception ex)
                {
                    transation.Rollback();
                    throw ex;
                }
            }
        }

        public async Task Delete(InvoiceDetail entity)
        {
            using (var transation = _context.Database.BeginTransaction())
            {
                try
                {
                    var invoice = _context.Invoices.FirstOrDefault(inv => inv.Id == entity.InvoiceId);
                    var product = _context.Products.FirstOrDefault(pro => pro.Id == entity.ProductId);
                    //Update Invoice Total Price
                    invoice.TotalPrice = invoice.TotalPrice - (entity.Count * product.Price);
                    _context.Set<InvoiceDetail>().Remove(entity);

                    transation.Commit();
                }
                catch (Exception ex)
                {
                    transation.Rollback();
                    throw ex;
                }
            }
        }

        public IEnumerable<InvoiceDetail> GetInvoiceDetalsByInvoiceId(Guid invoiceId)
        {
            return _context.InvoiceDetails.Where(inv => inv.InvoiceId == invoiceId).ToList();
        }
    }
}
