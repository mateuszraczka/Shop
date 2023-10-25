using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System.Diagnostics;

namespace Shop
{
    public class HomeController : Controller
    {
        private readonly IProductFetchService _productFetchService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductFetchService productFetchService)
        {
            _productFetchService = productFetchService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> products;

            try
            {
                products = _productFetchService.GetProducts();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }

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