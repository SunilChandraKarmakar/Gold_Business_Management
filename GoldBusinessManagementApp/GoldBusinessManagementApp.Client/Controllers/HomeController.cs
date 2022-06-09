using GoldBusinessManagementApp.Client.Models;
using GoldBusinessManagementApp.Manager.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GoldBusinessManagementApp.Client.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerManager _customerManager;
        private IProductManager _productManager;

        public HomeController(ICustomerManager customerManager, IProductManager productManager)
        {
            _customerManager = customerManager;
            _productManager = productManager;
        }

        public async Task<IActionResult> Index()
        {
            var totalCustomer = await _customerManager.GetAll();
            ViewBag.totalCustomerCount = totalCustomer.Count();

            var totlProduct = await _productManager.GetAll();
            ViewBag.totalProductCount = totlProduct.Count();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}