using AutoMapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarketWebApp.DTO.CustomerDTO;
using System;

namespace SuperMarketWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;
        public CustomerController(ICustomerRepository customerRepository,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            var result = _customerRepository.GetAll();
            return View(result.Result);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(Guid id)
        {
            var result = _customerRepository.GetById(id);
            return View();
        }


        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer(CreateCustomerDTO entity)
        {
            try
            {
                var result = _mapper.Map<Customer>(entity);
                _customerRepository.Create(result);
                _customerRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: CustomerController/Edit/5
        public ActionResult EditCustomer(Guid id)
        {
            var entity = _customerRepository.GetById(id);
            var updateCustomerObj = _mapper.Map<UpdateCustomerDTO>(entity.Result);
            return View(updateCustomerObj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(UpdateCustomerDTO customer)
        {
            var result = _mapper.Map<Customer>(customer);
            _customerRepository.Update(result);
            _customerRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(Guid id)
        {
            _customerRepository.Delete(id);
            _customerRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
