using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System.Diagnostics;

namespace Shop
{
    public class HomeController : Controller
    {
        private readonly IProductFetchService _productFetchService;

        public HomeController(IProductFetchService productFetchService)
        {
            _productFetchService = productFetchService;
        }

        public IActionResult Index()
        {
            List<Product> products;

            products = _productFetchService.GetProducts();

            return View(products);
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