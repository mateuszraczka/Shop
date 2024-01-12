using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System.Data;

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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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