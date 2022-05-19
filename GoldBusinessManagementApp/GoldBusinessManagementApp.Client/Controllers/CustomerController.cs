using AutoMapper;
using GoldBusinessManagementApp.Client.ViewModels.Customer;
using GoldBusinessManagementApp.Manager.Contracts;
using GoldBusinessManagementApp.Model.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace GoldBusinessManagementApp.Client.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerManager _customerManager;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public CustomerController(ICustomerManager customerManager, IMapper mapper, IToastNotification toastNotification)
        {
            _customerManager = customerManager;
            _mapper = mapper;
           _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<CustomerViewModel>>> Index()
        {
            var customers = _mapper.Map<ICollection<CustomerViewModel>>(await _customerManager.GetAll());
            return View(customers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CustomerCreateViewModel>> Create(CustomerCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customerCreateModel = _mapper.Map<Customer>(model);
                    var isCreated = await _customerManager.Create(customerCreateModel);

                    if (isCreated)
                    {
                        _toastNotification.AddSuccessToastMessage("Customer create successfull.");
                        return RedirectToAction("Index");
                    }

                    return ViewBag.ErrorMessage = "Customer can not be saved! Try again.";
                }

                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult<CustomerUpdateViewModel>> Details(int? id)
        {
            if(id == null)
            {
                _toastNotification.AddWarningToastMessage("Customer can't found! Try again.");
                return RedirectToAction("Index");
            }

            var existCustomer = _mapper.Map<CustomerUpdateViewModel>(await _customerManager.GetById(id));

            if (existCustomer == null)
            {
                _toastNotification.AddWarningToastMessage("Customer can't found! Try again.");
                return RedirectToAction("Index");
            }

            return View(existCustomer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(CustomerUpdateViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var updateCustomer =  _mapper.Map<Customer>(model);
                    var isUpdateCustomer = await _customerManager.Update(updateCustomer);
                    
                    if(isUpdateCustomer)
                    {
                        _toastNotification.AddSuccessToastMessage("Customer update successfull.");
                        return RedirectToAction("Index");
                    }

                    return ViewBag.ErrorMessage = "Customer update has been failed!";
                }

                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if(id == null)
            {
                _toastNotification.AddWarningToastMessage("Customer can't found! Try again.");
                return RedirectToAction("Index");
            }

            var existCustomer = await _customerManager.GetById(id);
            var isDeleted = await _customerManager.Delete(existCustomer);

            if (isDeleted)
            {
                _toastNotification.AddSuccessToastMessage("Customer delete successfull.");
                return RedirectToAction("Index");
            }  
            else
            {
                _toastNotification.AddWarningToastMessage("Customer can't found! Try again.");
                return RedirectToAction("Index");
            }
        }
    }
}
