using AutoMapper;
using GoldBusinessManagementApp.Client.ViewModels.Customer;
using GoldBusinessManagementApp.Client.ViewModels.Product;
using GoldBusinessManagementApp.Manager.Contracts;
using GoldBusinessManagementApp.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;

namespace GoldBusinessManagementApp.Client.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICustomerManager _customerManager;
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public ProductController(IProductManager productManager, IMapper mapper, IToastNotification toastNotification, 
            ICustomerManager customerManager)
        {
            _productManager = productManager;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _customerManager = customerManager;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductViewModel>>> Index()
        {
            var products = _mapper.Map<ICollection<ProductViewModel>>(await _productManager.GetAll());
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Customers = await CustomerSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductCreateViewModel model)
        {
            model.Code = await GenerateCode(6);
            //model.CustomerId = Convert.ToInt32(model.CustomerId);

            try
            {
                if (ModelState.IsValid)
                {
                    var productCreateModel = _mapper.Map<Product>(model);
                    var isCreated = await _productManager.Create(productCreateModel);

                    if (isCreated)
                    {
                        _toastNotification.AddSuccessToastMessage("Product create successfull.");
                        return RedirectToAction("Index");
                    }

                    ViewBag.Customers = await CustomerSelectList();
                    return ViewBag.ErrorMessage = "Product can not be saved! Try again.";
                }

                ViewBag.Customers = await CustomerSelectList();
                return View(ModelState.IsValid);
            }
            catch
            {
                ViewBag.Customers = await CustomerSelectList();
                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ProductUpdateViewModel>> Details(int? id)
        {
            if (id == null)
            {
                _toastNotification.AddWarningToastMessage("Product can't found! Try again.");
                return RedirectToAction("Index");
            }

            var existProduct = _mapper.Map<ProductUpdateViewModel>(await _productManager.GetById(id));

            if (existProduct == null)
            {
                _toastNotification.AddWarningToastMessage("Product can't found! Try again.");
                return RedirectToAction("Index");
            }

            ViewBag.Customers = await CustomerSelectList();
            return View(existProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(ProductUpdateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updateProduct = _mapper.Map<Product>(model);
                    var isUpdateProduct = await _productManager.Update(updateProduct);

                    if (isUpdateProduct)
                    {
                        _toastNotification.AddSuccessToastMessage("Product update successfull.");
                        return RedirectToAction("Index");
                    }

                    return ViewBag.ErrorMessage = "Product update has been failed!";
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
            if (id == null)
            {
                _toastNotification.AddWarningToastMessage("Product can't found! Try again.");
                return RedirectToAction("Index");
            }

            var existProduct = await _productManager.GetById(id);
            var isDeleted = await _productManager.Delete(existProduct);

            if (isDeleted)
            {
                _toastNotification.AddSuccessToastMessage("Product delete successfull.");
                return RedirectToAction("Index");
            }
            else
            {
                _toastNotification.AddWarningToastMessage("Product can't found! Try again.");
                return RedirectToAction("Index");
            }
        }

        private async Task<List<SelectListItem>> CustomerSelectList()
        {
            List<CustomerViewModel> customers = _mapper.Map<List<CustomerViewModel>>(await _customerManager.GetAll());
            var customerSelectList = customers.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            return customerSelectList;
        }

        private async Task<string> GenerateCode(int length)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
