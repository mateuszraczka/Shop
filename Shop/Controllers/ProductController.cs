using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productService)
        {
            _productServices = productService; // Implement products service for CRUD operations from database
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            Product product = new();

            try
            {
                product = _productServices.GetProductById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Index", "Admin");
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                bool deletionSuccessful = _productServices.DeleteProduct(id);

                if (deletionSuccessful)
                {
                    TempData["DeleteConfirmation"] = "Product deleted successfully.";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["DeleteConfirmation"] = "An error occurred while deleting the product.";
            }

            return RedirectToAction("Index", "Admin");
        }
    }
}
