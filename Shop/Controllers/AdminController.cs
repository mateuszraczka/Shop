using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop
{
    public class AdminController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IWebHostEnvironment _environment;


        public AdminController(IProductServices productServices, IWebHostEnvironment environment)
        {
            _productServices = productServices;
            _environment = environment;
        }

        // GET: AdminController
        public ActionResult Index()
        {
            List<Product> products = _productServices.GetProducts();

            if (TempData.ContainsKey("DeleteConfirmation"))
            {
                var deleteConfirmation = TempData["DeleteConfirmation"];
                ViewBag.DeleteConfirmation = deleteConfirmation;
            }

            return View(products);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
           bool deletionSuccessful = _productServices.DeleteProduct(id);

           if (deletionSuccessful)
           {
                TempData["DeleteConfirmation"] = true;
           }
           else
           {
                TempData["DeleteConfirmation"] = false;
           }

            return RedirectToAction("Index");
        }
    }
}